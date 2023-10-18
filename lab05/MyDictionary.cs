using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class MyDictionary<TKey, TValue> : IEnumerable
    {
        private KeyValuePair<TKey, TValue>[] array;
        private int count;

        public MyDictionary()
        {
            array = new KeyValuePair<TKey, TValue>[5];
            count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[count] = new KeyValuePair<TKey, TValue>(key, value);
            count++;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (array[i].Key.Equals(key))
                    {
                        return array[i].Value;
                    } 
                }
                throw new KeyNotFoundException();
            }
        }

        public int Count { get { return count; } }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(array, count);
        }

        private class MyEnumerator : IEnumerator
        {
            private KeyValuePair<TKey, TValue>[] array;
            private int count;
            private int position = -1;

            public MyEnumerator(KeyValuePair<TKey, TValue>[] array, int count)
            {
                this.array = array;
                this.count = count;
            }

            public bool MoveNext()
            {
                position++;
                return (position < count);
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get 
                { 
                    return array[position];
                }
            }
        }
    }
}
