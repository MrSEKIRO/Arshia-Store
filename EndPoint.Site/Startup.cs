using Arshai_Store.Presistence.Contexts;
using Arshia_Store.Application.AutoMapper.Products;
using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.FacadPattern;
using Arshia_Store.Application.Serivces.Users.Commands.EditUser;
using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Serivces.Users.Commands.RemoveUser;
using Arshia_Store.Application.Serivces.Users.Commands.UserStatusChange;
using Arshia_Store.Application.Serivces.Users.Queries.GetRoles;
using Arshia_Store.Application.Serivces.Users.Queries.GetUsers;
using Arshia_Store.Application.Serivces.Users.Queries.UserLogin;
using Arshia_Store.Application.Validatores;
using Arshia_Store.Common.UserRoles;
using EndPoint.Site.AuthenticationPolicies;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;

namespace EndPoint.Site
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();

			services.AddAuthentication(options =>
			{
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			}).AddCookie(options =>
			{
				options.LoginPath = new PathString("/Authentication/SignIn");
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
			});

			// Just Admins can use this side
			services.AddAuthorization(options =>
			{
				options.AddPolicy(nameof(AdminRequirement) , policy =>
				{
					policy.Requirements.Add(new AdminRequirement(UserRoles.Admin.ToString()));
				});
			});


			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			// Fluent Validation
			services.AddMvc().AddFluentValidation();
			services.AddTransient<IValidator<RequestRegisterUserDto>, RegisterUserValidatore>();

			// Costum Policy Authorization
			services.AddSingleton<IAuthorizationHandler, AdminHandler>();

			services.AddScoped<IStoreDbContext, StoreDbContext>();
			services.AddScoped<IGetUsersService, GetUsersService>();
			services.AddScoped<IGetRolesService, GetRolesService>();
			services.AddScoped<IRegisterUserService, RegisterUserService>();
			services.AddScoped<IRemoveUserSerivce, RemoveUserService>();
			services.AddScoped<IUserStatusChange, UserStatusChange>();
			services.AddScoped<IEditUserService, EditUserService>();
			services.AddScoped<IUserLoginService, UserLoginService>();

			// Facad Inject for Products
			services.AddScoped<IProductFacad, ProductFacad>();

			// AutoMapper for Product to ProductForAdmin
			services.AddAutoMapper(typeof(ProductMapper).Assembly);

			// Add EF Core
			services.AddEntityFrameworkSqlServer()
				.AddDbContext<StoreDbContext>(option => option.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				// For see changes after save imediately
				//app.UseDirectoryBrowser();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();

				// Products/Index.cshtml line 46
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName:"Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);

				endpoints.MapControllerRoute(
					name: "areas",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				//endpoints.MapControllerRoute(
				//	name: "areas",
				//	pattern: "{controller=Authentication}/{action=SignUp}/{id?}"
				//);
			});
		}
	}
}
