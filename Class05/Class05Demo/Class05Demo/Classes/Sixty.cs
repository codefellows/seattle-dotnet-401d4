using System;
using System.Collections.Generic;
using System.Text;

namespace Class05Demo.Classes
{
    class Sixty : OlderTwentyOne
    {
	    public override string Presents()
	    {
		    return base.Presents() + " & Disney Vacation";
	    }
    }
}
