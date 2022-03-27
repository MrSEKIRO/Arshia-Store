using Arshia_Store.Domain.Commons;

namespace Arshia_Store.Domain.Entities
{
	public class ProductImage : BaseEntity
	{
		public int Id { get; set; }
		public Product Product { get; set; }
		public int ProductId { get; set; }
		public string Src { get; set; }
	}
}
