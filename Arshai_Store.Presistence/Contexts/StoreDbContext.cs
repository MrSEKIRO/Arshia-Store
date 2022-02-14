using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.UserRoles;
using Arshia_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arshai_Store.Presistence.Contexts
{
	public class StoreDbContext : DbContext, IStoreDbContext
	{
		public StoreDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// making defualte roles
			modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Costumer) });

			// make emails unique
			modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

			// show only un-removed users
			modelBuilder.Entity<User>().HasQueryFilter(u => u.IsRemoved == false);
		}
	}
}
