using WebFormsExample.Models;

namespace WebFormsExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFormsExample.Models.CatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFormsExample.Models.CatContext context)
        {
            //context.Cats.Add(
            //    new Cat
            //    {
            //        Name = "Josie",
            //        Age = 6,
                    
            //    },
            //    new Cat
            //    {
            //        Name = "Meredith",
            //        Age = 4,

            //    },
            //    new Cat
            //    {
            //        Name = "Belle",
            //        Age = 6,
            //    }

            //);
        }
    }
}
