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
                     isValid = false,
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
        private int currentLength;

        //Sets the limits for reading the files
        private static int minOffset = 0;
        private static int maxOffset = 0;


        public int current  = 0,
                   prevInd  = 0,
                   template = 0;

        List<byte> readBytes = new List<byte>();
        
        private string original, translated;

        //Number for the specific-file offset and the required amount of bytes.
        private int offset = 0;
        //private int required = 0;

        //Control for the "lines" (more likely blocks)
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

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            byte[] prueba = Encoding.UTF8.GetBytes(translatedText.Text);
            if (isOpen && change && outputPath!=null)
            {
                using (var fs = new FileStream(outputPath, FileMode.Create))
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(0x42534D4E); // Writes the file header => "NMSB". This can be omited, the header is already known and written.
                    bw.Write('.');
                    bw.Write(prueba);
                    bw.Write('\0');
                    bw.Close();
                }
                //Perform save action merging the header file + data + footer
                MessageBox.Show("Datos guardados correctamente.", "Éxito");
            }
        }

        private void AbrirArchivoToolStripMenuItem_Click(object sender, EventArgs e){ OpenNMSFile(); }

        public void SetCurrentLine(int val) { currentLine = val; }

        public void UpdateCurrentLine() { etqCurrentLine.Text = currentLinePrefix + currentLine + "/" + totalLines; }

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

        private void AyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tutorial window = new Tutorial();
            window.Show();
        }

        private void CountLinesOnFile(string file) {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int ach;
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                while (true)
                {
                    
                    // If we past from maxOffset, then we break the counting and the while.
                    if (br.BaseStream.Position >= maxOffset)
                        break;

                    //Read the value from file.
                    ach = br.ReadByte();

                    //Each NUL, CR or LF the totalLines will increment
                    if ( ach == (byte)'\0')
                        totalLines += 1;
                }
                br.Close();
            }
            etqCurrentLine.Text = currentLinePrefix+ "0/" +totalLines;
        }

        //Main method reading NMSB files, the others are just auxiliars.
        private void ReadNMSFile(string file, bool reverse = false)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                //Restarts currentLength to match 0.
                currentLength = 0;

                // Seek to our required position.
                if(reverse == true)
                    br.BaseStream.Seek(prevOffset, SeekOrigin.Begin);
                else
                    br.BaseStream.Seek(offset, SeekOrigin.Begin);

                int chara;
                while ((chara = br.ReadByte()) != (byte)'\0')
                {
                    //Read the value from file and store the read byte.
                    readBytes.Add((byte)chara);

                    //We need to save an state of how much length was seeked until next null byte.
                    currentLength += 1;

                }

                //Updates the prevOffset for the line by saving the current offset, then updates the current offset.
                offset = (int)br.BaseStream.Position;

                //Close the stream from file
                br.Close();
            }

            original = BytesToString(readBytes.ToArray());

            //Updates the texts on the translation's boxes
            UpdateOriginalStringText(original);
            UpdateTranslatesStringText(original);

            //Updates the current line in order to know in what block we are
            if (currentLine == 0)
                currentLine = 1;

            /* In case of saving the file with changes performed... 
             *      1. Take the lenght from the translatedText RichTextBox.
             *      2. Open the file with prevOffset and read until the lenght from last step.
             *      3. Delete bytes on the selected range.
             *      4. Start writing as bytes the info from the translatedText RichTextBox
             *      5. Close the file
             */

            //Clear the byte list to prevent undesired merges
            readBytes.Clear();

            //For debug porpouses shows the current and previous offset.
            //MessageBox.Show("Current offset: " + offset + "\nPrevious offset:" + prevOffset + "\nLength: " + currentLength + "\nCurrent line: " + currentLine, "Actual file offsets", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Function to only get the offset for the line specified.
        private void ReadNMSFile(int line)
        {
            int current = 0;

            using (BinaryReader br = new BinaryReader(File.Open(inputPath, FileMode.Open)))
            {
                int ach; currentLength = 0;
                br.BaseStream.Seek(minOffset, SeekOrigin.Begin);
                while (true)
                {

                    // If we past from maxOffset, then we break the counting and the while.
                    if (br.BaseStream.Position >= maxOffset || current == line)
                        break;

                    //Read the value from file and store the read byte.
                    ach = br.ReadByte();
                    currentLength += 1;

                    //Each NUL, CR or LF the totalLines will increment
                    if (ach == (byte)'\0')
                        current += 1;
                }
                prevOffset = offset;
                offset = (int)br.BaseStream.Position;
                br.Close();
            }

            currentLine = line;
            ReadNMSFile(inputPath);

        }

        //Convert a byte array to its equivalent in string.
        private string BytesToString(byte[] bytes) {
            string response = string.Empty;

            foreach (byte b in bytes)
                response += (Char)b;

            return response;
        }

        private void UpdateOriginalStringText(string text) { originalText.Text = text; }

        private void UpdateTranslatesStringText(string text) { translatedText.Text = text; }


        private void ComboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isOpen && isValid)
            {
                MessageBox.Show("Ya tiene un archivo identificado. Presione NO para ignorar el cambio de plantilla.", "Advertencia de posible error de lectura de archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                comboTemplate.ResetText();
                isValid = (DialogResult == DialogResult.Yes) ? false : true;
            }
            else {
                switch (comboTemplate.Text)
                {
                    case "_itemdata.nms":
                        offset = 14301;
                        maxOffset = 67057;
                        //required = 52653;
                        template = 1;
                        //pctPreviewImg.Image = Properties.Resources.scemsg; //TODO: Add screenshot to be used on Item Data.
                        break;
                    case "scemsg.nms":
                        offset = 8836;
                        maxOffset = 271911;
                        //required = 263075;
                        template = 3;
                        pctPreviewImg.Image = Properties.Resources.scemsg;
                        break;
                    case "scename_US.nms":
                        offset = 844;
                        maxOffset = 3308;
                        //required = 2464;
                        template = 4;
                        pctPreviewImg.Image = Properties.Resources.scemsg;
                        break;
                    case "staffroll.nms":
                        offset = -1;
                        maxOffset = 67057;
                        template = 5;
                        break;
                    case "sysmsg.nms":
                        offset = 4310;
                        maxOffset = 50561;
                        //required = 46251;
                        template = 6;
                        pctPreviewImg.Image = Properties.Resources.sysmsg;
                        break;
                    case "lyricmsg.nms":
                        offset = 1892;
                        maxOffset = 47744;
                        //required = 45852;
                        template = 2;
                        break;
                    case "Otro archivo...":
                        offset = 0;
                        maxOffset = 40;
                        pctPreviewImg.Image = Properties.Resources.no_template;
                        //TODO: ask for the offset, maxOffset and leave open the template for the custom file that should be treated as
                        break;
                }
                isValid = true;
                minOffset = offset;
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
                    EnableOrDisableFields();
                }
                    
            }
            else
                ClearVariables();
        }

        void HotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.L)
            {
                //Muestra la ventana de mostrar línea.
                Line search = new Line();
                search.ShowDialog();
                ReadNMSFile(currentLine);
                UpdateCurrentLine();
                e.SuppressKeyPress = true;
            }

            else if(e.Control && e.KeyCode == Keys.O)
            {
                OpenNMSFile();
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

        public void UpdateFilePath(string path)
        {
            inputPath = path;
            etqCurrentFile.Text = "Archivo actual: " + Path.GetFileName(inputPath);
        }

        private void ClearVariables()
        {
            change = isOpen = isValid = false;
            comboTemplate.ResetText();
            chkPreviewImage.Checked = true;
            txtSaveToFile.ResetText();
            translatedText.ResetText();
            originalText.ResetText();
            etqSysMsg.Visible = false;
            etqPreviewDialog.Visible = false;
            currentLine = 0;
            totalLines = 0;
            readBytes.Clear();
            original = String.Empty;
            originalText.Text = String.Empty;
            translatedText.Text = String.Empty;
            etqCurrentFile.Text = "Archivo actual: (Ninguno)";
            etqCurrentLine.Text = "Línea actual: 0/0";
            pctPreviewImg.Image = Properties.Resources.no_file;
        }

        private void OpenNMSFile() {

            ClearVariables();

            openFileDialog.Title = "Seleccionar archivo de Textos de Muramasa Rebirth";
            openFileDialog.Filter = "Archivo NMS|*.nms";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isOpen = change = true;
                UpdateFilePath(openFileDialog.FileName);
                EnableOrDisableFields();
                updateImageOnOpenFile(openFileDialog.SafeFileName);
                CountLinesOnFile(inputPath);
                ReadNMSFile(inputPath);
                UpdateCurrentLine();
            }
        }

        private void updateImageOnOpenFile(string filename) {
            switch (filename) {
                case "scemsg.nms":
                    etqPreviewDialog.Visible = true;
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                case "sysmsg.nms":
                    etqSysMsg.Visible = true;
                    pctPreviewImg.Image = Properties.Resources.sysmsg;
                    break;
                case "scename_US.nms":
                    etqPreviewDialog.Visible = true;
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                case "_itemdata.nms":
                    etqPreviewDialog.Visible = true;
                    pctPreviewImg.Image = Properties.Resources.scemsg;
                    break;
                default:
                    pctPreviewImg.Image = Properties.Resources.no_template;
                    break;
            }
            comboTemplate.SelectedIndex = comboTemplate.FindStringExact(filename);
            prevInd = comboTemplate.SelectedIndex;
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
            if (outputPath != null )
                btnSave.Enabled = true;
            if (checkAccents.Checked == true) {
                replaceAccents();
            }

            undoList.Push(translatedText.Text);

            switch (template)
            {
                case 1:
                    //ItemData label
                    etqPreviewDialog.Text = translatedText.Text;
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

        private void irALíneaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isOpen && change)
            {
                Line search = new Line();
                search.ShowDialog();
                ReadNMSFile(currentLine);
                UpdateCurrentLine();
            }
        }

        private void TxtSaveToFile_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void checkAccents_CheckedChanged(object sender, EventArgs e)
        {
            replaceAccents();
        }

        private void copiarCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(translatedText.SelectedText);
        }

        private void btnPreviousLine_Click(object sender, EventArgs e)
        {
            //Prevents from decrementing the line counter
            if (currentLine > 1 && currentLine <= totalLines)
            {
                --currentLine;
                ReadNMSFile(currentLine);
                UpdateCurrentLine();
            }
        }

        private void btnNextLine_Click(object sender, EventArgs e)
        {
            //currentLine = (current < totalLines) ? ++current : current;
            if (currentLine < totalLines)
            {
                currentLine++;
                ReadNMSFile(inputPath);
                UpdateCurrentLine();
            }
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
                    etqSysMsg.Visible = !control;
                    etqPreviewDialog.Visible = control;
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
            saveFileDialog.Title = "Guardar texto de Muramasa Rebirth";
            saveFileDialog.Filter = "Archivo NMS|*.nms";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = saveFileDialog.FileName.ToString();
                txtSaveToFile.Text = outputPath;
                txtSaveToFile.ReadOnly = true;
            }
        }

        private void EnableOrDisableFields()
        {
            if (txtSaveToFile.Text != null)
            {
                this.btnSave.Enabled = change;
                this.txtSaveToFile.Enabled = change;
            }
            this.originalText.Enabled = change;
            this.translatedText.Enabled = change;
            this.btnNextLine.Enabled = change;
            this.btnPreviousLine.Enabled = change;
            this.settingsGroup.Enabled = change;
            this.outputFile.Enabled = change;
            this.btnCloseFile.Enabled = change;
            this.chkPreviewImage.Enabled = change;
            this.btnCopyOriginal.Enabled = change;
        }

        public void LineChanged()
        {
            etqCurrentLine.Text = "Línea actual:"+currentLine+ "/"+totalLines;
        }

    }
}
