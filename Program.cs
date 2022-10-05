using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trans
{
    struct Element
    {

        public int Delivery { get; set; }
        public int Value { get; set; }
        public static int FindMinElement(int a, int b)
        {
            if (a > b) return b;
            if (a == b) { return a; }
            else return a;
        }

    }

    public class Obrab
    {
        public static int resultSum = 0;
        public static List<string> postName = new List<string>();
        public static List<int> postZnach = new List<int>();
        public static List<int> ZapasPostZnach = new List<int>();
        public static List<string> naznName = new List<string>();
        public static List<int> naznZnach = new List<int>();
        public static List<int> ZapasNaznZnach = new List<int>();
        public static List<string> result = new List<string>();
        public static List<int> result2int = new List<int>();
        public static List<int> Sum = new List<int>();
    }

    public static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public static void clearList()
        {
            Obrab.postName.Clear();
            Obrab.postZnach.Clear();
            Obrab.ZapasPostZnach.Clear();
            Obrab.naznName.Clear();
            Obrab.naznZnach.Clear();
            Obrab.ZapasNaznZnach.Clear();
            Obrab.result.Clear();
            Obrab.result2int.Clear();
            Obrab.Sum.Clear();
            Obrab.resultSum = 0;
        }



      


        public static void SborPost(string name, string znach)
        {
            Obrab.postName.Add(name);
            Obrab.postZnach.Add(Convert.ToInt32(znach));
            Obrab.ZapasPostZnach.Add(Convert.ToInt32(znach));
        }

        public static void SborNazn(string name, string znach)
        {
            Obrab.naznName.Add(name);
            Obrab.naznZnach.Add(Convert.ToInt32(znach));
            Obrab.ZapasNaznZnach.Add(Convert.ToInt32(znach));
        }

        public static void prog()
        {
            int j = 0;
            int i = 0;
            Element[,] C = new Element[Obrab.postZnach.Count, Obrab.naznZnach.Count];
            int k = 0;

            ///
            for (i = 0; i < Obrab.postName.Count; i++)
            {
                for (j = 0; j < Obrab.naznName.Count; j++)
                {
                   
                    C[i, j].Value = Obrab.Sum[k];
                  
                    k++;

                }
            }
            ///
            i = j = 0;
            while (i < Obrab.postZnach.Count && j < Obrab.naznZnach.Count)
            {

                try
                {
                    if (Obrab.postZnach[i] == 0) { i++; }
                    if (Obrab.naznZnach[j] == 0) { j++; }
                    if (Obrab.postZnach[i] == 0 && Obrab.naznZnach[j] == 0) { i++; j++; }
                    C[i, j].Delivery = Element.FindMinElement(Obrab.postZnach[i], Obrab.naznZnach[j]);
                    Obrab.postZnach[i] -= C[i, j].Delivery;
                    Obrab.naznZnach[j] -= C[i, j].Delivery;
                }
                catch { }
            }
      
            for (i = 0; i < Obrab.postZnach.Count; i++)
            {
                for (j = 0; j < Obrab.naznZnach.Count; j++)
                {

                        Obrab.result.Add(Convert.ToString( C[i, j].Delivery) + "шт.   " + Convert.ToString(C[i, j].Value) + "$");
                    Obrab.result2int.Add(C[i, j].Delivery);

                }
                Console.WriteLine();
            }

            int ResultFunction = 0;
            //считаем целевую функцию
            for (i = 0; i < Obrab.postName.Count; i++)
            {
                for (j = 0; j < Obrab.naznName.Count; j++) {
                    ResultFunction += (C[i, j].Value * C[i, j].Delivery);
                }
            }
            Obrab.resultSum = ResultFunction;

        }
        

    }
}
