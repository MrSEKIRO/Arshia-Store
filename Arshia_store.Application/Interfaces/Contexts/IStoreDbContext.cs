using Arshia_Store.Domain.Entities;
using Arshia_Store.Domain.Entities.HomePage;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Interfaces.Contexts
{
	public interface IStoreDbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Role> Roles { get; set; }
		DbSet<Category> Categories { get; set; }
		DbSet<Product> Products { get; set; }
		DbSet<ProductImage> ProductImages { get; set; }
		DbSet<ProductFeature> ProductFeatures { get; set; }
		DbSet<Slider> Sliders { get; set; }
		int SaveChanges(bool acceptAllChangesOnSuccess);
		int SaveChanges();

		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
