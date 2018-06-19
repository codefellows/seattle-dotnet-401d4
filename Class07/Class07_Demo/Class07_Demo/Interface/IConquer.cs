using System;
using System.Collections.Generic;
using System.Text;

namespace Class07_Demo.Interface
{
    interface IConquer
    {
		string Monologue { get; set; }

	    string TragicBackstory(string hometown);

	    string HenchmanPet(string petName);
    }
}
