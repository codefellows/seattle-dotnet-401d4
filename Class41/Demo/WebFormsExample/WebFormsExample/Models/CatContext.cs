using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace WebFormsExample.Models
{
    public class CatContext : DbContext
    {
		public CatContext(): base()
		{

		}
        public DbSet<Cat> Cats { get; set; }
    }
}