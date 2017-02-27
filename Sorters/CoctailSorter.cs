using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public class CoctailSorter: Sorter
    {
        public CoctailSorter ( double[] numbers ):base(numbers)
        {

        }
        public override string ToString ()
        {
            return string.Format ( "Coctail" );
        }
        public override void Sort ( )
        {
            int numLeft = 0;
            int numRight = _numbers.Length - 1;

            while ( numLeft <= numRight )
            {
                for ( int i = numLeft; i < numRight; ++i )
                {
                    if ( IsLargeThan( _numbers[i], _numbers[i + 1] ) )
                      Swap ( ref _numbers[i], ref _numbers[i + 1] );
                }
                --numRight;

                for ( int i = numRight; i > numLeft; --i )
                {
                    if ( IsLargeThan ( _numbers[i - 1], _numbers[i] ) )
                       Swap ( ref _numbers[i - 1], ref _numbers[i] );
                }
                ++numLeft;
            }
        }
    }
}
