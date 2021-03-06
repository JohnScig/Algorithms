﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Subject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LoadMatrix();
            Console.ReadLine();
        }

        private static int[,] matrix = new int[6, 5];
        private static Subject[] _subjects = new Subject[]
        {
              new Subject {Name = "no", Value = 0, Time = 0},
              new Subject {Name = "al", Value = 100, Time = 3},
              new Subject {Name = "ar", Value = 20, Time = 2},
              new Subject {Name = "db", Value = 60, Time = 4},
              new Subject {Name = "kr", Value = 40, Time = 1}
        };

        private static void LoadMatrix()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < _subjects.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            DrawCache();

            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < (_subjects.Length); j++)
                {
                    int lastValue = 0;
                    try
                    {
                        lastValue = _subjects[j].Value + matrix[i - _subjects[j].Time, j - 1];
                    }
                    catch (Exception)
                    {

                        lastValue = 0;
                    }

                    int previousMatrixValue = 0;
                    try
                    {
                        previousMatrixValue = matrix[i, j-1];
                    }
                    catch (Exception)
                    {

                        previousMatrixValue = 0;
                    }

                    matrix[i, j] = Math.Max(previousMatrixValue, lastValue);
                }

                DrawCache();
            }
        }

        private static void DrawCache()
        {
            Console.Write("".PadLeft(6));
            for (int j = 0; j < _subjects.Length; j++)
            {

                Console.Write(_subjects[j].Name.PadLeft(6));
                //Console.Write(matrix[i, j].ToString().PadLeft(6));
            }
            Console.WriteLine();

            for (int i = 0; i < 6; i++)
            {
                Console.Write(i.ToString().PadLeft(6));
                for (int j = 0; j < _subjects.Length; j++)
                {
                    //Console.Write(_subjects[j].Name.PadLeft(6));
                    Console.Write(matrix[i, j].ToString().PadLeft(6));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
