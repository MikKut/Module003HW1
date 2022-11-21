using System.Collections;

namespace MyList.MyListCollection
{
    internal partial class CustomList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        // When you implement IEnumerable, you must also implement IEnumerator.
        private class CustomListEnumerator<TI> : IEnumerator<TI>
        {
            private TI[] _collection;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            private int _position = -1;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomListEnumerator{TI}"/> class.
            /// </summary>
            /// <param name="list">Collection to iterate.</param>
            public CustomListEnumerator(TI[] list)
            {
                _collection = list;
            }

            TI IEnumerator<TI>.Current
            {
                get
                {
                    try
                    {
                        return _collection[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object? IEnumerator.Current
            {
                get
                {
                    try
                    {
                        return _collection[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            // object IEnumerator.Current => IEnumerator<TI>.Current;
            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                _position++;
                return _position < _collection.Length;
            }

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
