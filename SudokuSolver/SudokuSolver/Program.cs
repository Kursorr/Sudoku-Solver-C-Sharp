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
               new System.IO.StreamReader("C:\\Users\\Maxime\\Documents\\Visual Studio 2015\\Projects\\SudokuSolver\\SudokuSolver\\sudoku.txt");

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }
            file.Close();
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            ReadFile();
        }
    }
}
