using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pr12
{
    public partial class SudokuHelper : Form
    {
        public SudokuHelper()
        {
            InitializeComponent();

            // Назначаем событие TextChanged для всех TextBox внутри Panel на форме
            foreach (Control panel in this.Controls)
            {
                if (panel is Panel panelControl)
                {
                    foreach (Control control in panelControl.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            textBox.TextChanged += textBox_TextChanged;
                        }
                    }
                }
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Проверяем, что введенная строка не пустая и содержит только одну цифру, большую  0
                if (!string.IsNullOrEmpty(textBox.Text) && int.TryParse(textBox.Text, out int number) && number > 0 && textBox.Text.Length == 1)
                {
                    // Если условие выполняется, ничего не делаем
                }
                else
                {
                    // Если условие не выполняется, очищаем TextBox
                    textBox.Text = string.Empty;
                }
            }
        }

        private void SudokuHelper_Load(object sender, EventArgs e)
        {

        }

        private void ConditionEntered(object sender, EventArgs e)
        {
            // Блокировка всех TextBox, в которые введены значения
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                foreach (TextBox textBox in panel.Controls.OfType<TextBox>())
                {
                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.ReadOnly = true;
                    }
                }
            }
        }
        private void CheckTextBoxes()
        {
            // Проверяем каждый Panel на форме
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                HashSet<string> values = new HashSet<string>();
                bool allFilled = true;

                // Проверяем каждый TextBox внутри текущего Panel
                foreach (TextBox textBox in panel.Controls.OfType<TextBox>())
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        allFilled = false;
                    }
                    else
                    {
                        if (!values.Add(textBox.Text))
                        {
                            // Если значение повторяется, делаем TextBox красным
                            textBox.BackColor = Color.Red;
                        }
                    }
                }

                // Если все TextBox заполнены и нет повторяющихся значений, делаем их зелёными
                if (allFilled && values.Count == 9)
                {
                    // Если все TextBox заполнены и нет повторяющихся значений, делаем их зелёными
                    foreach (TextBox textBox in panel.Controls.OfType<TextBox>())
                    {
                        textBox.BackColor = Color.Green;
                    }
                }
            }
        }

        private void Check(object sender, EventArgs e)
        {
            // Проверка правильности заполнения и цветов TextBox
            CheckTextBoxes();
        }
    }
}