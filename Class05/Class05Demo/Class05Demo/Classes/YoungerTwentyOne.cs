using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Class05Demo.Classes
{
	class YoungerTwentyOne : Birthday
	{
		public override bool HasClown { get; set; } = true;

		public sealed override string Presents()
		{
			return "Tickle-Me-Elmo";
		}
	}
}
