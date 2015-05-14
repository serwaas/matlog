using System.Linq;
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

        private string MakeDiz(int number)
        {
            var res = "";
            for (var i = 0; i < R; i++)
            {
                var ch = (char)(((number >> i) & 0x01) + 48);
                res = ch + res;
            }
            return res;
        }

        private void Splice(string s1, string s2, int indexS1, int indexS2)
        {
            int k = 0, n = 0;
            for (var i = 0; i < R; i++)
                if (s1[i] != s2[i])
                {
                    k++;
                    n = i;
                }
            switch (k)
            {
                case 0:
                    Rez[IndexRez] = s1;
                    Flag[indexS1] = Flag[indexS2] = 1;
                    IndexRez++;
                    break;
                case 1:
                    if ((s1[n] != '*') && (s1[n] != '*'))
                    {
                        Rez[IndexRez] = s1;
                        var builder = new StringBuilder(Rez[IndexRez]);
                        builder[n] = '*';
                        Rez[IndexRez] = builder.ToString();
                        Flag[indexS1] = Flag[indexS2] = 1;
                        IndexRez++;
                    }
                    break;
            }
        }

        private bool Del(string s)
        {
            var k = s.Count(ss => ss == '*');   
            return k == R; 
        }

        private void Clear()
        {
            IndexS = 0;
            for (var i = 0; i < SR * 2; i++)
            {
                Flag[i] = 0;
                S[i] = "";
            }
            for (var i = 0; i < IndexRez; i++) 
                if (Flag[i] == 0)
                    for (var j = i + 1; j < IndexRez; j++)
                        if (Rez[i] == Rez[j]) Flag[j] = 1;
            for (var i = 0; i < IndexRez; i++) 
                if (Flag[i] == 0)
                {
                    S[IndexS] = Rez[i];
                    IndexS++;
                }
        }
        
        public string[] Minimize(int[] y)
        {

            Y = y.Select(e => e).ToArray();

            //Получить массив S
            for (var i = 0; i < SR; i++) 
                S[i] = MakeDiz(i);

            //Преоразовать S: оставив только те элементы, для которых Y=1. Результат в Rez
            IndexRez = 0;
            for (var i = 0; i < SR; i++)
                if (Y[i] == 1)
                {
                    Rez[IndexRez] = S[i];
                    IndexRez++;
                }
            S = Rez.Select(r => r).ToArray();
            IndexS = IndexRez;
            
            //Склеивание
            for (var i = 0; i < R; i++)
            {
                //Подготовка массива Flag под склеивание
                IndexRez = 0;
                for (var j = 0; j < SR * 2; j++)
                {
                    Flag[j] = 0;
                    Rez[j] = "";
                }

                //Склеивание
                for (var j = 0; j < IndexS - 1; j++)
                    for (var k = j + 1; k < IndexS; k++)
                        Splice(S[j], S[k], j, k);

                //Копирование несклеившихся компонент
                for (var j = 0; j < IndexS; j++)
                    if (Flag[j] == 0)
                    {
                        Rez[IndexRez] = S[j];
                        IndexRez++;
                    }
                //Удаление одинаковых дизъюнктов
                Clear();
            }
            IndexRez = 0;

            //Удалить все дизъюнкты вида **...*
            for (var i = 0; i < IndexS; i++)
                if (!Del(S[i]))
                {
                    Rez[IndexRez] = S[i];
                    IndexRez++;
                }
            
            for (var i = 0; i < S.Length; i++)
            {
                if (S[i] == "")
                    break;
                var chair = S[i];
                S[i] = "";
                if (chair[0] == '0')
                    S[i] += "!x";
                if (chair[0] == '1')
                    S[i] += 'x';
                if (chair[1] == '0')
                    S[i] += "!y";
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