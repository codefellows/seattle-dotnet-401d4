using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Models
{
	public interface IInventory
	{
		/// <summary>
		/// Create a new product into the inventory
		/// </summary>
		/// <param name="product">New product to add</param>
		/// <returns>Result of product being created</returns>
		void CreateProduct(Product product);

		/// <summary>
		/// Get a specific product by ID
		/// </summary>
		/// <param name="id">ID of specific product</param>
		/// <returns>result of action being finished</returns>
		Product GetProductById(int? id);

		/// <summary>
		/// Get all products in the inventory
		/// </summary>
		/// <returns>result of retrival of products</returns>
		IEnumerable<Product> GetProducts();

		/// <summary>
		/// Update a specific product in the inventory
		/// </summary>
		/// <param name="id">ID of the specific product</param>
		/// <param name="product">New information about the product</param>
		/// <returns>result of IActionresult</returns>
		void UpdateProduct(Product product);

		/// <summary>
		/// Delete/remove a product from the inventory
		/// </summary>
		/// <param name="id">specific id of a product</param>
		/// <returns>result of the IActionResult</returns>
		void DeleteProduct(int id);

	}
}
