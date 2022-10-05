using System;
using System.Windows.Forms;

namespace Trans
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            fun();
        }
        string[] a = new string[Obrab.naznName.Count * Obrab.naznZnach.Count];
        public void fun()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("0", "Поставщики");

              
                for (int i = 0; i < Obrab.naznName.Count; i++) // вывод колонок
                {
                    dataGridView1.Columns.Add(i.ToString(), Convert.ToString(Obrab.naznName[i]));
                    
                }
                
            
                for (int i = 0; i < Obrab.postName.Count; i++) // вывод строк
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = Obrab.postName[i];
                    
                }
                
               
                

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Попробуйте ещё раз!\nПерезапустите программу!\nНе все ошибки обработаны!", "Ошибка!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Obrab.postName.Count; i++)
            {
                for (int j = 1; j <= Obrab.naznName.Count; j++)
                {
                    a[i] = dataGridView1[j, i].Value.ToString();
                    Obrab.Sum.Add(Convert.ToInt32(a[i]));
                }
            }
           

            Close();
        }
    }
}
