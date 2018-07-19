using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusMall.Data;
using Microsoft.AspNetCore.Mvc;

namespace BusMall.Models
{
	public class DevInventory : IInventory
	{
		private StoreDbContext _context;

		/// <summary>
		/// Constructor, require the current store DB Context
		/// </summary>
		/// <param name="context"></param>
		public DevInventory(StoreDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Create or add a new product into the inventory
		/// </summary>
		/// <param name="product">The product that you want to create</param>
		public async void CreateProduct(Product product)
		{
			await _context.Products.AddAsync(product);
			 _context.SaveChanges();

		}

		/// <summary>
		/// Delete or remove a product from the inventory
		/// </summary>
		/// <param name="id">The id of the product</param>

		public void DeleteProduct(int id)
		{
			Product product = _context.Products.Single<Product>(p => p.ID == id);
			_context.Products.Remove(product);
			_context.SaveChanges();

		}

		/// <summary>
		/// Get a specific product by id
		/// </summary>
		/// <param name="id">ID of the product you are looking for</param>
		/// <returns>return found product</returns>
		public Product GetProductById(int? id) => _context.Products.Single<Product>(p => p.ID == id);

		/// <summary>
		/// Get all the products in the inventory
		/// </summary>
		/// <returns>return the list of products</returns>
		public IEnumerable<Product> GetProducts() => _context.Products;

		/// <summary>
		/// Update a specific product in the inventory
		/// </summary>
		/// <param name="product">Product information we are updating</param>
		public void UpdateProduct(Product product)
		{
			_context.Products.Update(product);
			_context.SaveChanges();


		}
	}
}
