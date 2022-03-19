using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Arshia_Store.Application.Serivces.Products.Commands.DeleteProduct;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Interfaces.FacadPatterns
{
	public interface IProductFacad
	{
		AddNewCategoryService AddNewCategoryService { get; }
		GetCategoriesService GetCategoriesService { get; }
		AddNewProductService AddNewProductService { get; }

		/// <summary>
		/// Return CategoryParentName-CategorName List
		/// </summary>
		GetAllCategoriesTypesService GetAllCategoriesTypes { get; }

		/// <summary>
		/// Return Products for Admin part 
		/// </summary>
		GetProductForAdminService GetProductForAdminService { get; }

		/// <summary>
		/// Return Details of Specified Product
		/// </summary>
		GetProductDetailForAdminService GetProductDetailForAdminService { get; }

		/// <summary>
		/// Delete Spesified Product by Id
		/// </summary>
		DeleteProductService DeleteProductService { get; }
	}
}
