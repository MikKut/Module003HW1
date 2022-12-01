﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.MyListCollection
{
    internal partial class CustomList<T> : IEnumerable<T>, ICustomList<T>
        where T : IComparable<T>
    {
        private T[] _collection;
        private int _size = 0;
        private int _capacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomList{T}"/> class.
        /// </summary>
        /// <param name="capacity">Initial capacity of the <see cref="MyList">.</param>.
        /// <exception cref="ArgumentException">Is thrown when capacity is lower than 1.</exception>
        public CustomList(int capacity = 8)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"Capacity of the {nameof(CustomList<T>)} cannot be less than 1.");
            }

            _capacity = capacity;
            _collection = new T[capacity];
        }

        /// <inheritdoc />
        public int Size { get => _size; }

        /// <inheritdoc />
        public int Capacity { get => _capacity; }

        /// <inheritdoc />
        public bool IsEmpty { get => _size == 0; }

        public T this[int i]
        {
            get
            {
                if (i >= Size)
                {
                    throw new IndexOutOfRangeException($"Index was outside the bounds of the {nameof(CustomList<T>)}");
                }

                return _collection[i];
            }
            set => _collection[i] = value;
        }

        /// <inheritdoc />
        public void Add(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Cannot add {nameof(obj)} because it is null");
            }

            if (Size == Capacity)
            {
                ExpandArray(2);
            }

            _collection[_size++] = obj;
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<T> obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Cannot add {nameof(obj)} because it is null");
            }

            int minSizeOfTheArray = obj.Count() + Size, currentIndex = Size;
            if (minSizeOfTheArray > Capacity + 1)
            {
                ExpandArray((minSizeOfTheArray / Capacity) + 1);
            }

            foreach (T item in obj)
            {
                _collection[currentIndex++] = item;
            }

            _size = minSizeOfTheArray;
        }

        /// <inheritdoc />
        public bool Remove(T obj)
        {
            if (IsEmpty)
            {
                throw new ArgumentException($"{nameof(obj)} cannot be deleted because the {nameof(CustomList<T>)} is empty.");
            }

            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} cannot be deleted because it is null");
            }

            for (int i = 0; i < _size; i++)
            {
                if (obj.Equals(_collection[i]))
                {
                    MakeShiftRight(i);
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public void RemoveAt(int position)
        {
            if (IsEmpty)
            {
                throw new ArgumentException($"object at {position} cannot be deleted because the {nameof(CustomList<T>)} is empty.");
            }

            if (position < 0 || position > Size)
            {
                throw new ArgumentOutOfRangeException($"Cannot acces the object at {position} positon");
            }

            if (_collection[position] == null)
            {
                throw new ArgumentNullException($"object cannot be deleted because it is null");
            }

            MakeShiftRight(position);
        }

        /// <inheritdoc />
        public void Sort()
        {
            var validCollection = GetCollectionWithoutRubbish();
            Array.Sort(validCollection);
            for (int i = 0; i < Size; i++)
            {
                _collection[i] = validCollection[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new CustomListEnumerator<T>(GetCollectionWithoutRubbish());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomListEnumerator<T>(GetCollectionWithoutRubbish());
        }

        /// <summary>
        /// Gets collection untill <see cref="Size">.
        /// </summary>.
        /// <returns>Collection untill <see cref="Size">.</returns>
        private T[] GetCollectionWithoutRubbish()
        {
            var localCollection = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                localCollection[i] = _collection[i];
            }

            return localCollection;
        }

        /// <summary>
        /// Makes shift(ignores) shiftSize elements.
        /// </summary>
        /// <param name="index">Specifies which element to start with.</param>
        /// <param name="shiftSize">Specifies quantity of ignored elements.</param>
        private void MakeShiftRight(int index, int shiftSize = 1)
        {
            for (int i = index + 1; i < _size - 1; i++)
            {
                _collection[i - 1] = _collection[i];
            }

            _size--;
        }

        /// <summary>
        /// Expands array in howManyTimesToIncrese times.
        /// </summary>
        /// <param name="howManyTimesToIncrese">Shows how many times to expand the collection.</param>
        private void ExpandArray(int howManyTimesToIncrese)
        {
            var newCollection = new T[Capacity * howManyTimesToIncrese];
            for (int i = 0; i < Capacity; i++)
            {
                newCollection[i] = _collection[i];
            }

            _collection = newCollection;
            _capacity *= howManyTimesToIncrese;
        }
    }
}
