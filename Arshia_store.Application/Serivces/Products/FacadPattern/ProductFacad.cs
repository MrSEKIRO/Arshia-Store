using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Arshia_Store.Application.Serivces.Products.Commands.DeleteProduct;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace Arshia_Store.Application.Serivces.Products.FacadPattern
{
	public class ProductFacad : IProductFacad
	{
		private readonly IStoreDbContext _context;
		private readonly IWebHostEnvironment _environment;
		private readonly IMapper _mapper;

		public ProductFacad(IStoreDbContext context, IWebHostEnvironment environment, IMapper mapper)
		{
			_context = context;
			_environment = environment;
			_mapper = mapper;
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

		private GetAllCategoriesTypesService _GetAllCategoriesTypes;
		public GetAllCategoriesTypesService GetAllCategoriesTypes
		{
			get
			{
				return _GetAllCategoriesTypes ??= new GetAllCategoriesTypesService(_context);
			}
		}

		private GetProductForAdminService _GetProductForAdminService;
		public GetProductForAdminService GetProductForAdminService
		{
			get
			{
				return _GetProductForAdminService ??= new GetProductForAdminService(_context, _mapper);
			}
		}

		private GetProductDetailForAdminService _GetProductDetailForAdminService;
		public GetProductDetailForAdminService GetProductDetailForAdminService
		{
			get
			{
				return _GetProductDetailForAdminService ??= new GetProductDetailForAdminService(_context, _mapper);
			}
		}

		private DeleteProductService _DeleteProductService;
		public DeleteProductService DeleteProductService
		{
			get
			{
				return _DeleteProductService ??= new DeleteProductService(_context);
			}
		}

	}
}
