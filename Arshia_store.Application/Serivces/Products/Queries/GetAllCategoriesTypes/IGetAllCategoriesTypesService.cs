using Arshia_Store.Common.Dto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes
{
	public interface IGetAllCategoriesTypesService
	{
		ResultDto<List<CategoriesTypeDto>> Execute();
	}
}
