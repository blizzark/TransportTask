using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Trans
{
    public partial class Form1 : Form
    {
        public static List<int> result = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.clearList();
            Form ifrm = new Form2();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем Form2
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("0", "Поставщики");


                Program.prog();
                int k = 0;
                for (int i = 0; i < Obrab.naznName.Count; i++) // вывод колонок
                {
                    dataGridView1.Columns.Add(i.ToString(), Convert.ToString(Obrab.naznName[i]));
                    k++;
                }
                k += 1;
                dataGridView1.Columns.Add(k.ToString(), "Запасы");
                k = 0;



                for (int i = 0; i < Obrab.postZnach.Count; i++)
                {
                    for (int j = 1; j < Obrab.naznZnach.Count + 1; j++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[j].Value = Obrab.result[k];
                        if (Obrab.result2int[k] != 0)
                        {
                            dataGridView1[j, i].Style.BackColor = Color.LightSeaGreen;
                        }
                        k++;
                    }
                }



                k = 0;
                for (int i = 0; i < Obrab.postName.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Obrab.postName[i];
                    k++;
                }
                dataGridView1.Rows[k].Cells[0].Value = "Потребность:";
                for (int i = 1; i < Obrab.naznName.Count + 1; i++)
                {
                    dataGridView1.Rows[k].Cells[i].Value = Obrab.ZapasNaznZnach[i - 1];
                }

                for (int i = 0; i < Obrab.postName.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[Obrab.naznName.Count + 1].Value = Obrab.ZapasPostZnach[i];
                }
                int zapas = 0;
                int potreb = 0;
                for (int i = 0; i < Obrab.ZapasPostZnach.Count; i++)
                {
                    zapas = zapas + Obrab.ZapasPostZnach[i];
                }
                for (int i = 0; i < Obrab.ZapasNaznZnach.Count; i++)
                {
                    potreb = potreb + Obrab.ZapasNaznZnach[i];
                }

                label4.Text = Convert.ToString(zapas);
                label5.Text = Convert.ToString(potreb);
                if (zapas == potreb)
                {


                    label6.Text = "Задача сбалансированная";
                    label6.BackColor = Color.Green;
                }
                else
                {
                    label6.Text = "Задача несбалансированная!";
                    label6.BackColor = Color.Red;
                }
                label8.Text = Convert.ToString(Obrab.resultSum);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Попробуйте ещё раз!\nПерезапустите программу!\nНе все ошибки обработаны!", "Ошибка!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данную программу разработали студенты\nСПбГТИ(ТУ) факультета ИТиУ 475группы:\nОвчинников Роман Сергеевич\nАндрианова Карина Ивановна\nПекер Валерия Александровна", "Информация о разработчике");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            label4.Text = "0";
            label5.Text = "0";
            label8.Text = "0";
            label6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"HelpTrans.chm", HelpNavigator.TableOfContents);
        }
    }
}
