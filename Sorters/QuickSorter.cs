using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public class QuickSorter: Sorter
    {
        public QuickSorter(double[] numbers)
            : base(numbers)
        {
        }

        public override string ToString ()
        {
            return string.Format ( "Quick" );
        }

        public override void Sort ( )
        {
            
            QuickSort(_numbers, 0, _numbers.Length - 1);
        }

        private void QuickSort(double [] a, int num, int length)
        {
            double x = a[num + (length - num) / 2];
 
            int i = num;
            int j = length;
            
            while (i <= j)
            {
                while (IsLargeThan(x,a[i])) i++;
                while (IsLargeThan(a[j],x)) j--;
                if (i <= j)
                {
                    Swap(ref a[i],ref a[j]);
                    i++;
                    j--;
                }
            }
            if (i < length)
                QuickSort(a, i, length);

            if (num < j)
                QuickSort(a, num, j);
        }
        
    }
}
