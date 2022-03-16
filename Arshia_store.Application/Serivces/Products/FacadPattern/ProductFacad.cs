using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.FacadPattern
{
	public class ProductFacad : IProductFacad
	{
		private readonly IStoreDbContext _context;
		public ProductFacad(IStoreDbContext context)
		{
			_context = context;
		}


		private AddNewCategoryService _AddNewCategoryService;
		public AddNewCategoryService AddNewCategoryService
		{
			get
			{
				return _AddNewCategoryService ?? (_AddNewCategoryService = new AddNewCategoryService(_context));
			}
		}
	}
}
