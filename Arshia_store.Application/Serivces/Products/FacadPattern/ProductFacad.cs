using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;

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
				return _AddNewCategoryService ??= new AddNewCategoryService(_context);
			}
		}

		private GetCategoriesService _GetCategoriesService;
		public GetCategoriesService GetCategoriesService
		{
			get
			{
				return _GetCategoriesService ??= new GetCategoriesService(_context);
			}
		}
	}
}
