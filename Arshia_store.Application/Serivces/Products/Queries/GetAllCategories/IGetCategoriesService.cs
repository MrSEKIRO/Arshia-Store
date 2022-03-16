using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories
{
	public interface IGetCategoriesService
	{
		ResultDto<List<CategoriesDto>> Execute(int? ParentId);
	}
}
