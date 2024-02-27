using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr11
{
    public partial class Sudoku : Form
    {
        public Sudoku()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {

        }

        // Блокировка полей textBox от ввода после запуска формы
        private void Sudoku_Load(object sender, EventArgs e)
        {
            foreach (Control panelControl in this.Controls)
            {
                if (panelControl is Panel panel)
                {
                    foreach (Control textBoxControl in panel.Controls)
                    {
                        if (textBoxControl is TextBox textBox)
                        {
                            textBox.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}
