using Arshia_Store.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Domain.Entities
{
	public class Product : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Display { get; set; } = true;
		public Category Category { get; set; }
		public int CategoryId { get; set; }

		public List<ProductImage> ProductImages { get; set; }
		public List<ProductFeature> ProductFeatures { get; set; }
	}
}
