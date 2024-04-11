using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    internal class Demo
    {

        public static void Practice1()
        {

            string path = @"C:\\Users\\Admin\\source\\repos\\FileIO\\FileIO\\demo.txt";

            if(File.Exists(path))
            {
                Console.WriteLine("file is present ");
            }
            else 
            {
               File.CreateText(path);
                Console.WriteLine("it is not present");
            }
        }

       

        internal static void RaeadingAllLines()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\demo.txt";
            string[] lines;

            lines=File.ReadAllLines(path);


            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

        }

        internal static void ReadingText()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\demo.txt";
            string lines;
            lines = File.ReadAllText(path);

            Console.WriteLine(lines);
        }

        internal static void Clone()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\demo.txt";

            string copyPath = @"C:\Users\Admin\source\repos\FileIO\FileIO\\file.txt";
            if (!File.Exists(copyPath))
            {
                File.Copy(path, copyPath);
                Console.WriteLine("copied succussfully");
                Console.ReadKey();

            }

        }

        public static void Delete()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\file.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("deleted file succussfully");
            }
            else
                Console.WriteLine("File not found or has been deleted prior");
        }


        // reading text using stream 
        public static void Read()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\demo.txt";

            using (StreamReader sr= File.OpenText(path))
            {
                string s = "";

                while((s= sr.ReadLine())!=null) {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }

        public static void Write()
        {
            string path = @"C:\Users\Admin\source\repos\FileIO\FileIO\\demo.txt";

            

            using (StreamWriter sw= File.AppendText(path))
            {
                sw.WriteLine("USN  - 3VC20ME442");
                sw.Close();
                Console.WriteLine(File.ReadAllText(path));

            }
        }
    }
}
