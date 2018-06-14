using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Demo08
{
    class NumberList<T> : IEnumerable
    {
		T[] items = new T[5];

		int count;

		//Add Method

	    public void Add(T item)
	    {
		    if (count == items.Length)
		    {
			    Array.Resize(ref items, items.Length * 2);
		    }

		    items[count++] = item;
	    }

	    public IEnumerator<T> GetEnumerator()
	    {
		    for (int i = 0; i < count; i++)
		    {
			    yield return items[i];
		    }
	    }

	    public void Shuffle()
	    {
		    
	    }


		// Magic Don't Touch
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
