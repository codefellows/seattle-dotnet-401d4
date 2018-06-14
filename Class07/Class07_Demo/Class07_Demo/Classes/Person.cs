using System;
using System.Collections.Generic;
using System.Text;

namespace Class07_Demo.Classes
{
	abstract class Person
	{
		public string Name { get; set; }
		public string EyeColor { get; set; }
		public string HairColor { get; set; }
		public int Age { get; set; }

		public virtual bool HasFace { get; set; } = true;

		/// <summary>
		/// I am Virtual
		/// </summary>
		/// <returns></returns>
		public virtual string MyVirtualMethod()
		{
			return "My virutal Method";
		}

		/// <summary>
		/// I am abstract
		/// </summary>
		/// <returns></returns>
		public abstract string MyAbstractMethod();



	}
}
