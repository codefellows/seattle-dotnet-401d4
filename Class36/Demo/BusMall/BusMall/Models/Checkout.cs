using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Models
{
	public class Checkout
	{
		public string CCNumber { get; set; }
		public Address Addresss { get; set; }
		public decimal Amount { get; set; }

		public List<Product> Products { get; set; }
	}
}
