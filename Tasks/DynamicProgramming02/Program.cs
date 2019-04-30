using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming02
{
    class Subject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
    }

    class ChartElement
    {
        public int Value { get; set; }
        public bool Selected { get; set; }

        public ChartElement()
        {
            Value = 0;
            Selected = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LoadMatrix();
            Console.ReadLine();
            WhichSubjectsToStudy();
            Console.ReadLine();
        }

        private static ChartElement[,] matrix = new ChartElement[6, 5];
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
                        matrix[i, j].Value = 0;
                    }
                }
            }

            DrawCache();

            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < (_subjects.Length); j++)
                {
                    int addedValue = 0;
                    try
                    {
                        addedValue = _subjects[j].Value + matrix[i - _subjects[j].Time, j - 1].Value;
                    }
                    catch (Exception)
                    {

                        addedValue = 0;
                    }

                    int noAddedValue = 0;
                    try
                    {
                        noAddedValue = matrix[i, j - 1].Value;
                    }
                    catch (Exception)
                    {

                        noAddedValue = 0;
                    }

                    matrix[i, j].Value = Math.Max(noAddedValue, addedValue);
                    if (matrix[i, j].Value == addedValue)
                    {
                        matrix[i, j].Selected = true;
                    }
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

        private static void WhichSubjectsToStudy()
        {

        }


    }
}
