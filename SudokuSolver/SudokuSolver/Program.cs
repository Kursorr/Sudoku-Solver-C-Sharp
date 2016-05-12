using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void ReadFile()
        {
            int counter = 0;
            string line;
         
            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\test.txt");

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }
            file.Close();
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
        }
    }
}
