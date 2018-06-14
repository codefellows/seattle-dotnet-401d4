using System;
using System.Collections.Generic;
using System.Text;
using Class07_Demo.Interface;

namespace Class07_Demo.Classes
{
    class BendingUnit : Robot, IConquer
    {
	    public bool InsertGirder { get; set; }

	    public string Consumption()
	    {
		    return "Drink it all!";
	    }


	    public string Monologue { get; set; }
	    public string TragicBackstory(string hometown)
	    {
		    return "I'm not trash!";
	    }

	    public string HenchmanPet(string petName)
	    {
		    return "Fry";
	    }
    }
}
