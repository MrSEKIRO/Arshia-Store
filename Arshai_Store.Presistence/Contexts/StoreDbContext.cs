using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.UserRoles;
using Arshia_Store.Domain.Entities;
using Arshia_Store.Domain.Entities.HomePage;
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
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductFeature> ProductFeatures { get; set; }
		public DbSet<Slider> Sliders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

			// we don`t use EntityConfiguration here
			modelBuilder.Entity<Slider>().HasQueryFilter(u => u.IsRemoved == false);
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

	public class ProductTypeConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasQueryFilter(u=>u.IsRemoved == false);
		}
	}
	
	public class ProductImageTypeConfigurations : IEntityTypeConfiguration<ProductImage>
	{
		public void Configure(EntityTypeBuilder<ProductImage> builder)
		{
			builder.HasQueryFilter(u=>u.IsRemoved == false);
		}
	}
	
	public class ProductFeatureTypeConfigurations : IEntityTypeConfiguration<ProductFeature>
	{
		public void Configure(EntityTypeBuilder<ProductFeature> builder)
		{
			builder.HasQueryFilter(u=>u.IsRemoved == false);
		}
	}
}
