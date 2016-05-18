using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Sudoku
    {
        public const int size = 9;
        protected int[,] sudoku;

        public Sudoku()
        {
            sudoku = new int[size, size];
        }

        public void ReadFile()
        {
            string file = File.ReadAllText(@"C:\Users\Maxime\Documents\Visual Studio 2015\Projects\SudokuSolver\SudokuSolver\sudoku.txt");

            int i = 0, j = 0;
            int[,] sudoku = new int[size, size];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var column in row.Split(' '))
                {
                    this.sudoku[i, j] = int.Parse(column);
                    j++;
                }
                i++;
            }
        }

        public void DisplaySudoku()
        {
            for (int row = 0; row < sudoku.GetLength(0); row++)
            {
                if (row % 3 == 0) { Console.WriteLine("-------------"); }

                for (int col = 0; col < sudoku.GetLength(1); col++)
                {
                    if (col % 3 == 0) { Console.Write("|"); }

                    Console.Write("{0}", sudoku[row, col]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }

        bool CanFillCell(int candidate, Tuple<int, int> coords)
        {
            int square_x = (coords.Item1 / 3) * 3;

            int square_y = (coords.Item2 / 3) * 3;

            for (int x = square_x; x < square_x + 3; x++)
            {
                for (int y = square_y; y < square_y + 3; y++)
                {
                    int tmp = sudoku[x, y];

                    if (tmp == candidate)
                    {
                        return false;
                    }
                }
            }

            int row = 9;

            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                int tmp = sudoku[rowIndex, coords.Item2];

                if (tmp == candidate)
                {
                    return false;
                }
            }

            int column = 9;

            for (int columnIndex = 0; columnIndex < column; columnIndex++)
            {
                int tmp = sudoku[coords.Item1, columnIndex];

                if (tmp == candidate)
                {
                    return false;
                }
            }
            return true;
        }

        private Tuple<int, int> GridIndex(int value)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (sudoku[x, y] == value)
                        return Tuple.Create(x, y);
                }
            }
            return Tuple.Create(-1, -1);
        }

        public bool Solve()
        {
            Tuple<int, int> coords = GridIndex(0);

            int[] potential_candidates = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (coords.Item1 == -1)
            {
                return true;
            }

            foreach (int candidate in potential_candidates)
            {
                if (CanFillCell(candidate, coords))
                {
                    sudoku[coords.Item1, coords.Item2] = candidate;
                    if (Solve()) { return true; }
                    else { sudoku[coords.Item1, coords.Item2] = 0; }
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.ReadFile();
            sudoku.DisplaySudoku();
            Console.WriteLine("-------------");
            Console.WriteLine("- SOLUTION -");
            sudoku.Solve();
            sudoku.DisplaySudoku();
            Console.WriteLine("-------------");
            Console.ReadKey();
        }
    }
}