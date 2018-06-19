using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class11Demo.Models.ViewModels
{
    public class ResponseExampleViewModel
    {
	    public int Number { get; set; }
	    public bool IsTrue { get; set; }
	    public List<Cat> myCats = new List<Cat>();
    }
}
