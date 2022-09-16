using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muramasa_Translator
{
    public partial class Line : Form
    {
        private int total, actual;

        public Line()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
        }

        
        private void txtJumpTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void Line_Load(object sender, EventArgs e)
        {
            actual = mainUI.currentLine;
            total = mainUI.totalLines;
            etqActualLine.Text = "Línea actual: " + actual + "/" + total;
            etqTotalLines.Text = "/" + total;
            txtJumpTo.SelectAll(); txtJumpTo.Focus();
        }

        // Método para leer si se presionó ESC y cerrar la ventana si así es.
        // Requiere KeyPreview = true; y crear en el Designer 
        // this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Escape_KeyDown);
        void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                int number = Int32.Parse(txtJumpTo.Text.ToString());    //Se obtiene el numero digitado.

                if (number > total)
                    mainUI.currentLine = total;
                else
                    mainUI.currentLine = number;


                this.Close();
            }
        }
    }
}
