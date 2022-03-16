using Arshia_Store.Application.Serivces.Products.AddNewCategory;
using Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories;
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
	}
}
