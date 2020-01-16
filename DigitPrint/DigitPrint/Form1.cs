using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == radioButton2.Checked)
            {
                MessageBox.Show("Выберите тип цифрового отпечатка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (radioButton1.Checked == true)
            {
                var textPrint = new TextPrintForm();
                textPrint.Show();
            }
            if (radioButton2.Checked == true)
            {
                var textPrint = new GraphPrintForm();
                textPrint.Show();
            }
        }
    }
}
