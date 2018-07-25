using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cohort4ECommerce.Data;
using Cohort4ECommerce.Models;
using Cohort4ECommerce.Models.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cohort4ECommerce
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddDbContext<CMSDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("Over21", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
				options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
				options.AddPolicy("HasFavColor", policy => policy.RequireClaim("FavoriteColor"));
			});

			services.AddScoped<ICMSRepo, DevCMSRepo>();
			services.AddScoped<ITitleService, TitleService>();

			services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseStaticFiles();

			app.UseMvcWithDefaultRoute();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
