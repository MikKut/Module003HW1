namespace MyList.MyListCollection
{
    internal interface ICustomList<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Gets quantity of added elements in the collection.
        /// </summary>
        /// <value>
        /// Quantity of added elements in the collection.
        /// </value>
        public int Size { get; }

        /// <summary>
        /// Gets total quantity of elements in the collection.
        /// </summary>
        /// <value>
        /// Total quantity of elements in the collection.
        /// </value>
        public int Capacity { get; }

        /// <summary>
        /// Gets a value indicating whether the collection is empty.
        /// </summary>
        /// <value>
        /// Value indicating whether the collection is empty.
        /// </value>
        bool IsEmpty { get; }
        T this[int i] { get; set; }

        /// <summary>
        /// Adds element to the collection.
        /// </summary>
        /// <param name="obj">Element to add.</param>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        void Add(T obj);

        /// <summary>
        /// Adds range of elements to the collection.
        /// </summary>
        /// <param name="obj">Range of elements to add.</param>
        /// <exception cref="ArgumentNullException">Range of elements is null.</exception>
        void AddRange(IEnumerable<T> obj);

        /// <summary>
        /// Tries to remove the element.
        /// </summary>
        /// <param name="obj">Element to remove.</param>
        /// <returns>Result showing if the delete succeeded.</returns>
        /// <exception cref="ArgumentException">Is thrown when list is empty.</exception>
        /// <exception cref="ArgumentNullException">Is thrown when argument is null.</exception>
        bool Remove(T obj);

        /// <summary>
        /// Removes element at the position.
        /// </summary>
        /// <param name="position">Position to remove.</param>
        /// <exception cref="ArgumentException">Is thrown when list is empty.</exception>
        /// <exception cref="ArgumentNullException">Is thrown when argument is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown when position is invalid.</exception>
        void RemoveAt(int position);

        /// <summary>
        /// Sorts array with help of <see cref="Array.Sort(Array)"> method.
        /// </summary>.
        void Sort();
    }
}