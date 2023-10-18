using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    class MyList<T>
    {
        private T[] items;

        public MyList()
        {
            items = new T[0];
        }

        public void Add(T item)
        {
            T[] new_items = new T[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                new_items[i] = items[i];
            }
            new_items[items.Length] = item;
            items = new_items;
        }

        public T this[int index]
        {
            get { return items[index]; }
        }

        public int Count
        {
            get { return items.Length; }
        }
    }
}
