using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public class HeapSorter: Sorter
    {
        public HeapSorter ( double[] numbers ): base(numbers)
        {

        }

        public override string ToString()
        {
 	         return string.Format("Heap");
        }

        public override void Sort ()
        {
            HSorter ( _numbers, _numbers.Length);
        }
        private void HSorter ( double[] numbers, int numLength )
        {
            for ( int i = numLength / 2 - 1; i >= 0; --i )
            {
                long lPreviousI = i;
                i = AddToPyramid ( numbers, i, numLength );
                if ( lPreviousI != i )
                {
                    ++i;
                }
            }
            for ( int k = numLength - 1; k > 0; --k )
            {
                Swap ( ref _numbers[0], ref _numbers[k] );
                int i = 0;
                int lPreviousI = -1;
                while ( i != lPreviousI )
                {
                    lPreviousI = i;
                    i = AddToPyramid ( numbers, i, k);
                }
            }
        }
        private int AddToPyramid ( double[] numbers, int i, int N )
        {
            int iIMax;
            if ( (2 * i + 2) < N )
            {
                if ( numbers[2 * i + 1] < numbers[2 * i + 2] )
                {
                    iIMax = 2 * i + 2;
                }
                else
                {
                    iIMax = 2 * i + 1;
                }
            }
            else
            {
                iIMax = 2 * i + 1;
            }
            if ( iIMax >= N )
            {
                return i;
            }
            if ( IsLargeThan ( numbers[iIMax], numbers[i] ) )
            {
                Swap ( ref numbers[i], ref numbers[iIMax] );
                if ( iIMax < N / 2 )
                {
                    i = iIMax;
                }
            }
            return i;
        }
    }
}
