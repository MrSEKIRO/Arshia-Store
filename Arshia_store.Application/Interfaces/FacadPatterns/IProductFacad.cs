using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Arshia_Store.Application.Serivces.Products.Commands.DeleteProduct;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForSite;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Interfaces.FacadPatterns
{
	public interface IProductFacad
	{
		IAddNewCategoryService AddNewCategoryService { get; }
		IGetCategoriesService GetCategoriesService { get; }
		IAddNewProductService AddNewProductService { get; }

		/// <summary>
		/// Return CategoryParentName-CategorName List
		/// </summary>
		IGetAllCategoriesTypesService GetAllCategoriesTypes { get; }

		/// <summary>
		/// Return Products for Admin part 
		/// </summary>
		IGetProductForAdminService GetProductForAdminService { get; }

		/// <summary>
		/// Return Details of Specified Product
		/// </summary>
		IGetProductDetailForAdminService GetProductDetailForAdminService { get; }

		/// <summary>
		/// Delete Spesified Product by Id
		/// </summary>
		IDeleteProductService DeleteProductService { get; }

		/// <summary>
		/// Return List of Titles,Picture,Star of Products
		/// </summary>
		IGetProductsForSiteService GetProductsForSiteService { get; }

		/// <summary>
		/// Return Details of product for specified product in site
		/// </summary>
		IGetProductDetailForSiteService GetProductDetailForSite { get; }
	}
}
