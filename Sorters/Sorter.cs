using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorterer
{
    public delegate void SortingStart ( object s, SortingEventArgs args );
    public delegate void Swapped ( object s, SwapSorterEventArgs args );
    public delegate void SortingFin (object s, SortingEventArgs args);

    public class SortingEventArgs : EventArgs
    {
        public SortingEventArgs ()
        {
        }
    }

    public class SwapSorterEventArgs : EventArgs
    {
        public SwapSorterEventArgs(double a = 0, double b = 0)
        {
            FirstArg = a;
            SecondArg = b;
        }

        public double FirstArg { get; private set; }
        public double SecondArg { get; private set; }
    }
    interface SortEvents
    {
        event SortingStart SortingStart;
        event Swapped Swapp;
        event Swapped Compare;
        event SortingFin SortingFin;
    }

    public abstract class Sorter : SortEvents
    {
        public const int DEF_SIZE = 10000;

        #region ctors

        public Sorter ( int size = DEF_SIZE )
        {
            _numbers = new double[size];
            // инициализация с помощью Random !!!
        }

        public Sorter ( double[] numbers )
        {

            _numbers = (double[]) numbers.Clone ();
        }

        #endregion

        public event SortingStart SortingStart
        {
            add
            {
                _SStart += value;

            }
            remove
            {
                _SStart -= value;
            }
        }
        public event Swapped Swapp
        {
            add
            {
                _Swap += value;
            }
            remove
            {
                _Swap -= value;
            }
        }
        public event Swapped Compare
        {
            add
            {
                _Compare += value;
            }
            remove
            {
                _Compare -= value;
            }
        }
        public event SortingFin SortingFin
        {
            add
            {
                _SFin += value;
            }
            remove
            {
                _SFin -= value;
            }
        }
        public void Run ()
        {
            if ( _SStart != null )
            {
                _SStart ( this, new SortingEventArgs () );
            }
            Sort ();
            if ( _SFin != null )
            {
                _SFin ( this, new SortingEventArgs () );
            }
        }
        public abstract void Sort ();
        public void Swap ( ref double a, ref double b )
        {

            double c = b;
            b = a;
            a = c;
            if ( _Swap != null )
            {
                _Swap ( this, new SwapSorterEventArgs ( a, b ) );
            }
        }
        public bool IsLargeThan ( double a, double b )
        {
            if ( _Compare != null )
            {
                _Compare ( this, new SwapSorterEventArgs ( a, b ) );
            }

            return a > b;
        }
        public double this[int index]
        {
            get
            {
                return _numbers[index];
            }
            set
            {
                _numbers[index] = value;
            }
        }
        public Sorter GetArrCopy()
        {
            return (Sorter)MemberwiseClone();
        }
        protected double[] _numbers = null;
        protected SortingStart _SStart;
        protected Swapped _Swap;
        protected Swapped _Compare;
        protected SortingFin _SFin;
    
    }

    
}
