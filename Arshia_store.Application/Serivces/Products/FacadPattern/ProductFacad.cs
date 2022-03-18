using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes;
using Microsoft.AspNetCore.Hosting;

namespace Arshia_Store.Application.Serivces.Products.FacadPattern
{
	public class ProductFacad : IProductFacad
	{
		private readonly IStoreDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public ProductFacad(IStoreDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
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

		private AddNewProductService _AddNewProductService;
		public AddNewProductService AddNewProductService
		{
			get
			{
				return _AddNewProductService ??= new AddNewProductService(_context, _environment);
			}
		}

		private GetAllCategoriesTypes _GetAllCategoriesTypes;
		public GetAllCategoriesTypes GetAllCategoriesTypes
		{
			get
			{
				return _GetAllCategoriesTypes ??= new GetAllCategoriesTypes(_context);
			}
		}
	}
}
