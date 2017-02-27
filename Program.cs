using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorterer;

namespace _20170128_SortersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            double[] numbers = new double[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.NextDouble();
            }

            TestSortMethod ( new BubbleSorter ( numbers ) );
            Console.WriteLine ();
           
            TestSortMethod ( new QuickSorter ( numbers ) );
            Console.WriteLine ();

            TestSortMethod ( new InsertSorter ( numbers ) );
            Console.WriteLine ();

            TestSortMethod ( new ShellSorter ( numbers ) );
            Console.WriteLine ();

            TestSortMethod ( new HeapSorter ( numbers ) );
            Console.WriteLine ();

            TestSortMethod ( new CoctailSorter ( numbers ) );
            Console.WriteLine ();

            Console.ReadKey();
        }

        /// <summary>
        /// Запуск сортировки
        /// </summary>
        /// <param name="s">тип сортировки</param>
        private static void TestSortMethod(Sorter s)
        {
            Analizer a = new Analizer (s);
            
            s.Run();
        }
    }
}
