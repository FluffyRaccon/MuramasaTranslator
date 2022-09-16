namespace Muramasa_Translator
{
    partial class Line
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Line));
            this.etqActualLine = new System.Windows.Forms.Label();
            this.txtJumpTo = new System.Windows.Forms.TextBox();
            this.etqTotalLines = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // etqActualLine
            // 
            this.etqActualLine.AutoSize = true;
            this.etqActualLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqActualLine.Location = new System.Drawing.Point(39, 22);
            this.etqActualLine.Name = "etqActualLine";
            this.etqActualLine.Size = new System.Drawing.Size(182, 20);
            this.etqActualLine.TabIndex = 0;
            this.etqActualLine.Text = "Línea actual: ???/999";
            // 
            // txtJumpTo
            // 
            this.txtJumpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumpTo.Location = new System.Drawing.Point(50, 63);
            this.txtJumpTo.Name = "txtJumpTo";
            this.txtJumpTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtJumpTo.Size = new System.Drawing.Size(118, 22);
            this.txtJumpTo.TabIndex = 1;
            this.txtJumpTo.Text = "Ingrese un número";
            // 
            // etqTotalLines
            // 
            this.etqTotalLines.AutoSize = true;
            this.etqTotalLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqTotalLines.Location = new System.Drawing.Point(174, 65);
            this.etqTotalLines.Name = "etqTotalLines";
            this.etqTotalLines.Size = new System.Drawing.Size(44, 20);
            this.etqTotalLines.TabIndex = 2;
            this.etqTotalLines.Text = "/999";
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAccept.Location = new System.Drawing.Point(85, 106);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 36);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 154);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.etqTotalLines);
            this.Controls.Add(this.txtJumpTo);
            this.Controls.Add(this.etqActualLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Line";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saltar a línea específica";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Line_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Escape_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJumpTo_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label etqActualLine;
        private System.Windows.Forms.TextBox txtJumpTo;
        private System.Windows.Forms.Label etqTotalLines;
        private System.Windows.Forms.Button btnAccept;
    }
}