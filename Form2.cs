using System;
using System.Windows.Forms;

namespace Trans
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             Form ifrm = new Form3();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем Form2
            this.Close(); // скрываем Form1 (this - текущая форма)
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text);
                Program.SborPost(Convert.ToString(textBox1.Text.ToString()), Convert.ToString(textBox2.Text.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Попробуйте ещё раз!\nПерезапустите программу!\nНе все ошибки обработаны!", "Ошибка!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Close(); // скрываем Form1 (this - текущая форма)
        }
    }
}
