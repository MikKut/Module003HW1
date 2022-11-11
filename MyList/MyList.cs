using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.MyList
{
    internal class MyList<T> : IEnumerable<T>
    {
        private T[] collection;
        private int _size = 0;
        private int _capacity;

        public MyList(int capacity = 8)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"Capacity of the {nameof(MyList<T>)} cannot be less than 1.");
            }

            _capacity = capacity;
            collection = new T[capacity];
        }
        public int Size { get => _size; }
        public int Capacity { get => _capacity; }
        public bool IsEmpty { get => _size == 0; }
        public void Add(T obj)
        {

        }
        public void AddRange(ICollection<T> obj)
        {

        }
        public bool Remove(T obj)
        {
            if (IsEmpty)
            {
                throw new ArgumentException($"{nameof(obj)} cannot be deleted because the {nameof(MyList<T>)} is empty.");
            }

            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} cannot be deleted because it is null");
            }

            for (int i = 0; i < _size; i++)
            {
                if (obj.Equals(collection[i]))
                {
                    MakeShiftRight(i);
                    return true;
                }
            }

            return false;
        }
        public bool RemoveAt(T obj)
        {

        }
        public void Sort(IComparer comparer)
        {

        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private void MakeShiftRight(int index, int shiftSize = 1)
        {
            for(int i = index+1; i < _size - 1; i++)
            {
                collection[i - 1] = collection[i];
            }
            _size--;
        }
        private void MakeShiftLeft(int shiftSize = 1)
        {

        }
    }
}
