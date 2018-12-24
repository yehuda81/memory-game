using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = Getsize();
            int[,] matrix = new int[size, size];
            GenerateRandomMatrix(size, matrix);
            printmatrix(matrix,99,99);
            bool user1 = true;
            for (int i = 0; i < size * size / 2; i++)
            {
               
                if (user1)
                {                    
                    Console.WriteLine("User1 turn");
                    
                }
                else
                {
                    Console.WriteLine("User2 turn");
                    
                }
                user1 = !user1;
                
                Console.WriteLine("pick firstcard:");
                int card1 = pickcard(matrix, out int a, out int b);
                if (matrix[a, b] != 0)
                {
                    Console.WriteLine("pick secondcard:");

                    int card2 = pickcard(matrix, out int c, out int d);

                    if (c == a && d == b || matrix[c, d] == 0)
                    {
                        i = i - 1;
                        Console.WriteLine("you need to pick anouther card");
                    }
                    else if (card1 != card2)
                    {
                        i = i - 1;
                        Console.WriteLine("Try Again");
                    }
                    else
                    {
                        Console.WriteLine("Keep going");
                        matrix[a, b] = 0;
                        matrix[c, d] = 0;


                    }
                }
                else
                {
                    i = i - 1;
                    Console.WriteLine("you need to pick anouther card");
                }
            }
            Console.WriteLine("you Win");
            printmatrix(matrix, 0, 0);

        }
        private static int pickcard(int[,] matrix,out int a,out int b)
        {
            int i;
            int j;
            
            do
            {                
                Console.Write("Row:");
                i = Convert.ToInt32(Console.ReadLine());
                Console.Write("Col:");
                j = Convert.ToInt32(Console.ReadLine());
                if (i >= matrix.GetLength(0) || i < 0 || j >= matrix.GetLength(1) || j < 0)
                {
                    Console.WriteLine("Try Again");
                   
                }
                
            }
            while (i >= matrix.GetLength(0) || i < 0 || j >= matrix.GetLength(1) || j < 0 );
            int card = matrix[i, j];            
            Console.WriteLine(matrix[i, j]);
            a = i;
            b = j;
            printmatrix(matrix, a, b);
            return card;           

        }
      

        private static void printmatrix(int[,] matrix,int a,int b)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("    ");
                    if (i == a && j == b)
                    {
                        Console.Write(matrix[i,j]);
                    }
                    else if (matrix[i,j] == 0)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void GenerateRandomMatrix(int size, int[,] matrix)
        {
            Random r = new Random();
            int zugot = size * size / 2;
            for (int i = 1; i <= zugot; i++)
            {
                for (int g = 0; g < 2; g++)
                {


                    int row, cul;
                    do

                    {
                        row = r.Next(0, size);
                        cul = r.Next(0, size);
                    }
                    while (matrix[row, cul] != 0);
                    matrix[row, cul] = i;
                }
            }
               
        }

        private static int Getsize()
        {
            int size;

            do
            {
                Console.WriteLine("Enter Size Please:");
                size = Convert.ToInt32(Console.ReadLine());
            }
            while (size <= 0 || size % 2 != 0 || size > 8);
            return size;

            
        }
    }
}
