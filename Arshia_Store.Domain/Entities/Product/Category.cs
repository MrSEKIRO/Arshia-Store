using Arshia_Store.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Domain.Entities
{
	public class Category : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Category ParentCategory { get; set; }

		public int? ParentCategoryId { get; set; }

		public List<Category> SubCategories { get; set; }

		public List<Product> Products { get; set; }
	}
}
