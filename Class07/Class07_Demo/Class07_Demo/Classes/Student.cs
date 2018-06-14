using System;
using System.Collections.Generic;
using System.Text;

namespace Class07_Demo.Classes
{
    class Student : Person
    {
	    public string Name { get; set; }
	    public override string MyAbstractMethod()
	    {
		    throw new NotImplementedException();
	    }
    }
}
