﻿using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.UserRoles;
using Arshia_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arshai_Store.Presistence.Contexts
{
	public class StoreDbContext : DbContext, IStoreDbContext
	{
		public StoreDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
		}
	}

	public class UserEntityTypeConfigurations : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			// make emails unique
			builder.HasIndex(u => u.Email).IsUnique();

			// show only un-removed users
			builder.HasQueryFilter(u => u.IsRemoved == false);
		}
	}

	public class RoleEntityTypeConfigurations : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			// making defualte roles
			builder.HasData(new Role { Id = (int)UserRoles.Admin, Name = UserRoles.Admin.ToString() });
			builder.HasData(new Role { Id = (int)UserRoles.Operator, Name = UserRoles.Operator.ToString() });
			builder.HasData(new Role { Id = (int)UserRoles.Costumer, Name = UserRoles.Costumer.ToString() });

			// show only un-removed roles
			builder.HasQueryFilter(u => u.IsRemoved == false);
		}
	}

	public class CategoryTypeConfigurations : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasQueryFilter(u=>u.IsRemoved == false);

		}
	}
}
