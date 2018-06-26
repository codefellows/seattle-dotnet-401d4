using DemoClass14.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DemoClass14.Models;
using System.Linq;
using DemoClass14.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Demo14Tests
{
    public class AuthorControllerTests
    {
        [Fact]
        public async void DatabaseCanSave()
		{
			DbContextOptions<LibraryDbContext> options =
				new DbContextOptionsBuilder<LibraryDbContext>()
				.UseInMemoryDatabase("DbCanSave")
				.Options;

			using (LibraryDbContext context = new LibraryDbContext(options))
			{

				//Arrange
				Author author = new Author();
				author.Name = "Amanda";
				author.Genre = Genre.ScienceFiction;

				//Act
				await context.Authors.AddAsync(author);
				await context.SaveChangesAsync();

				var results = context.Authors.Where(a => a.Name == "Amanda");

				//Assert
				Assert.Equal(1, results.Count());
			}

        }


		[Fact]
		public async void AuthorControllerCanCreate()
		{
			DbContextOptions<LibraryDbContext> options =
				new DbContextOptionsBuilder<LibraryDbContext>()
				.UseInMemoryDatabase("AuthorCreateTestDb")
				.Options;

			using (LibraryDbContext context = new LibraryDbContext(options))
			{

				//Arrange
				Author author = new Author();
				author.Name = "Miss Kitty";
				author.Genre = Genre.Fantasy;

				//Act
				AuthorController ac = new AuthorController(context);

				var x = ac.Create(author);

				var results = context.Authors.Where(a => a.Name == "Miss Kitty");

				//Assert
				Assert.Equal(1, results.Count());
			}

		}



		[Fact]
		public async void ReturnsIActionResult()
		{
			DbContextOptions<LibraryDbContext> options =
				new DbContextOptionsBuilder<LibraryDbContext>()
				.UseInMemoryDatabase("AuthorCreateTestDb")
				.Options;

			using (LibraryDbContext context = new LibraryDbContext(options))
			{

				//Arrange
				Author author = new Author();
				author.Name = "Miss Kitty";
				author.Genre = Genre.Fantasy;

				//Act
				AuthorController ac = new AuthorController(context);

				var x = ac.Create(author);

				var results = context.Authors.Where(a => a.Name == "Miss Kitty");

				//Assert
				Assert.IsAssignableFrom<IActionResult>(x);
			}

		}


		[Fact]
		public async void AuthorNameGetterTest()
		{
		

				//Arrange
				Author author = new Author();
				author.Name = "Miss Kitty";
				author.Genre = Genre.Fantasy;
			author.Name = "Amanda";

				Assert.Equal("Amanda", author.Name);
			

		}
	}
}
