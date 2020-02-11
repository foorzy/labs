using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;


namespace mcopy
{
    public class Program
    {
        #region Все ошибки(коды завершения программы)
        private const int ERROR_SUCCESS = 0x0;
        private const int ERROR_FILE_NOT_FOUND = 0x2;
        private const int ERROR_PATH_NOT_FOUND = 0x3;
        private const int ERROR_BAD_ARGUMENTS = 0xA0;
        private const int ERROR_INVALID_FLAG_NUMBER = 0xBA;
        private const int ERROR_ACCESS_DENIED = 0x5;
        #endregion
        public static int count = 0; /* Глобальная переменная для метода WalkDirectoryTree
                                      * для подсчета кол-ва скопированных файлов
                                      */

        public static List<string> allfiles = new List<string>();/* Глобальная переменная, список для метода WalkDirectoryTree
                                                                 * для дальнейшего вывода пути и имени файлов
                                                                 */
        public static int ReadArgs(string[] m)
        {//проверка на пустой массив
            try
            {
                if (m.Length == 1 && m[0] != "/?" || m.Length == 0) //если один аргумент в строке - ошибка
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка в синтаксисе команды");
                return Environment.ExitCode = ERROR_BAD_ARGUMENTS;
            }
            string[] allflags = { "/Y", "/-Y","/C", "/?", "/A","/T" };        // все правильные ключи
            List<string> flags = new List<string>();
            List<string> masks = new List<string>();
            List<string> paths = new List<string>();
            string[] attributes = { "R", "A", "H",  }; //регулярка для атрибутов
            Regex flagsR = new Regex(@"\/[A-Z]|\/-Y|\/\?"); // регулярка для проверки на ключ
            Regex checkDir = new Regex(@"([a-zA-Z]:)?(\[a-zA-Z0-9_-]+)+\?|([a-zA-Z]:)"); //регулярка для дириктории
            Regex masksR = new Regex(@"[a-zA-Z0-9_-]+\.(?:[a-zA-Z]+)$|(?:\d*\.)?\d+\.(?:[a-zA-Z]+)$"); //регулярка для имени файла 
            Regex masksForF = new Regex(@"\*\.\*|\*\.[a-z]+"); // регулярка для масок файлов
            int startpoint=0;
            if (m[0] == "/C")
                startpoint = 1;
            for(; startpoint < m.Length; startpoint++)
            {
                if (m[startpoint] == "/A" || m[startpoint] == "/T")
                    break;
                paths.Add(m[startpoint]);
                try
                {
                    if (m[startpoint + 1] == "/T" || m[startpoint + 1] == "/A" || m[startpoint+1].Contains("\\")!=true)
                        break;
                }
                catch(Exception e)
                {
                    break;
                }
            }
            if(paths.Count == 0)
            {
                Console.WriteLine("пути не указаны");
                return Environment.ExitCode = ERROR_FILE_NOT_FOUND;
            }
            for (int i = 0; i < m.Length; i++)
            {
                if (flagsR.IsMatch(m[i]))
                    flags.Add(m[i]);
                if (masksR.IsMatch(m[i]) && checkDir.IsMatch(m[i])) // если в указанном пути есть название файла, то его(путь) не нужно добавлять в список файлов,
                    continue;                                       // а продолжить работу цикла
                else if (masksR.IsMatch(m[i]))
                    masks.Add(m[i]);
            }
            if (flags.Contains("/?"))
            {
                Console.WriteLine("MYCopy [/?] [/C] источник [результат] [/T[типы]] [/A[[:] атрибуты]]]\n"
                                    + "\n" + "  " + "источник\tИмя папки или файла для перемещения.\n"
                                    + " " + "\t/C\tИспользовать папку по умолчанию\n"
                                    + " " + "\t/T\tТипы файлов для обработки\n"
                                    + " " + "\t/.txt\t файлы текстового формата\n"
                                    + " " + "\t/.doc\t файлы формата Microsoft Word\n"
                                    + " " + "\t/.rar\t файлы WinRar архивов\n"
                                    + "  " + "\t/A\tОтбор файлов для перемещения по атрибутам\t\n"
                                    + "  " + "атрибуты\tR файлы,доступны только для чтения\n"
                                    + "\t\tH Скрытые файлы\n\t\tA архивные файлы\n"
                                    + "  " + "результат\tКаталог для конечных файлов\n");
                return Environment.ExitCode = ERROR_SUCCESS;
            }
            //проверка на правильные флаги
            bool corectflag = false;
            if (flags.Count != 0)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i].Contains("/"))
                    {
                        for (int j = 0; j < allflags.Length; j++)
                        {
                            if (m[i] == allflags[j])
                            {
                                corectflag = true;
                                break;
                            }
                        }
                    }
                }
            }
            if(corectflag == false && flags.Count != 0)
            {
                Console.WriteLine("Такого флага не существует");
                return Environment.ExitCode = ERROR_INVALID_FLAG_NUMBER;

            }
            string SourcePath="", TargetPath="";
            //SourcePath = m[0];
            int typesPosition = paths.Count;
            bool defaultwork;
            int flagwhileCopy;
            //проверка на работу по умолчанию
            if (flags.Contains("/C"))
            {
                defaultwork = true;
                flagwhileCopy = paths.Count;
                TargetPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\result");
                typesPosition++;

            }
            else
            {
                flagwhileCopy = paths.Count - 1;
                defaultwork = false;
                TargetPath = paths[paths.Count - 1] ;
            }
            if(flags.Contains("/T") && flags.Contains("/A"))
            {
                List<string> filetypes = new List<string>();
                List<string> Attriblist = new List<string>();
                int i = typesPosition + 1;
                while (true)
                {
                    if (i < m.Length && m[i].Contains("."))
                    {
                        filetypes.Add(m[i]);
                        i++;
                    }
                    else break;
                }
                i++;
                
                //string s = File.GetAttributes(@"C: \Users\Anton\source\repos\archcomp1\test1\философия смита.docx").ToString();
                while(true)
                {
                     switch (m[i])
                     {
                         case "R":
                             Attriblist.Add("ReadOnly, ");
                             break;
                         case "H":
                             Attriblist.Add("Hidden, ");
                             break;
                         case "A":
                             Attriblist.Add("Archive, ");
                             break;
                         default:
                             {
                                 Console.WriteLine("Такого атрибута не существует");
                                 return Environment.ExitCode = ERROR_INVALID_FLAG_NUMBER;
                             }
                        }
                    try
                    {
                        if (m[i + 1].Contains("A") == false && m[i + 1].Contains("H") == false && m[i + 1].Contains("R") == false)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                    i++;
                }
                if (Attriblist.Count == 0)
                {
                    Console.WriteLine("Атрибуты не указаны");
                    return Environment.ExitCode = ERROR_BAD_ARGUMENTS;
                }
                if (filetypes.Count == 0)
                {
                    Console.WriteLine("Шаблоны не указаны");
                    return Environment.ExitCode = ERROR_BAD_ARGUMENTS;
                }

                try
                {
                    for (int j = 0; j < flagwhileCopy; j++)
                    {
                        Copyfiles(paths[j], TargetPath, filetypes,Attriblist);
                        //ClearDirectori(paths[j], filetypes,Attriblist);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Путь не найден");
                    return Environment.ExitCode = ERROR_PATH_NOT_FOUND;
                }
            }

            else if (flags.Contains("/T"))
            {
                List<string> filetypes = new List<string>();
                int i = typesPosition+1;
                while (true)
                {
                    if (i < m.Length && m[i].Contains("."))
                    {
                        filetypes.Add(m[i]);
                        i++;
                    }
                    else break;
                }
                if (filetypes.Count == 0)
                {
                    Console.WriteLine("Шаблоны не указаны");
                    return Environment.ExitCode = ERROR_BAD_ARGUMENTS;
                }
                try
                {
                    for (int j = 0; j < flagwhileCopy; j++)
                    {
                        Copyfiles(paths[j], TargetPath, filetypes);
                        //ClearDirectori(paths[j], filetypes);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Путь не найден");
                    return Environment.ExitCode = ERROR_PATH_NOT_FOUND;
                }

            }
            else if(flags.Contains("/A"))
            {
                List<string> Attriblist = new List<string>();
                int i = typesPosition + 1;
                while (true)
                {
                    switch (m[i])
                    {
                        case "R":
                            Attriblist.Add("ReadOnly, ");
                            break;
                        case "H":
                            Attriblist.Add("Hidden, ");
                            break;
                        case "A":
                            Attriblist.Add("Archive, ");
                            break;
                        default:
                            {
                                Console.WriteLine("Такого атрибута не существует");
                                return Environment.ExitCode = ERROR_INVALID_FLAG_NUMBER;
                            }
                    }
                    try
                    {
                        if (m[i + 1].Contains("A") == false && m[i + 1].Contains("H") == false && m[i + 1].Contains("R") == false)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                    i++;
                }
                if(Attriblist.Count == 0)
                {
                    Console.WriteLine("Атрибуты не указаны");
                    return Environment.ExitCode = ERROR_BAD_ARGUMENTS;
                }
                try
                {
                    for (int j = 0; j < flagwhileCopy; j++)
                    {
                        Copyfiles(paths[j], TargetPath, Attriblist);
                        //ClearDirectori(paths[j], Attriblist);
                    }
                }
                catch(Exception e)
                {

                }
            }
            else
            {
                for (int i = 0; i < flagwhileCopy; i++)
                {
                    try
                    {
                        Copyfiles(paths[i], TargetPath);

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Путь не найден");
                        return Environment.ExitCode = ERROR_PATH_NOT_FOUND;
                    }
                    try
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(paths[i]);

                       
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Путь не найден");
                        return Environment.ExitCode = ERROR_PATH_NOT_FOUND;
                    }
                }
            }
                //Console.WriteLine("Перемещено файлов:   "+FilesCopyd);
            return Environment.ExitCode = ERROR_SUCCESS;
            
        }

        static void Copyfiles(string FromDir, string ToDir)
        {
            try
            {
                Directory.CreateDirectory(ToDir);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Неправильно указан путь к Приёмнику");
                return;
            }
            try
            { 
                foreach (string s1 in Directory.GetFiles(FromDir))
                {
                    string s2 = ToDir + "\\" + Path.GetFileName(s1);
                    File.Copy(s1, s2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("неверно указан путь к источнику");
                return;
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                Copyfiles(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        static void Copyfiles(string FromDir, string ToDir,List<string> FIletypes)
        {
            Directory.CreateDirectory(ToDir);
            bool istypes = false;
            for(int j=0;j<FIletypes.Count;j++)
            {
                if (FIletypes[j].Contains("."))
                    istypes = true;
            }
            if (istypes)
            {
                foreach (string s1 in Directory.GetFiles(FromDir))
                {
                    string s2 = ToDir + "\\" + Path.GetFileName(s1);
                    for (int i = 0; i < FIletypes.Count; i++)
                    {
                        if (s2.Contains(FIletypes[i]))
                        {
                            File.Copy(s1, s2);
                            break;
                        }
                    }
                }
                foreach (string s in Directory.GetDirectories(FromDir))
                {
                    Copyfiles(s, ToDir + "\\" + Path.GetFileName(s), FIletypes);
                }
            }
            else
            {
                foreach (string s1 in Directory.GetFiles(FromDir))
                {
                    string s2 = ToDir + "\\" + Path.GetFileName(s1);
                    for (int i = 0; i < FIletypes.Count; i++)
                    {
                        if (File.GetAttributes(s1).ToString().Contains(FIletypes[i]))
                        {
                            File.Copy(s1, s2);
                            break;
                        }
                    }
                }
                foreach (string s in Directory.GetDirectories(FromDir))
                {
                    Copyfiles(s, ToDir + "\\" + Path.GetFileName(s), FIletypes);
                }
            }
        }

        

        static void Copyfiles(string FromDir, string ToDir, List<string> FIletypes,List<string> atributes)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                for (int i = 0; i < FIletypes.Count; i++)
                {
                    if (s1.Contains(FIletypes[i]))
                    {
                        for(int j=0;j<atributes.Count;j++)
                        {
                            if(File.GetAttributes(s1).ToString().Contains(atributes[j]))
                            {
                                File.Copy(s1, s2);
                                break;
                            }
                        }
                        
                    }
                }
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                Copyfiles(s, ToDir + "\\" + Path.GetFileName(s), FIletypes);
            }
        }

       
        static void Main(string[] args)
        {
            //Console.WriteLine("Чтобы вывести подсказку напишите /?");
            string[] test = new string[] { @"C:\Users\admin\Desktop\archcomp1\test1",@"C:\Users\admin\Desktop\archcomp1\test3" };
            //string[] test = new string[]{"/?"};
            ReadArgs(args);
            Console.ReadKey();
        }
    }
}