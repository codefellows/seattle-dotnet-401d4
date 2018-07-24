using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusMall.Data;
using BusMall.Models;
using BusMall.Models.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusMall
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			var builder = new ConfigurationBuilder().AddEnvironmentVariables();
			builder.AddUserSecrets<Startup>();
			Configuration = builder.Build();
			//Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication().AddGoogle(google =>
			{
				google.ClientId = Configuration["Authentication:Google:ClientId"];
				google.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
			});

			services.AddDbContext<StoreDbContext>(options =>
			options.UseSqlServer(Configuration["ConnectionStrings:ProductionStoreDb"]));

			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration["ConnectionStrings:ProductionIdentity"]));

			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
				options.AddPolicy("CodefellowsOnly", policy => policy.Requirements
				.Add(new RequiredEmailRequirement("@codefellows.com")));
			});


			services.AddScoped<IInventory, DevInventory>();
			services.AddScoped<IAuthorizationHandler, RequiredEmailHandler>();
			services.AddScoped<IEmailSender, EmailSender>();

		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();
			app.UseStaticFiles();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
