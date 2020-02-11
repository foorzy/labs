using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2TM
{
    public static class Obrabotka
    {
        public static InfoIf infoif = new InfoIf();

        public static InfoElse infoelse = new InfoElse();

        public static string strForFile = "";

        public static int rejectCount = 0;

        static int schetchik = 1;

        public static bool SravneniyeStrok(List<string> spisokIndexDomino, string str1, string str2, string indeksi, int index)
        {
            if (str1 == str2)
            {
                return true;
            }

            if (str1.Length < str2.Length)
            {
                if (str2.Substring(0, str1.Length) == str1)
                {
                    spisokIndexDomino.Add(indeksi + index.ToString());
                }
            }
            else
            {
                if (str1.Substring(0, str2.Length) == str2)
                {
                    spisokIndexDomino.Add(indeksi + index.ToString());
                }
            }
            return false;
        }

        public static int Process(Domino domino)
        {
            var spisokIndexDomino = new List<string>();

            var Glubina = domino.Glubina;

            while (Glubina > 0)
            {

                var newspisokIndexDomino = new List<string>();

                if (spisokIndexDomino.Count != 0)
                {
                    foreach (var indeksi in spisokIndexDomino)
                    {

                    string strVerhToConcate = ""; // То, что может (будет) получаться из комбинаций
                    string strNizToConcate = ""; // То, что может (будет) получаться из комбинаций

                    var dominoIndeces = indeksi.Split(',');

                    foreach (var indexDomino in dominoIndeces)
                    {
                        strVerhToConcate += domino.Verh[Convert.ToInt32(indexDomino)];

                        strNizToConcate += domino.Niz[Convert.ToInt32(indexDomino)];
                    }
                    for (int i = 0; i < domino.Verh.Count; i++) // Смотрим, что можем соединить
                    {
                        var str1 = strVerhToConcate + domino.Verh[i];

                        var str2 = strNizToConcate + domino.Niz[i];

                        var result = SravneniyeStrok(newspisokIndexDomino, str1, str2, indeksi + ",", i); // Сравниваем строки, если строки одинаковы - бросаем в результат 1, говорим, что всё ок!

                        if (result)
                        {
                            infoif.Indexes = indeksi;

                            infoif.i = i;

                            infoif.OutString = str1;

                            infoif.Glubina = domino.Glubina - Glubina + 1;

                            WriteMinInFile(strForFile);
                            strForFile = "";
                            schetchik = 1;

                            return 1;
                        }
                    }
                    }
                }
                else // Бахнули сюда, узнали все домимношки
                {
                    for (int i = 0; i < domino.Verh.Count; i++)
                    {
                        var result = SravneniyeStrok(newspisokIndexDomino, domino.Verh[i], domino.Niz[i], "", i);
                        if (result)
                        {
                            infoelse.i = i;
                            infoelse.OutString = domino.Verh[i];
                            infoelse.Glubina = domino.Glubina - Glubina + 1;

                           // WriteMinInFile(strForFile);
                            
                            return 1;
                        }
                    }
                }

                //strForFile += schetchik.ToString() + " - " + spisokIndexDomino.Count.ToString() + Environment.NewLine;

                spisokIndexDomino = newspisokIndexDomino;
                Glubina--;

                strForFile += schetchik.ToString() + " - " + spisokIndexDomino.Count.ToString() + Environment.NewLine;

                schetchik++;
            }

            strForFile += schetchik.ToString() + " - " + rejectCount + Environment.NewLine;
            rejectCount = spisokIndexDomino.Count;
            return 0;  // Упали в цикл до самого конца шагов глубины, бросаем в результат 0, говорим, что всё плохо.
        }

        public static void WriteMinInFile(string str)
        {
            try
            {
                string path = $"Tests\\result.txt";

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {                    
                        sw.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
