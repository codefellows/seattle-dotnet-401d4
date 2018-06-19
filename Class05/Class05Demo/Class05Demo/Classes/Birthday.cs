using System;
using System.Collections.Generic;
using System.Text;

namespace Class05Demo.Classes
{
	abstract class Birthday : Party
	{
		public abstract bool HasClown { get; set; }

		protected int NewAge { get; set; }
		public virtual string Presents()
		{
			return "New Car";
		}


	}
}
