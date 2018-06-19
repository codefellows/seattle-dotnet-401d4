using System;
using System.Collections.Generic;
using System.Text;
using Class07_Demo.Interface;

namespace Class07_Demo.Classes
{
    class Cat : IConquer, IPlay
    {
	    public string Name { get; set; }
	    public int Age { get; set; }

	    string DailyKnockingThingsOverSchedule()
	    {
		    return "Monday - Wine.";
	    }

	    public string Monologue { get; set; }
	    public string TragicBackstory(string hometown)
	    {
		    return "MEOW";
	    }

	    public string HenchmanPet(string petName)
	    {
		    return "Amanda";
	    }

	    public string Activity()
	    {
		    throw new NotImplementedException();
	    }
    }
}
