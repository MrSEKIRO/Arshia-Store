using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Domain.Commons
{
	public abstract class BaseEntity
	{
		public DateTime InsertTime { get; set; } = DateTime.Now;
		public DateTime? UpdateTime { get; set; }
		public bool IsRemoved { get; set; } = false;
		public DateTime? RemoveTime { get; set; }
	}

}
