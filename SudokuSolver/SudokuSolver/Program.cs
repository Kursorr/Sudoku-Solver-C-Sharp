using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static int[,] ReadFile()
        {
            string file = File.ReadAllText("C:\\Users\\Maxime\\Documents\\Visual Studio 2015\\Projects\\SudokuSolver\\SudokuSolver\\sudoku.txt");

            int i = 0, j = 0;
            int[,] sudoku = new int[9, 9];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var column in row.Split(' '))
                {
                    sudoku[i, j] = int.Parse(column);
                    j++;
                }
                i++;
            }
            return sudoku;
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
