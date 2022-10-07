using System.Collections;

namespace ClassLibrary
{
    public class MyList<T>
        where T : IComparable<T>
    {
        private T[] _array;
        private int _index = 0;

        public MyList()
        {
            _array = new T[2];
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
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_array);
        }

        // Добавить в конец коллекуции элемент
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

        // добавить в конец колекции коллекцию или массив
        public void AddRange(T[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                Add(value[i]);
            }
        }

        // Удалить из колекции данный элемент и сдвинуть коллекцию в случае успешного удаления вернуть труе
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

        // удалить из коллекции элемент по индексу и сдвинуть коллекцию
        public void RemoveAt(int index)
        {
            ResizeRemove(ref _array, index);
            _index--;
        }

        // отсортировать коллекцию
        public void Sort()
        {
            Array.Sort(_array, new MyComparer<T>());
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