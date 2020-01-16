using PrintMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitPrint
{
    public partial class TextPrintForm : Form
    {
        public TextPrintForm()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter= "Text files (*.txt)|*.txt";
            openDialog.ShowDialog();
            if (openDialog.FileName == "")
                return;
            textBox1.Text = File.ReadAllText(openDialog.FileName,Encoding.UTF8);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter= "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.ShowDialog();
            if (saveDialog.FileName == "")
                return;
            File.WriteAllText(saveDialog.FileName, textBox1.Text, Encoding.UTF8);
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            maskedTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = "";
            for(var i = 0; i < 10; i++)
            {
                if(maskedTextBox1.Text.Length<=i||maskedTextBox1.Text[i]==' ')
                {
                    id += '0';
                }
                else
                {
                    id += maskedTextBox1.Text[i];
                }
            }
            if (id == "0000000000" || id == "1111111111")
            {
                MessageBox.Show("Недопустимое значение идентификатора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var container = textBox1.Text;
            try
            {
                container = container.MarkByPrint(id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            textBox1.Text = container;
            if (MessageBox.Show("Цифровой отпечаток введен. Сохранить изменения?", "Успешно!", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var container = textBox1.Text;
            var id = "";
            try
            {
                id = container.GetPrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (id == "00000000" || id=="11111111")
            {
                MessageBox.Show("Цифровой отпечаток не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            maskedTextBox1.Text = id;
        }

        private void maskedTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
