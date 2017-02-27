using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sorterer;

namespace _20170128_SortersDemo
{
    class Analizer
    {
        /// <summary>
        /// конструктор аналайзера с подпиской на события
        /// </summary>
        /// <param name="s">сортировка</param>
        public Analizer (Sorter s)
        {
            s.SortingStart += StartSortMessage;
            s.Swapp += SwapCounting;
            s.Compare += CompareCounting;
            s.SortingFin += GetSwapCount;
            s.SortingFin += GetCompareCount;
            s.SortingFin += FinishSortMessage;
        }
        /// <summary>
        /// Обработчик события старта сортировки
        /// </summary>
        /// <param name="s"></param>
        /// <param name="arg"></param>
        public void StartSortMessage ( object s, EventArgs arg )
        {
            Console.WriteLine ( "Стартовала " + s.ToString () + " сортировка" );
        }
        /// <summary>
        /// Получения количества обмена элементов
        /// </summary>
        /// <param name="o"></param>
        /// <param name="args"></param>
        public void GetSwapCount ( object o, SortingEventArgs args )
        {
            Console.WriteLine ( "Совершено " + _SwapCount + " перестановок" );
        }
        /// <summary>
        /// Получение количества сравнения элементов
        /// </summary>
        /// <param name="o"></param>
        /// <param name="args"></param>
        public void GetCompareCount ( object o, SortingEventArgs args )
        {
            Console.WriteLine ( "Совершено " + _CompareCount + " сравнений" );
        }
        /// <summary>
        /// Обработчик события окончания сортировки
        /// </summary>
        /// <param name="o"></param>
        /// <param name="arg"></param>
        public void FinishSortMessage ( object o, EventArgs arg )
        {
            Console.WriteLine ( "Закончилась сортировка" );
        }
        /// <summary>
        /// Обработчик события обмена элементов
        /// </summary>
        /// <param name="o"></param>
        /// <param name="arg"></param>
        public void SwapCounting(object o, SwapSorterEventArgs arg)
        {
            _SwapCount++;
        }
        /// <summary>
        /// Обработчик события сравнения элементов
        /// </summary>
        /// <param name="o"></param>
        /// <param name="arg"></param>
        public void CompareCounting ( object o, SwapSorterEventArgs arg )
        {
            _CompareCount++;
        }
        /// <summary>
        /// Счетчик обменов
        /// </summary>
        private uint _SwapCount = 0;
        /// <summary>
        /// Счетчик сравнений
        /// </summary>
        private uint _CompareCount = 0;

    }
}
