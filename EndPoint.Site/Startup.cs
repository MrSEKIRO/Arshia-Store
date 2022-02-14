using Arshai_Store.Presistence.Contexts;
using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Serivces.Users.Commands.RemoveUser;
using Arshia_Store.Application.Serivces.Users.Commands.UserStatusChange;
using Arshia_Store.Application.Serivces.Users.Queries.GetRoles;
using Arshia_Store.Application.Serivces.Users.Queries.GetUsers;
using Arshia_Store.Application.Validatores;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			services.AddMvc().AddFluentValidation();
			services.AddTransient<IValidator<RequestRegisterUserDto>, RegisterUserValidatore>();

			services.AddScoped<IStoreDbContext, StoreDbContext>();
			services.AddScoped<IGetUsersService, GetUsersService>();
			services.AddScoped<IGetRolesService, GetRolesService>();
			services.AddScoped<IRegisterUserService, RegisterUserService>();
			services.AddScoped<IRemoveUserSerivce, RemoveUserService>();
			services.AddScoped<IUserStatusChange, UserStatusChange>();

			services.AddEntityFrameworkSqlServer()
				.AddDbContext<StoreDbContext>(option => option.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			
				endpoints.MapControllerRoute(
					name: "areas",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});
		}
	}
}
