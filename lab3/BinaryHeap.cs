using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class BinaryHeap : IEnumerable
    {
        private int[] array;

        public int Parent(int i)
        {
            if (i == 1)
                return -1;
            return i / 2;
        }

        public int Right(int i)
        {
            int res = 2 * i + 1;
            if (res > Count)
                return -1;
            return res;
        }

        public int Left(int i)
        {
            int res = 2 * i;
            if (res > Count)
                return -1;
            return res;
        }

        private const int LENGTH = 10;
        public int Count;
        public BinaryHeap()
        {
            array = new int[LENGTH];
            Count = 0;
        }

        public void Heapify(int i)
        {
            int l = Left(i);
            int r = Right(i); // индекс находился вне границ ???
            int largest = i;
            if (l != -1 && this[l] > this[largest])
                largest = l;
            if (r != -1 && this[r] > this[largest])
                largest = r;
            if (largest != i)
            {
                int temp = this[i];
                this[i] = this[largest];
                this[largest] = temp;
                Heapify(largest);
            }
        }

        public BinaryHeap(int[] A)
        {
            array = A;
            Count = array.Length;
            //int temp;
            //if (array.Length % 2 == 0)
            //    temp = array.Length / 2;
            //else
            //    temp = array.Length / 2 - 1;
            for (int i = array.Length / 2; i > 0; i--) // нижний слой не имеет листьев, действие не имеет смысла. Корень тоже должен делать хипифай
                Heapify(i);
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
        public override string ToString()
        {
            string result = "";
            int max = 0;
            for (int i = 0; i < Count; i++)
            {
                result += array[i].ToString() + " ";
                if (i == max)
                {
                    result += "\n";
                    max += 2 * (max / 2 + 1);
                }
            }
            return result;
        }

        int this[int i]
        {
            get
            {
                return array[i - 1];
            }
             set
            {
                array[i - 1] = value;
            }
        }

        public static void SortArray(ref int[] array)
        {
            BinaryHeap heap = new BinaryHeap(array); // тут уже и происходит хиппифай всего дерева, кроме последнего слоя
            for (int i = heap.Count; i > 1; i--)
            {
                int temp = heap[i];
                heap[i] = heap[1];
                heap[1] = temp;
                heap.Count--;
                heap.Heapify(1);
            }
            array = heap.array;
        }
    
    }
}
