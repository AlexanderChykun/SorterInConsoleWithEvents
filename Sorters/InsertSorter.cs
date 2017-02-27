using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public class InsertSorter : Sorter
    {
        public InsertSorter(double[] numbers) : base(numbers)
        {
            
        }

        public override string ToString ()
        {
            return string.Format ( "Insert" );
        }

        public override void Sort()
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                double temp = _numbers[i];
                int j = i - 1;
                while ( j >= 0 &&IsLargeThan ( _numbers[j], temp ) )
                {
                    
                    _numbers[j + 1] = _numbers[j];
                    j--;
                }
                
                _numbers[j + 1] = temp;
            }
        }
    }
}
