### Set up MVC
1. File >> New Project
2. ASP.NET Core Web Application
3. Create a project name (Do not use dashes, only use underscores if needed)
4. Select Empty for the type of web application
5. Go to StartupClass
6. In ConfigureServices add middleware `services.AddMVC()`
7. In `Configure()` add HTTP Pipeline requirements

```
app.UseMvc(routes =>
{
	routes.MapRoute(
	name: "default",
	template: "{controller=Home}/{action=Index}/{id?}");
});
```

8. Add app.UseStaticFiles() under Configure() after mapping the route.
9. Create a new folder in solution called "Controllers"
10. Create a new folder in solution called "Models"
11. Create a new folder in solution called "Views"
12. Create a new class named HomeController in the Controllers Folder
13. Derive HomeController from base class Controller (`HomeController:Controller`)
14. Import the appropriate namespace (`Microsoft.AspNetcore.MVC`)
15. Create new action in HomeController named "Index" with a return type of IActionResult
16. Make the return of the `Index()` action `return View()`
17. Create a new folder named "Home" in our Views Folder.
18. Create a new .cshtml page in the Home folder that you just created
	a. Right click on Home Foldeer
	b. Add -> New Item ->
	c. search for "View" 
	d. select "Razor View"
	e. Name the View the same page as your action (Keep it Index for this example)
19. Add Text to your Index.cshtml file
20. Run the app and make sure it loads your Home page.
21. If it runs -> YAAY!, if not repeat step 1-20.

### Adding Entity Framework Core and a SQL Database:
1. Add an appsettings.json file 
	a. Right click on project --> Add -> new item
    2. search for appsettings
    3. Select appsettings.json
	b. Keep the name `appsettings.json`
    
2. Change the database name in your newly created connection string. 
3. Add a new folder named Data to your project
4. Create a new class in the data folder for your DbContext (i.e. DemoClass13DbContext)
5. Derive your new DbContext class from DbContext (i.e. `DemoClass13DbContext : DbContext`)
    a. Make sure you bring in the namespace Microsoft.EntityFrameworkCore
6. Create a new Constructor for your DbContext class and require the DbContextOptions parameter and have that constructor derive from the base
	a. Example Constructor looks like this:

```
public DemoClass13DbContext(DbContextOptions<DemoClass13DbContext> options) : base(options)
    {
	 
	}
		
```

7. Go to `Startup.cs`
8. Register our DbContext in our services. 
	a. Inside configureServices() add the following code:(Change out the name of the Context for your DbContext, as well as the "DefaultConnection" with your DefualtConnection name found in your appsettings.json file. 

```
 services.AddDbContext<DemoClass13DbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
	
9. We now setup our app to support depenency Injection, we do this by adding a constructor to our startup class that requires Iconfiguration. This is the conde for that:
```
    public Startup(IConfiguration configuration)
     {
	    
     }
```

10. Add a new property named Configuration that is of type IConfiguration.
11. Make sure you have added the following using statement:
```
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
```
	
12. Open up Package Manager Console.
13. Run the following Commands
	a. Install the EntityFrameworkCore Tools: Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.0
14. Add an initial migration to your project. Run the following command in PMC
	a. Add-Migration initial
15. After adding a migration, update your database with the "Update-Database" command. 
		


### MISC

1. When you start adding tables, make sure you do so in the DBContext file by adding a new `DBSet`. 
A DbSet would look like this:

```
public DbSet<MODELNAME> TABLENAME {get; set;}
```

2. Make sure that you add a new migration and update the database after every major change you make. 


