using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Enumeratorssss<T> : IEnumerator<T>
    {
        private T[] _array;
        private int _position = -1;
        public Enumeratorssss(T[] values)
        {
            _array = values;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _array.Length)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _array[_position];
                }
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_position < _array.Length - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
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
