using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Arshia_Store.Application.Serivces.Products.Commands.DeleteProduct;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForSite;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductsForSite;
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


		private IAddNewCategoryService _addNewCategoryService;
		public IAddNewCategoryService AddNewCategoryService
		{
			get
			{
				return _addNewCategoryService ??= new AddNewCategoryService(_context);
			}
		}

		private IGetCategoriesService _getCategoriesService;
		public IGetCategoriesService GetCategoriesService
		{
			get
			{
				return _getCategoriesService ??= new GetCategoriesService(_context);
			}
		}

		private IAddNewProductService _addNewProductService;
		public IAddNewProductService AddNewProductService
		{
			get
			{
				return _addNewProductService ??= new AddNewProductService(_context, _environment);
			}
		}

		private IGetAllCategoriesTypesService _getAllCategoriesTypes;
		public IGetAllCategoriesTypesService GetAllCategoriesTypes
		{
			get
			{
				return _getAllCategoriesTypes ??= new GetAllCategoriesTypesService(_context);
			}
		}

		private IGetProductForAdminService _getProductForAdminService;
		public IGetProductForAdminService GetProductForAdminService
		{
			get
			{
				return _getProductForAdminService ??= new GetProductForAdminService(_context, _mapper);
			}
		}

		private IGetProductDetailForAdminService _getProductDetailForAdminService;
		public IGetProductDetailForAdminService GetProductDetailForAdminService
		{
			get
			{
				return _getProductDetailForAdminService ??= new GetProductDetailForAdminService(_context, _mapper);
			}
		}

		private IDeleteProductService _deleteProductService;
		public IDeleteProductService DeleteProductService
		{
			get
			{
				return _deleteProductService ??= new DeleteProductService(_context);
			}
		}

		private IGetProductsForSiteService _getProductsForSiteService;
		public IGetProductsForSiteService GetProductsForSiteService
		{
			get
			{
				return _getProductsForSiteService ??= new GetProductsForSiteService(_context);
			}
		}

		private IGetProductDetailForSiteService _getProductDetailForSite;
		public IGetProductDetailForSiteService GetProductDetailForSite
		{
			get
			{
				return _getProductDetailForSite ??= new GetProductDetailForSiteService(_context);
			}
		}
	}
}
