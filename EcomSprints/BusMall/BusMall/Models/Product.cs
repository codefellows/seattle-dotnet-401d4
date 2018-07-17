using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Models
{
	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string SKU { get; set; }
		public decimal Price { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
	}
}
