using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public class ShellSorter: Sorter
    {
        public ShellSorter ( double[] numbers ): base(numbers)
        {

        }
        public override string ToString ()
        {
            return string.Format ( "Shell" );
        }
        public override void Sort (  )
        {
            int j;
            int iStep = _numbers.Length / 2;
            while ( iStep > 0 )
            {
                for ( int i = 0; i < (_numbers.Length - iStep); ++i )
                {
                    j = i;
                    while ( j >= 0 && IsLargeThan( _numbers[j], _numbers[j + iStep] ) )
                    {
                        Swap ( ref _numbers[j], ref _numbers[j + iStep] );
                        j -= iStep;
                    }
                }
                iStep = iStep / 2;
            }
        }
    }
}
