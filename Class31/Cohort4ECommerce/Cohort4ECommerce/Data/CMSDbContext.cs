using Cohort4ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Data
{
	public class CMSDbContext : DbContext
	{
		public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>().HasData
				(
				new Post
				{
					ID = 1,
					Title = "My cats are my best friends",
					Contents = "Seriously, they are my best friends. They really know me.",
				}, 
				new Post
				{
					ID = 2,
					Title = "Tacos are Great",
					Contents = "Tacos make me happy, they are delicious. They make all the problems go away.",
				},
				new Post
				{
					ID = 3,
					Title = "Disney Princess",
					Contents = "Elsa is not a princess. She is a queen. Therefore better than all other princesses.",

				},
				new Post
				{
					ID = 4,
					Title = "Coffee is life",
					Contents = "Dear Coffee, I love you. That is all.",
				}

				);

		}

		public DbSet<Post> Posts { get; set; }
	}
}
