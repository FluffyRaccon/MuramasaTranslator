using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Muramasa_Translator
{
    public partial class mainUI : Form
    {
        private bool isOpen  = false, 
                     change  = false, 
                     control = true;

        //Replacement chars for the accents.
        private char aacute = '¬',
                     eacute = '}',
                     iacute = '{',
                     oacute = 'ó',
                     uacute = 'ú';

        private string currentLinePrefix = "Línea actual: ";

        //Saves the previous offset before reading the bytes in file.
        private int prevOffset;

        //Sets the limits for reading the files
        private static int minOffset = 0;
        private static int maxOffset = 0;


        public int current = 0, template;                               //Controla la posición del array de la traducción.

        List<byte> readBytes = new List<byte>();

        private string original, translated;                            //Se crea un array para que lo pueda transferir al RichTextBox.
        private static int offset = 0;
        private static int required = 0;
        public static int currentLine = 0;
        public static int totalLines = 0;

        public static string  inputPath, outputPath;

        private Stack<string> undoList = new Stack<string>();

        public mainUI()
        {
            InitializeComponent();
            etqPreviewDialog.Visible = false;
            etqSysMsg.Visible = false;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isOpen && change && outputPath!=null)
            {
                using (var fs = new FileStream(openFileDialog.FileName, FileMode.Create))
                using (var bw = new BinaryWriter(fs))
                {
                    //bw.Write(0x42534D4E); // Writes the file header => "NMSB". This can be omited, the header is already known and written.

                }
                //Perform save action merging the header file + data + footer.
            }
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Call to action open file dialog => openNMSFile();
            openNMSFile();


        }

        public void UpdateCurrentLine()
        {
            
        }

        //private static string ConvertStringArrayToByte(string[] array)
        //{
        //    // Concatenate all the elements into a StringBuilder.
        //    StringBuilder builder = new StringBuilder();
        //    foreach (string value in array)
        //    {
        //        builder.Append(value);
        //        builder.Append('\0');
        //    }
        //    string res = builder.ToString();
        //    var plainTextBytes = Encoding.UTF8.GetBytes(res);
        //    return Convert.ToBase64String(plainTextBytes);
        //}

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tutorial window = new Tutorial();
            window.Show();
        }

        private void countLinesOnFile(string file) {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                while (true)
                {
                    // If we past from maxOffset, then we break the counting and the while.
                    if (br.BaseStream.Position >= maxOffset)
                        break;

                    if(br.ReadByte() == (byte)'\0')
                        totalLines += 1;
                }
                br.Close();
            }
            etqCurrentLine.Text = currentLinePrefix+ "0/" +totalLines;
        }

        public void ReadNMSFile(string file)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                // Seek to our required position.
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                int chara;
                while ((chara = br.ReadByte()) != (byte)'\0')
                {
                    //Updates the prevOffset for the line by saving the current offset, then updates the current offset + 1
                    prevOffset = offset;
                    offset = (int)br.BaseStream.Position;
                    readBytes.Add((byte)chara);
                }
                br.Close();
            }

            original = bytesToString(readBytes.ToArray());

            //Updates the texts on the translation's boxes
            updateOriginalStringText(original);
            updateTranslatesStringText(original);
        }


        //Convert a byte array to its equivalent in string.
        private string bytesToString(byte[] bytes) {
            string response = string.Empty;

            foreach (byte b in bytes)
                response += (Char)b;

            return response;
        }

        private void updateOriginalStringText(string text) { originalText.Text = text; }

        private void updateTranslatesStringText(string text) { translatedText.Text = text; }


        private void comboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboTemplate.Text)
            {
                case "sysmsg.nms":
                    offset = 4310; //4310 was the exact value for bytes omited
                    maxOffset = 50561;
                    minOffset = offset;
                    required = 46251;
                    template = 6;
                    pctPreviewImg.Image = Properties.Resources.sysmsg;
                    break;
                case "scename_US.nms":
                    offset = 205;
                    required = -1;
                    template = 4;
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                case "scemsg.nms":
                    offset = 8836;
                    maxOffset = 271911;
                    minOffset = offset;
                    required = 263075;
                    template = 3;
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                case "_itemdata.nms":
                    offset = 7137;
                    required = -1;
                    template = 1;
                    break;
                case "lyricmsg.nms":
                    offset = 77;
                    required = -1;
                    template = 2;
                    break;
                case "staffroll.nms":
                    offset = -1;
                    required = -1;
                    template = 5;
                    break;
            }
        }

        private void BtnCloseFile_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                DialogResult choice = MessageBox.Show("Se perderán todos los cambios no guardados ¿Quiere cerrar",
                    "Advertencia de pérdida de datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);
                if (choice == DialogResult.OK)
                {
                    ClearVariables();
                    EnableDisableFields();
                }
                    
            }
            else
                ClearVariables();
        }

        private void irALíneaCtrlLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Line search = new Line();
            search.Show();
        }

        void HotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.L)
            {
                //Muestra la ventana de mostrar línea.
                Line search = new Line();
                search.Show();
                e.SuppressKeyPress = true;
            }

            else if(e.Control && e.KeyCode == Keys.O)
            {
                openNMSFile();
                e.SuppressKeyPress = true;
            }

            else if(e.Control && e.KeyCode == Keys.Z)
            {
                if(undoList.Count > 0)
                    translatedText.Text = undoList.Pop();
                e.SuppressKeyPress = true;
            }
            
            else if(e.Control && e.KeyCode == Keys.Y)
            {
                // Redo code: https://stackoverflow.com/questions/15772602/how-to-undo-and-redo-in-c-sharp-rich-text-box
                e.SuppressKeyPress = true;
            }

            e.SuppressKeyPress = false;

            
        }

        public void UpdateFilePath()
        {
            etqCurrentFile.Text = "Archivo actual: " + Path.GetFileName(openFileDialog.FileName);
        }

        private void ClearVariables()
        {
            change = false;
            isOpen = false;
            comboTemplate.ResetText();
            chkPreviewImage.Checked = true;
            txtSaveToFile.ResetText();
            translatedText.ResetText();
            originalText.ResetText();
            etqSysMsg.Visible = false;
            etqPreviewDialog.Visible = false;
            currentLine = 0;
            totalLines = 0;
            readBytes = new List<byte>();
            original = String.Empty;
            originalText.Text = String.Empty;
            translatedText.Text = String.Empty;
            etqCurrentFile.Text = "Archivo actual: (Ninguno)";
            etqCurrentLine.Text = "Línea actual: 0/0";
            pctPreviewImg.Image = Properties.Resources.no_file;
        }

        private void openNMSFile() {

            ClearVariables();

            openFileDialog.Title = "Seleccionar archivo de Textos de Muramasa Rebirth";
            openFileDialog.Filter = "Archivo NMS|*.nms";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isOpen = true;
                change = true;
                UpdateFilePath();
                EnableDisableFields();
                UpdateCurrentLine();
                inputPath = openFileDialog.FileName;
                updateImageOnOpenFile(openFileDialog.SafeFileName);
                countLinesOnFile(inputPath);
                ReadNMSFile(inputPath);
            }
        }

        private void updateImageOnOpenFile(string filename) {
            switch (filename) {
                case "scemsg.nms":
                    etqPreviewDialog.Visible = true;
                    comboTemplate.SelectedIndex = comboTemplate.FindStringExact("scemsg.nms");
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                case "sysmsg.nms":
                    etqSysMsg.Visible = true;
                    comboTemplate.SelectedIndex = comboTemplate.FindStringExact("sysmsg.nms");
                    pctPreviewImg.Image = Properties.Resources.sysmsg;
                    break;
                case "scename_US.nms":
                    etqPreviewDialog.Visible = true;
                    comboTemplate.SelectedIndex = comboTemplate.FindStringExact("scename_US.nms");
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                default:
                    pctPreviewImg.Image = Properties.Resources.no_template;
                    break;
            }
        }

        private void replaceAccents() {
            if (translatedText.Text.Contains("á") == true ||
                translatedText.Text.Contains("é") == true ||
                translatedText.Text.Contains("í") == true)
            {

                translatedText.Text = translatedText.Text.Replace('á', aacute);
                translatedText.Text = translatedText.Text.Replace('é', eacute);
                translatedText.Text = translatedText.Text.Replace('í', iacute);
            }
        }

        private void translatedText_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (checkAccents.Checked == true) {
                replaceAccents();
            }

            undoList.Push(translatedText.Text);

            switch (template)
            {
                case 1:
                    //ItemData label
                    break;
                case 2:
                    //LyricMsg label
                    break;
                case 3:
                    etqPreviewDialog.Text = translatedText.Text;
                    break;
                case 4:
                    //SceName_US label
                    etqPreviewDialog.Text = translatedText.Text;
                    break;
                case 5:
                    //StaffRoll label
                    break;
                case 6:
                    etqSysMsg.Text = translatedText.Text;
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            translatedText.Text = originalText.Text;
        }

        private void checkAccents_CheckedChanged(object sender, EventArgs e)
        {
            replaceAccents();
        }

        private void pegarCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Retrieves data

            IDataObject iData = Clipboard.GetDataObject();

            // Is Data Text?

            if (iData.GetDataPresent(DataFormats.Text))

                translatedText.Text = (String)iData.GetData(DataFormats.Text);
        }

        private void copiarCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(translatedText.SelectedText);
        }

        private void btnPreviousLine_Click(object sender, EventArgs e)
        {
            currentLine = (current > 0) ? --current : current;
            UpdateCurrentLine();
        }

        private void btnNextLine_Click(object sender, EventArgs e)
        {
            currentLine = (current < totalLines) ? ++current : current;
            UpdateCurrentLine();
        }

        private void cortarCrtlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(translatedText.SelectedText);
            translatedText.ResetText();
        }

        private void chkPreviewImage_CheckedChanged(object sender, EventArgs e)
        {
            control = !control;

            switch (template)
            {
                case 1:
                    //ItemData label
                    break;
                case 2:
                    //LyricMsg label
                    break;
                case 3:
                    etqSysMsg.Visible = !control;
                    etqPreviewDialog.Visible = control;
                    break;
                case 4:
                    //SceName_US label
                    break;
                case 5:
                    //StaffRoll label
                    break;
                case 6:
                    etqSysMsg.Visible = control;
                    etqPreviewDialog.Visible = !control;
                    break;
            }
        }

        private void BtnSaveToPath_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Seleccionar salida texto de Muramasa Rebirth";
            saveFileDialog.Filter = "Archivos NMS|*.nms";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = saveFileDialog.FileName.ToString();
                txtSaveToFile.Text = outputPath;
            }
        }

        private void EnableDisableFields()
        {
            this.txtSaveToFile.Enabled = change;
            this.originalText.Enabled = change;
            this.translatedText.Enabled = change;
            this.btnNextLine.Enabled = change;
            this.btnPreviousLine.Enabled = change;
            this.settingsGroup.Enabled = change;
            this.outputFile.Enabled = change;
            this.btnCloseFile.Enabled = change;
            this.chkPreviewImage.Enabled = change;
            this.btnSave.Enabled = change;
        }

        public void LineChanged()
        {
            etqCurrentLine.Text = "Línea actual:"+currentLine+ "/"+totalLines;
        }

    }
}
