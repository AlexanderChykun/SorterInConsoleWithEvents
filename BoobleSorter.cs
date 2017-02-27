using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170128_SortersDemo
{
    class BoobleSorter : Sorter
    {
        public BoobleSorter(double[] numbers)
            : base(numbers)
        {
        }

        public override string SortName
        {
            get 
            {
                return "Booble"; 
            }
        }


        public override void Sort(MyEvent evt)
        {
            bool exit = false;

            do
            {
                exit = false;
                for (int i = 0; i < _numbers.Length-1; i++)
                {
                    if (IsLargeThan(_numbers[i], _numbers[i+1]))
                    {
                        Swap(ref _numbers[i], ref _numbers[i + 1]);
                        exit = true;
                    }
                }
               
            } while (exit);
           
           
        }
    }
}
