using System;
using System.Collections.Generic;
using System.Text;

namespace Demo08
{
    class Example
    {
	    public Day DayOfTheWeek { get; set; }
    }

	enum Day 
	{
		Sunday = 1,
		Monday,
		Tuesday,
		Wednesday = 100,
		Thursday,
		Friday,
		Saturday
	}
}
