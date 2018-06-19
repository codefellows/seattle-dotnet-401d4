using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class09Demo
{
    class Garage<C> : IEnumerable
    {
		C[] items = new C[5];

	    private int count;

	    public void Add(C car)
	    {
		    if (count == items.Length)
		    {
			    Array.Resize(ref items, items.Length * 3);

		    }

		    items[count++] = car;

	    }

	    public IEnumerator<C> GetEnumerator()
	    {
		    for (int i = 0; i < count; i++)
		    {
			    yield return items[i];
		    }
	    }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
