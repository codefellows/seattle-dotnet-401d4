using System;
using System.Collections.Generic;
using System.Text;

namespace Class05Demo.Classes
{
	abstract class Party
	{
		public int GuestListMax { get; set; } = 100;

		public string Music()
		{
			return "Taylor Swift";
		}

		public bool Setup()
		{
			return true;
		}

		public bool TearDown()
		{
			return false;
		}
	}
}
