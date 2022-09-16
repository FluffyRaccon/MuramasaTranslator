namespace Muramasa_Translator
{
    partial class mainUI
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainUI));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.settingsGroup = new System.Windows.Forms.GroupBox();
            this.checkAccents = new System.Windows.Forms.CheckBox();
            this.templateLabel = new System.Windows.Forms.Label();
            this.comboTemplate = new System.Windows.Forms.ComboBox();
            this.originalText = new System.Windows.Forms.RichTextBox();
            this.translatedText = new System.Windows.Forms.RichTextBox();
            this.originalTextLabel = new System.Windows.Forms.Label();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.lblPreviewWarning = new System.Windows.Forms.Label();
            this.etqSysMsg = new System.Windows.Forms.Label();
            this.etqPreviewDialog = new System.Windows.Forms.Label();
            this.pctPreviewImg = new System.Windows.Forms.PictureBox();
            this.etqCurrentLine = new System.Windows.Forms.Label();
            this.etqCurrentFile = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.translationLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnPreviousLine = new System.Windows.Forms.Button();
            this.btnNextLine = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.outputFile = new System.Windows.Forms.GroupBox();
            this.lblWarningSaving = new System.Windows.Forms.Label();
            this.BtnSaveToPath = new System.Windows.Forms.Button();
            this.txtSaveToFile = new System.Windows.Forms.TextBox();
            this.btnCloseFile = new System.Windows.Forms.Button();
            this.chkPreviewImage = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.settingsGroup.SuspendLayout();
            this.previewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreviewImg)).BeginInit();
            this.outputFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(796, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArchivoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir archivo      Ctrl + O";
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // settingsGroup
            // 
            this.settingsGroup.Controls.Add(this.checkAccents);
            this.settingsGroup.Controls.Add(this.templateLabel);
            this.settingsGroup.Controls.Add(this.comboTemplate);
            this.settingsGroup.Enabled = false;
            this.settingsGroup.Location = new System.Drawing.Point(12, 41);
            this.settingsGroup.Name = "settingsGroup";
            this.settingsGroup.Size = new System.Drawing.Size(229, 96);
            this.settingsGroup.TabIndex = 1;
            this.settingsGroup.TabStop = false;
            this.settingsGroup.Text = "Configuración";
            // 
            // checkAccents
            // 
            this.checkAccents.AutoSize = true;
            this.checkAccents.Location = new System.Drawing.Point(9, 57);
            this.checkAccents.Name = "checkAccents";
            this.checkAccents.Size = new System.Drawing.Size(219, 17);
            this.checkAccents.TabIndex = 2;
            this.checkAccents.Text = "Corregir automáticamente la acentuación";
            this.toolTips.SetToolTip(this.checkAccents, "Se recomienda activar al final de escribir");
            this.checkAccents.UseVisualStyleBackColor = true;
            this.checkAccents.CheckedChanged += new System.EventHandler(this.checkAccents_CheckedChanged);
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Location = new System.Drawing.Point(6, 22);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(46, 13);
            this.templateLabel.TabIndex = 1;
            this.templateLabel.Text = "Plantilla:";
            // 
            // comboTemplate
            // 
            this.comboTemplate.FormattingEnabled = true;
            this.comboTemplate.Items.AddRange(new object[] {
            "_itemdata.nms",
            "scemsg.nms",
            "scename_US.nms",
            "staffroll.nms",
            "sysmsg.nms"});
            this.comboTemplate.Location = new System.Drawing.Point(58, 19);
            this.comboTemplate.Name = "comboTemplate";
            this.comboTemplate.Size = new System.Drawing.Size(135, 21);
            this.comboTemplate.TabIndex = 0;
            this.comboTemplate.SelectedIndexChanged += new System.EventHandler(this.comboTemplate_SelectedIndexChanged);
            // 
            // originalText
            // 
            this.originalText.DetectUrls = false;
            this.originalText.Enabled = false;
            this.originalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalText.Location = new System.Drawing.Point(256, 60);
            this.originalText.MaxLength = 2000;
            this.originalText.Name = "originalText";
            this.originalText.ReadOnly = true;
            this.originalText.Size = new System.Drawing.Size(245, 98);
            this.originalText.TabIndex = 2;
            this.originalText.Text = "";
            // 
            // translatedText
            // 
            this.translatedText.Enabled = false;
            this.translatedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translatedText.Location = new System.Drawing.Point(507, 60);
            this.translatedText.MaxLength = 300;
            this.translatedText.Name = "translatedText";
            this.translatedText.Size = new System.Drawing.Size(245, 98);
            this.translatedText.TabIndex = 3;
            this.translatedText.Text = "";
            this.translatedText.TextChanged += new System.EventHandler(this.translatedText_TextChanged);
            // 
            // originalTextLabel
            // 
            this.originalTextLabel.AutoSize = true;
            this.originalTextLabel.Location = new System.Drawing.Point(253, 41);
            this.originalTextLabel.Name = "originalTextLabel";
            this.originalTextLabel.Size = new System.Drawing.Size(75, 13);
            this.originalTextLabel.TabIndex = 4;
            this.originalTextLabel.Text = "Texto Original:";
            // 
            // previewGroup
            // 
            this.previewGroup.Controls.Add(this.lblPreviewWarning);
            this.previewGroup.Controls.Add(this.etqSysMsg);
            this.previewGroup.Controls.Add(this.etqPreviewDialog);
            this.previewGroup.Controls.Add(this.pctPreviewImg);
            this.previewGroup.Controls.Add(this.etqCurrentLine);
            this.previewGroup.Controls.Add(this.etqCurrentFile);
            this.previewGroup.Location = new System.Drawing.Point(256, 175);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Size = new System.Drawing.Size(530, 188);
            this.previewGroup.TabIndex = 7;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Vista previa del texto";
            // 
            // lblPreviewWarning
            // 
            this.lblPreviewWarning.AutoSize = true;
            this.lblPreviewWarning.Location = new System.Drawing.Point(428, 20);
            this.lblPreviewWarning.Name = "lblPreviewWarning";
            this.lblPreviewWarning.Size = new System.Drawing.Size(95, 130);
            this.lblPreviewWarning.TabIndex = 15;
            this.lblPreviewWarning.Text = "Nota: es posible\r\nque los textos no\r\nse vean idénticos\r\na la vista previa.\r\n\r\nEl " +
    "mayor problema\r\nde este programa\r\nes previsualizar los\r\ntextos con más de\r\n3 lin" +
    "eas de altura.";
            // 
            // etqSysMsg
            // 
            this.etqSysMsg.AutoSize = true;
            this.etqSysMsg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.etqSysMsg.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqSysMsg.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.etqSysMsg.Location = new System.Drawing.Point(37, 59);
            this.etqSysMsg.Name = "etqSysMsg";
            this.etqSysMsg.Size = new System.Drawing.Size(235, 30);
            this.etqSysMsg.TabIndex = 14;
            this.etqSysMsg.Text = "Mensaje de Sistema:\r\nTexto de ejemplo, cambia automáticamente.";
            // 
            // etqPreviewDialog
            // 
            this.etqPreviewDialog.AutoSize = true;
            this.etqPreviewDialog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.etqPreviewDialog.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqPreviewDialog.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.etqPreviewDialog.Location = new System.Drawing.Point(37, 97);
            this.etqPreviewDialog.Name = "etqPreviewDialog";
            this.etqPreviewDialog.Size = new System.Drawing.Size(114, 17);
            this.etqPreviewDialog.TabIndex = 13;
            this.etqPreviewDialog.Text = "Texto de Ejemplo";
            // 
            // pctPreviewImg
            // 
            this.pctPreviewImg.Image = global::Muramasa_Translator.Properties.Resources.no_file;
            this.pctPreviewImg.Location = new System.Drawing.Point(18, 19);
            this.pctPreviewImg.Name = "pctPreviewImg";
            this.pctPreviewImg.Size = new System.Drawing.Size(403, 138);
            this.pctPreviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctPreviewImg.TabIndex = 12;
            this.pctPreviewImg.TabStop = false;
            // 
            // etqCurrentLine
            // 
            this.etqCurrentLine.AutoSize = true;
            this.etqCurrentLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.etqCurrentLine.Location = new System.Drawing.Point(307, 166);
            this.etqCurrentLine.Name = "etqCurrentLine";
            this.etqCurrentLine.Size = new System.Drawing.Size(114, 15);
            this.etqCurrentLine.TabIndex = 11;
            this.etqCurrentLine.Text = "Línea actual: 0/0";
            // 
            // etqCurrentFile
            // 
            this.etqCurrentFile.AutoSize = true;
            this.etqCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqCurrentFile.Location = new System.Drawing.Point(15, 168);
            this.etqCurrentFile.Name = "etqCurrentFile";
            this.etqCurrentFile.Size = new System.Drawing.Size(152, 13);
            this.etqCurrentFile.TabIndex = 10;
            this.etqCurrentFile.Text = "Archivo actual: (Ninguno)";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(12, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(228, 70);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Guardar Traducción";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // translationLabel
            // 
            this.translationLabel.AutoSize = true;
            this.translationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.translationLabel.Location = new System.Drawing.Point(504, 41);
            this.translationLabel.Name = "translationLabel";
            this.translationLabel.Size = new System.Drawing.Size(64, 13);
            this.translationLabel.TabIndex = 9;
            this.translationLabel.Text = "Traducción:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "sysmsg.nms";
            // 
            // btnPreviousLine
            // 
            this.btnPreviousLine.Enabled = false;
            this.btnPreviousLine.Location = new System.Drawing.Point(758, 60);
            this.btnPreviousLine.Name = "btnPreviousLine";
            this.btnPreviousLine.Size = new System.Drawing.Size(28, 24);
            this.btnPreviousLine.TabIndex = 11;
            this.btnPreviousLine.Text = "▲";
            this.toolTips.SetToolTip(this.btnPreviousLine, "Linea anterior del archivo");
            this.btnPreviousLine.UseVisualStyleBackColor = true;
            this.btnPreviousLine.Click += new System.EventHandler(this.btnPreviousLine_Click);
            // 
            // btnNextLine
            // 
            this.btnNextLine.Enabled = false;
            this.btnNextLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNextLine.Location = new System.Drawing.Point(758, 98);
            this.btnNextLine.Name = "btnNextLine";
            this.btnNextLine.Size = new System.Drawing.Size(28, 24);
            this.btnNextLine.TabIndex = 12;
            this.btnNextLine.Text = "▼";
            this.toolTips.SetToolTip(this.btnNextLine, "Linea siguiente en archivo");
            this.btnNextLine.UseVisualStyleBackColor = true;
            this.btnNextLine.Click += new System.EventHandler(this.btnNextLine_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSave.Location = new System.Drawing.Point(758, 134);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(28, 24);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "A";
            this.toolTips.SetToolTip(this.buttonSave, "Copiar original a traducción");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // outputFile
            // 
            this.outputFile.Controls.Add(this.lblWarningSaving);
            this.outputFile.Controls.Add(this.BtnSaveToPath);
            this.outputFile.Controls.Add(this.txtSaveToFile);
            this.outputFile.Enabled = false;
            this.outputFile.Location = new System.Drawing.Point(12, 144);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(229, 100);
            this.outputFile.TabIndex = 14;
            this.outputFile.TabStop = false;
            this.outputFile.Text = "Archivo de Salida";
            // 
            // lblWarningSaving
            // 
            this.lblWarningSaving.AutoSize = true;
            this.lblWarningSaving.Location = new System.Drawing.Point(6, 49);
            this.lblWarningSaving.Name = "lblWarningSaving";
            this.lblWarningSaving.Size = new System.Drawing.Size(222, 39);
            this.lblWarningSaving.TabIndex = 2;
            this.lblWarningSaving.Text = "Por favor al momento de guardar los cambios\r\nselecciona un nombre de archivo dife" +
    "rente al \r\narchivo que abriste.";
            // 
            // BtnSaveToPath
            // 
            this.BtnSaveToPath.Location = new System.Drawing.Point(168, 19);
            this.BtnSaveToPath.Name = "BtnSaveToPath";
            this.BtnSaveToPath.Size = new System.Drawing.Size(51, 20);
            this.BtnSaveToPath.TabIndex = 1;
            this.BtnSaveToPath.Text = "Abrir...";
            this.BtnSaveToPath.UseVisualStyleBackColor = true;
            this.BtnSaveToPath.Click += new System.EventHandler(this.BtnSaveToPath_Click);
            // 
            // txtSaveToFile
            // 
            this.txtSaveToFile.Location = new System.Drawing.Point(9, 19);
            this.txtSaveToFile.Name = "txtSaveToFile";
            this.txtSaveToFile.Size = new System.Drawing.Size(153, 20);
            this.txtSaveToFile.TabIndex = 0;
            // 
            // btnCloseFile
            // 
            this.btnCloseFile.Enabled = false;
            this.btnCloseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCloseFile.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCloseFile.Location = new System.Drawing.Point(12, 250);
            this.btnCloseFile.Name = "btnCloseFile";
            this.btnCloseFile.Size = new System.Drawing.Size(131, 36);
            this.btnCloseFile.TabIndex = 15;
            this.btnCloseFile.Text = "Cerrar archivo";
            this.btnCloseFile.UseVisualStyleBackColor = true;
            this.btnCloseFile.Click += new System.EventHandler(this.BtnCloseFile_Click);
            // 
            // chkPreviewImage
            // 
            this.chkPreviewImage.AutoSize = true;
            this.chkPreviewImage.Checked = true;
            this.chkPreviewImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreviewImage.Enabled = false;
            this.chkPreviewImage.Location = new System.Drawing.Point(149, 256);
            this.chkPreviewImage.Name = "chkPreviewImage";
            this.chkPreviewImage.Size = new System.Drawing.Size(99, 30);
            this.chkPreviewImage.TabIndex = 16;
            this.chkPreviewImage.Text = "Mostrar vista\r\nprevia de texto.";
            this.chkPreviewImage.UseVisualStyleBackColor = true;
            this.chkPreviewImage.CheckedChanged += new System.EventHandler(this.chkPreviewImage_CheckedChanged);
            // 
            // mainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 375);
            this.Controls.Add(this.chkPreviewImage);
            this.Controls.Add(this.btnCloseFile);
            this.Controls.Add(this.outputFile);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.btnNextLine);
            this.Controls.Add(this.btnPreviousLine);
            this.Controls.Add(this.translationLabel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.previewGroup);
            this.Controls.Add(this.originalTextLabel);
            this.Controls.Add(this.translatedText);
            this.Controls.Add(this.originalText);
            this.Controls.Add(this.settingsGroup);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "mainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muramasa Translator [PS Vita]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKey_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.settingsGroup.ResumeLayout(false);
            this.settingsGroup.PerformLayout();
            this.previewGroup.ResumeLayout(false);
            this.previewGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreviewImg)).EndInit();
            this.outputFile.ResumeLayout(false);
            this.outputFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.GroupBox settingsGroup;
        private System.Windows.Forms.Label templateLabel;
        private System.Windows.Forms.ComboBox comboTemplate;
        private System.Windows.Forms.CheckBox checkAccents;
        private System.Windows.Forms.RichTextBox originalText;
        private System.Windows.Forms.RichTextBox translatedText;
        private System.Windows.Forms.Label originalTextLabel;
        private System.Windows.Forms.GroupBox previewGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label translationLabel;
        private System.Windows.Forms.Label etqCurrentFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnPreviousLine;
        private System.Windows.Forms.Button btnNextLine;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.GroupBox outputFile;
        private System.Windows.Forms.Button BtnSaveToPath;
        private System.Windows.Forms.TextBox txtSaveToFile;
        private System.Windows.Forms.Button btnCloseFile;
        private System.Windows.Forms.CheckBox chkPreviewImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label etqCurrentLine;
        private System.Windows.Forms.PictureBox pctPreviewImg;
        private System.Windows.Forms.Label etqPreviewDialog;
        private System.Windows.Forms.Label etqSysMsg;
        private System.Windows.Forms.Label lblWarningSaving;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label lblPreviewWarning;
    }
}

