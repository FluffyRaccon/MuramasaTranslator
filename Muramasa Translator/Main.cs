using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Muramasa_Translator
{
    public partial class mainUI : Form
    {
        private bool isOpen  = false, 
                     change  = false,
                     isValid = false,
                     extFile = false,
                     control = true;

        //Replacement chars for the accents.
        private char aacute = '¬',
                     eacute = '}',
                     iacute = '{';
                     //oacute = 'ó',
                     //uacute = 'ú';

        private string currentLinePrefix = "Línea actual: ";
        private string currentStatusPrefix = "Estado: ";

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
        
        private string original;

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



        private void BtnSave_Click(object sender, EventArgs e){ SaveChanges(); }

        private void SaveChanges() {
            if (originalText.Text != null && translatedText.Text != null && outputPath != null)
            {
                extFile = true; offset = minOffset;
                ReplaceTextInFile(inputPath, outputPath, originalText.Text, translatedText.Text);
                ReadNMSFile(currentLine, extFile);
                UpdateStatusLabel("Guardado", Color.Green);
            }
            else
                MessageBox.Show("Antes de guardar, revise que los campos de texto no se encuentren vacíos (incluido el archivo de salida).");
        }

        /* In case of saving the file with changes performed... 
         *      1. Take the lenght from the translatedText RichTextBox.
         *      2. Open the file with prevOffset and read until the lenght from last step.
         *      3. Delete bytes on the selected range.
         *      4. Start writing as bytes the info from the translatedText RichTextBox
         *      5. Close the file
         *      
         *      Code from StackOverflow thanks to: Peter Duniho
         *      Find the answer here: https://stackoverflow.com/questions/28062565/how-can-i-replace-a-unicode-string-in-a-binary-file
         */
        void ReplaceTextInFile(string fileName, string outputFile, string oldText, string newText)
        {
            Encoding windows_default = Encoding.GetEncoding("ISO-8859-1");

            byte[] fileBytes = File.ReadAllBytes(fileName),
                oldBytes = windows_default.GetBytes(oldText),
                newBytes = windows_default.GetBytes(newText);

            int index = IndexOfBytes(fileBytes, oldBytes);

            if (index < 0)
            {
                // Text was not found
                MessageBox.Show("Texto ingresado: " + windows_default.GetString(oldBytes) + "\n\nNo se han hecho cambios al archivo"+ "\nCodificación actual del sistema: " + Encoding.Default, "Texto no encontrado");
                return;
            }

            byte[] newFileBytes =
                new byte[fileBytes.Length + newBytes.Length - oldBytes.Length];

            Buffer.BlockCopy(fileBytes, 0, newFileBytes, 0, index);
            Buffer.BlockCopy(newBytes, 0, newFileBytes, index, newBytes.Length);
            Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
                newFileBytes, index + newBytes.Length,
                fileBytes.Length - index - oldBytes.Length);

            File.WriteAllBytes(outputFile, newFileBytes);
        }

        int IndexOfBytes(byte[] searchBuffer, byte[] bytesToFind)
        {
            for (int i = 0; i < searchBuffer.Length - bytesToFind.Length; i++)
            {
                bool success = true;

                for (int j = 0; j < bytesToFind.Length; j++)
                {
                    if (searchBuffer[i + j] != bytesToFind[j])
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    return i;
                }
            }

            return -1;
        }
        //
        // END OF CODE from StackOverflow thanks to: Peter Duniho
        //

        private void AbrirArchivoToolStripMenuItem_Click(object sender, EventArgs e){ OpenNMSFile(); }

        public void UpdateCurrentLine() { etqCurrentLine.Text = currentLinePrefix + currentLine + "/" + totalLines; }

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
                        totalLines++;
                }
                br.Close();
            }
            etqCurrentLine.Text = currentLinePrefix+ "0/" +totalLines;
        }

        //Main method reading NMSB files, the others are just auxiliars.
        private void ReadNMSFile(string file)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                //Restarts currentLength to match 0.
                currentLength = 0;

                // Seek to our required position.
                br.BaseStream.Seek(offset, SeekOrigin.Begin);

                int chara;
                while ((chara = br.ReadByte()) != (byte)'\0' && !br.EOF())
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

            //Clear the byte list to prevent undesired merges
            readBytes.Clear();

            //For debug porpouses shows the current and previous offset.
            //MessageBox.Show("Current offset: " + offset + "\nPrevious offset:" + prevOffset + "\nLength: " + currentLength + "\nCurrent line: " + currentLine, "Actual file offsets", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Function to only get the offset for the line specified.
        private void ReadNMSFile(int line, bool extFile = false)
        {
            int current = 0;

            using (BinaryReader br = new BinaryReader(File.Open(inputPath, FileMode.Open)))
            {
                int ach; currentLength = 0;
                br.BaseStream.Seek(minOffset, SeekOrigin.Begin);
                while (true)
                {

                    // If we past from maxOffset, then we break the counting and the while.
                    if (br.EOF() || current == line)
                        break;

                    //Read the value from file and store the read byte.
                    ach = br.ReadByte();
                    currentLength += 1;

                    //Each NUL, CR or LF the totalLines will increment
                    if (ach == (byte)'\0')
                        current++;
                }
                prevOffset = offset;
                offset = (int)br.BaseStream.Position;
                br.Close();
            }

            currentLine = line;
            if (extFile)
                ReadNMSFile(outputPath);
            else
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
                        isValid = true;
                        //pctPreviewImg.Image = Properties.Resources.scemsg; //TODO: Add screenshot to be used on Item Data.
                        break;
                    case "scemsg.nms":
                        offset = 8836;
                        maxOffset = 271911;
                        //required = 263075;
                        template = 3;
                        isValid = true;
                        pctPreviewImg.Image = Properties.Resources.scemsg;
                        break;
                    case "scename_US.nms":
                        offset = 844;
                        maxOffset = 3308;
                        //required = 2464;
                        template = 4;
                        isValid = true;
                        pctPreviewImg.Image = Properties.Resources.scemsg;
                        break;
                    case "staffroll.nms":
                        offset = -1;
                        maxOffset = 67057;
                        template = 5;
                        isValid = true;
                        pctPreviewImg.Image = Properties.Resources.no_template;
                        break;
                    case "sysmsg.nms":
                        offset = 4310;
                        maxOffset = 50561;
                        //required = 46251;
                        template = 6;
                        isValid = true;
                        pctPreviewImg.Image = Properties.Resources.sysmsg;
                        break;
                    case "lyricmsg.nms":
                        offset = 176;
                        maxOffset = 453;
                        //required = 277;
                        template = 2;
                        isValid = true;
                        pctPreviewImg.Image = Properties.Resources.sysmsg;
                        break;
                    case "Otro archivo...":
                        offset = 0;
                        isValid = true;
                        maxOffset = 40;
                        pctPreviewImg.Image = Properties.Resources.no_template;
                        //TODO: ask for the offset, maxOffset and leave open the template for the custom file that should be treated as
                        break;
                    default:
                        break;
                }
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
                ReadNMSFile(currentLine, extFile);
                UpdateCurrentLine();
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                //Shortcut for Ctrl + S.
                SaveChanges();
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
                ResetFileVars();
                UpdateFilePath(openFileDialog.FileName);
                EnableOrDisableFields();
                updateImageOnOpenFile(openFileDialog.SafeFileName);
                CountLinesOnFile(inputPath);
                ReadNMSFile(inputPath);
                UpdateCurrentLine();
                if (!checkEscribirOtroArchivo.Checked)
                {
                    outputPath = inputPath;
                    txtSaveToFile.Text = outputPath;
                }
                etqEstatus.Text = currentStatusPrefix + "Arch. abierto";
                Properties.Settings.Default.last_file = inputPath;
                Properties.Settings.Default.Save();
            }
        }

        private void ResetFileVars()
        {
            offset = 0;
            minOffset = 0;
            totalLines = 0;
            currentLine = 0;
            isOpen = change = true;
            comboTemplate.SelectedIndex = -1;
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
                case "lyricmsg.nms":
                    etqSysMsg.Visible = true;
                    pctPreviewImg.Image = Properties.Resources.sysmsg;
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

        private void UpdateStatusLabel(string stat, Color color) {
            etqEstatus.Text = currentStatusPrefix + stat;
            etqEstatus.ForeColor = color;
        }

        private void TranslatedText_TextChanged(object sender, EventArgs e)
        {
            if (outputPath != null )
                btnSave.Enabled = true;

            undoList.Push(translatedText.Text);
            UpdateStatusLabel("Escribiendo", Color.Black);

            switch (template)
            {
                case 1:
                    //ItemData label
                    etqPreviewDialog.Text = translatedText.Text;
                    break;
                case 2:
                    //LyricMsg label
                    etqSysMsg.Text = translatedText.Text;
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (originalText.Text == translatedText.Text)
            {
                UpdateStatusLabel("Sin cambios", Color.Black);
            }
            else
                translatedText.Text = originalText.Text;
        }

        private void IrALíneaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isOpen && change)
            {
                Line search = new Line();
                search.ShowDialog();
                ReadNMSFile(currentLine, extFile);
                UpdateCurrentLine();
            }
        }

        private void CorregirAcentos_Click(object sender, EventArgs e)
        {
            replaceAccents();
        }

        private void EscribirOtroArchivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEscribirOtroArchivo.Checked)
            {
                outputPath = saveFileDialog.FileName.ToString();
                txtSaveToFile.Text = String.Empty;
                BtnSaveToPath.Focus();
            }
            else
            {
                outputPath = inputPath;
            }
            outputFile.Enabled = checkEscribirOtroArchivo.Checked;
        }

        private void mainUI_Load(object sender, EventArgs e)
        {
            currentLine = Properties.Settings.Default.current_line;
        }

        private void TxtSaveToFile_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void BtnPreviousLine_Click(object sender, EventArgs e)
        {
            //Prevents from decrementing the line counter
            if (currentLine > 0)
            {
                ReadNMSFile(--currentLine, extFile);
                UpdateCurrentLine();
            }
        }

        private void btnNextLine_Click(object sender, EventArgs e)
        {
            if (currentLine < totalLines)
            {
                ReadNMSFile(++currentLine, extFile);
                UpdateCurrentLine();
            }
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

            UpdateStatusLabel("Sel. Arch.", Color.Red);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = saveFileDialog.FileName.ToString();
                txtSaveToFile.Text = outputPath;
                txtSaveToFile.ReadOnly = true;
                UpdateStatusLabel("Arch. Selecc.", Color.Black);
            }
        }

        private void EnableOrDisableFields()
        {
            if (txtSaveToFile.Text != null)
            {
                btnSave.Enabled = change;
                txtSaveToFile.Enabled = change;
            }

            if(checkEscribirOtroArchivo.Checked)
                outputFile.Enabled = change;

            btnNextLine.Enabled = change;
            btnCloseFile.Enabled = change;
            originalText.Enabled = change;
            settingsGroup.Enabled = change;
            translatedText.Enabled = change;
            btnPreviousLine.Enabled = change;
            chkPreviewImage.Enabled = change;
            btnCopyOriginal.Enabled = change;
            btnCorregirAcentos.Enabled = change;
        }

        public void LineChanged()
        {
            etqCurrentLine.Text = "Línea actual:"+currentLine+ "/"+totalLines;
        }

    }

    /**
     * Added EOF function to BinaryReader Class thanks to: Un Peu
     * Found the answer on: https://stackoverflow.com/questions/10942848/c-sharp-checking-for-binary-reader-end-of-file
     */
    public static class StreamEOF
    {
        public static bool EOF(this BinaryReader binaryReader)
        {
            var bs = binaryReader.BaseStream;
            return (bs.Position == bs.Length);
        }
    }
}
