using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;


namespace ConsoleApplication1
{
   
    class ReadFile
    {

        protected string path = @"D:\in.txt";
        protected string res = "";
        public ReadFile()
        {
            try
            {
                Console.WriteLine("*********Считывание файла*********");
                FileStream file = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(file, Encoding.Default);
                res = reader.ReadToEnd();
                Console.WriteLine(res);
                reader.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class RegexDataInfo:ReadFile
    {

        private string regexData = @"(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])-[0-9]{4}";
        protected string Vpath = @"D:\on.txt";

        public RegexDataInfo()
        {

            Console.WriteLine("*********Применение регярного выражения*********");
            // StreamWriter sw = new StreamWriter(Vpath, false, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(Vpath, false, Encoding.Default);
            Match match = Regex.Match(this.res, regexData);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                sw.WriteLine(match.Value);
               match = match.NextMatch();

            }
            sw.Close();
        }

    }
    


    class Program
    {
        static void Main(string[] args)
        {
            //ReadFile readFile = new ReadFile();
            RegexDataInfo regexDataInfo = new RegexDataInfo();
        }
    }
}
