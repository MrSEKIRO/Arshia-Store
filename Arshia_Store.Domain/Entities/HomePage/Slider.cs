using Arshia_Store.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Domain.Entities.HomePage
{
	public class Slider : BaseEntity
	{
		public int Id { get; set; }
		public string Src { get; set; }
		public string Link { get; set; }
	}
}
