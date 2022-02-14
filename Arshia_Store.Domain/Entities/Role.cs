using Arshia_Store.Domain.Commons;
using System.Collections.Generic;

namespace Arshia_Store.Domain.Entities
{
	public class Role : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<User> Users { get; set; }
	}
}
