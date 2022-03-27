using Arshia_Store.Domain.Commons;

namespace Arshia_Store.Domain.Entities
{
	public class ProductFeature : BaseEntity
	{
		public int Id { get; set; }
		public Product Product { get; set; }
		public int ProductId { get; set; }
		public string DisplayName { get; set; }
		public string Value { get; set; }
	}
}
