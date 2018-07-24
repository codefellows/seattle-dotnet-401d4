using BusMall.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMall.Data
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData
				(
				   new Product
				   {
					   ID = 1,
					   SKU = "BAN246",
					   Name = "Banana Slicer",
					   Price = 4.99M,
					   Description = "Slice your bananas into smaller pieces!",
					   Image = @"\Images\assets\banana.jpg",
					   Quantity = 10,

				   },
					new Product
					{
						ID = 2,
						SKU = "Uni481",
						Name = "Unicorn Meat",
						Price = 2.95M,
						Description = "Nothing is tastier than meat from a magical stallion!",
						Image = @"\Images\assets\unicorn.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 3,
						SKU = "Win637",
						Name = "No-Spill Wine Glass",
						Price = 7.50M,
						Description = "You can't spill the wine, if you can't drink it.",
						Image = @"\Images\assets\wine-glass.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 4,
						SKU = "BOOT348",
						Name = "Open-Toed Rain Boots",
						Price = 11.55M,
						Description = "Look Fashionable in the rain",
						Image = @"\Images\assets\boots.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 5,
						SKU = "DRGN123",
						Name = "Dragon Meat",
						Price = 1.50M,
						Description = "The Khaleesi approves this.",
						Image = @"\Images\assets\dragon.jpg",
						Quantity = 10,

					}, 
					new Product
					{
						ID = 6,
						SKU = "R2D246",
						Name = "R2D2 Bag",
						Price = 19.00M,
						Description = "These are the bags you are looking for!",
						Image = @"\Images\assets\bag.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 7,
						SKU = "WTR729",
						Name = "Self Watering Can",
						Price = 6.77M,
						Description = "Imagine a can that can fill itself.",
						Image = @"\Images\assets\water-can.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 8,
						SKU = "SCS988",
						Name = "Pizza Scissors",
						Price = 2.99M,
						Description = "Cutting Pizza with scissors is cool.",
						Image = @"\Images\assets\scissors.jpg",
						Quantity = 10,

					},
					new Product
					{
						ID = 9,
						SKU = "CHR654",
						Name = "Outverted Chair",
						Price = 10.47M,
						Description = "Why sit down, when you can sit up!!",
						Image = @"\Images\assets\chair.jpg",
						Quantity = 10,
					},
					new Product
					{
						ID = 10,
						SKU = "BFST123",
						Name = "All-In-One Breakfast Maker",
						Price = 14.39M,
						Description = "Break the fast all in one place!",
						Image = @"\Images\assets\breakfast.jpg",
						Quantity = 10,

					}
				);


		}

		public DbSet<Product> Products { get; set; }
	}
}
