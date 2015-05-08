using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace matlog
{
    public class MinQwain
    {
        private const int R = 4;
        private const int SR = 16;
        private string[] S;
        private string[] Rez;
        private int[] Flag;
        private int[] Y;
        private int IndexS;
        private int IndexRez;

        public MinQwain()
        {
            S = new string[SR * 2];
            Rez = new string[SR * 2];
            Flag = new int[SR * 2];
            Y = new int[SR];

        }
        ~MinQwain()
        {
        }
        string MakeDiz(int number)
        {
            string res = "";
            for (int i = 0; i < R; i++)
            {
                char ch = (char)(((number >> i) & 0x01) + 48);
                res = ch + res;
            }
            return res;
        }
        void Splice(string S1, string S2, int IndexS1, int IndexS2)
        {
            int k = 0, n = 0;
            for (int i = 0; i < R; i++)
                if (S1[i] != S2[i]) { k++; n = i; }
            switch (k)
            {
                case 0:
                    Rez[IndexRez] = S1;
                    Flag[IndexS1] = Flag[IndexS2] = 1;
                    IndexRez++;
                    break;
                case 1:
                    if ((S1[n] != '*') && (S1[n] != '*'))
                    {
                        Rez[IndexRez] = S1;
                        StringBuilder builder = new StringBuilder(Rez[IndexRez]);
                        builder[n] = '*';
                        Rez[IndexRez] = builder.ToString();
                        Flag[IndexS1] = Flag[IndexS2] = 1;
                        IndexRez++;

                    }
                    break;

            }
            return;
        }
        bool Del(string S)
        {
            bool del = false;
            int k = 0;
            for (int i = 0; i < R; i++) if (S[i] == '*') k++;
            if (k == R) del = true;
            return del;
        }
        void Clear()
        {
            IndexS = 0;
            for (int i = 0; i < SR * 2; i++)
            {
                Flag[i] = 0;
                S[i] = "";
            }
            for (int i = 0; i < IndexRez; i++) if (Flag[i] == 0)
                    for (int j = i + 1; j < IndexRez; j++)
                        if (Rez[i] == Rez[j]) Flag[j] = 1;
            for (int i = 0; i < IndexRez; i++) if (Flag[i] == 0)
                {
                    S[IndexS] = Rez[i];
                    IndexS++;
                }
            return;

        }
        void PrintRez(int Step)
        {
            //Console.WriteLine("------------------------------------------------");

            //if (Step == 0)
            //{
            //    Console.WriteLine("Исходная ДНФ.");

            //}
            //else
            //    if (Step == 100)
            //        Console.WriteLine("Итоговая ДНФ.");
            //    else
            //    {
            //        Console.WriteLine("Шаг номер :{0:d}", Step, ".");

            //    }
            //Console.WriteLine(" Количество дизьюнктов :{0:d}", IndexS);

            //for (int i = 0; i < IndexS; i++)
            //{
            //    Console.Write("{0:d} ", S[i]);

            //}
            //Console.WriteLine();

        }
        public string[] Minimize(int[] y)
        {

            /*Считать массив Y из файла*/
            for (int i = 0; i < SR; i++) Y[i] = y[i];

            /*Получить массив S*/
            for (int i = 0; i < SR; i++) S[i] = MakeDiz(i);
            /*Преоразовать S: оставив только те элементы, для которых Y=1. Результата в Rez*/
            IndexRez = 0;
            for (int i = 0; i < SR; i++)
                if (Y[i] == 1)
                {
                    Rez[IndexRez] = S[i];
                    IndexRez++;
                }
            for (int i = 0; i < SR * 2; i++) S[i] = Rez[i];
            IndexS = IndexRez;
            //PrintRez(0);
            /*склеивание*/
            for (int i = 0; i < R; i++)
            {
                /*подготовка массива Flag под склеивание*/
                IndexRez = 0;
                for (int j = 0; j < SR * 2; j++)
                {
                    Flag[j] = 0;
                    Rez[j] = "";
                }
                /*склеивание*/
                for (int j = 0; j < IndexS - 1; j++)
                    for (int k = j + 1; k < IndexS; k++)
                        Splice(S[j], S[k], j, k);
                /*копирование несклеившихся компонент*/
                for (int j = 0; j < IndexS; j++)
                    if (Flag[j] == 0)
                    {
                        Rez[IndexRez] = S[j];
                        IndexRez++;
                    }
                Clear();/*удаление одинаковых дизъюнктов*/
                //PrintRez(i + 1);/*вывод результата на экран*/
            }
            IndexRez = 0;
            /*Удалить все дизъюнкты вида **...* */
            for (int i = 0; i < IndexS; i++)
                if (!Del(S[i]))
                {
                    Rez[IndexRez] = S[i];
                    IndexRez++;
                }
            //PrintRez(R + 1);
            //PrintRez(100);

          //  Console.WriteLine();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == "")
                    break;
                string chair = S[i];
                S[i] = "";
                if (chair[0] == '0')
                    S[i] += "!x";
                if (chair[0] == '1')
                    S[i] += 'x';
                if (chair[1] == '0')
                    S[i] += "!Y";
                if (chair[1] == '1')
                    S[i] += 'y';
                if (chair[2] == '0')
                    S[i] += "!z";
                if (chair[2] == '1')
                    S[i] += 'z';
                if (chair[3] == '0')
                    S[i] += "!t";
                if (chair[3] == '1')
                    S[i] += 't';
            }

            return S.Where(w=>w!="").ToArray();

        }
    }
}