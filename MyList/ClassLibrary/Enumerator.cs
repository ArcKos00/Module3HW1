using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private T[] _arr;
        private int _position = -1;
        public Enumerator(T[] values)
        {
            _arr = values;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _arr.Length)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _arr[_position];
                }
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_position < _arr.Length - 1)
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
