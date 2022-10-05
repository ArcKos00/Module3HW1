using System.Collections;

namespace ClassLibrary
{
    public class MyList<T> : IEnumerable
    {
        private T[] _array;
        private int _index = 0;

        public MyList()
        {
            _array = new T[0];
        }

        public MyList(int count)
        {
            _array = new T[count];
        }

        public MyList(params T[] collection)
        {
            _array = new T[collection.Length];
            for (int i = 0; i < collection.Length; i++)
            {
                _array[i] = collection[i];
            }

            _index = collection.Length - 1;
        }

        public T[] GetList
        {
            get { return _array; }
        }

        // пересчет элементов коллекции
        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(_array);
        }

        // Добавить в конец коллекуции элемент
        public void Add(T value)
        {
            if (_array[_index] == null && _index < _array.Length)
            {
                _array[_index] = value;
                _index++;
            }
            else
            {
                Resize(ref _array, 5);
                Add(value);
            }
        }

        // добавить в конец колекции коллекцию или массив
        public void AddRange(T[] value)
        {

        }

        // Удалить из колекции данный элемент и сдвинуть коллекцию в случае успешного удаления вернуть труе
        public bool Remove(T value)
        {
            return true;
        }

        // удалить из коллекции элемент по индексу и сдвинуть коллекцию
        public void RemoveAt(int index)
        {

        }

        // отсортировать коллекцию
        public void Sort()
        {
            Array.Sort();
        }

        private void Resize(ref T[] arr, int diff = 1)
        {
            T[] newArr = new T[arr.Length + diff];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
    }
}