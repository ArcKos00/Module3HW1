using System.Collections;

namespace ClassLibrary
{
    public class MyList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private const int _startCount = 0;
        private T[] _array;
        private int _index = 0;

        public MyList()
        {
            _array = new T[_startCount];
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

        public void Add(T value)
        {
            if (_array.Length == 0 || _index == _array.Length)
            {
                ResizeAdd(ref _array);
                Add(value);
                return;
            }

            if (new MyComparer<T>().Compare(_array[_index], default(T)) == 0)
            {
                _array[_index] = value;
                _index++;
            }
        }

        public void AddRange(T[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                Add(value[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        public bool Remove(T value)
        {
            bool isHappened = false;
            for (int i = _array.Length - 1; i >= 0; i--)
            {
                if (new MyComparer<T>().Compare(_array[i], value) == 0)
                {
                    ResizeRemove(ref _array, i);
                    isHappened = true;
                    _index--;
                }
            }

            return isHappened;
        }

        public void RemoveAt(int index)
        {
            ResizeRemove(ref _array, index);
            _index--;
        }

        public void Sort()
        {
            Array.Sort(_array, new MyComparer<T>());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        private void ResizeAdd(ref T[] arr, int diff = 1)
        {
            T[] newArr = new T[arr.Length + diff];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        private void ResizeRemove(ref T[] arr, int index)
        {
            T[] newArr = new T[arr.Length - 1];

            if (index <= 0 && index > arr.Length)
            {
                return;
            }

            for (int i = 0; i < index; i++)
            {
                newArr[i] = arr[i];
            }

            for (int i = index; i < newArr.Length; i++)
            {
                newArr[i] = arr[i + 1];
            }

            arr = newArr;
        }
    }
}