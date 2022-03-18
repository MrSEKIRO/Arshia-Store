using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategoriesTypes
{
	public class GetAllCategoriesTypes : IGetAllCategoriesTypes
	{
		private readonly IStoreDbContext _context;

		public GetAllCategoriesTypes(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<CategoriesTypeDto>> Execute()
		{
			try
			{
				var result = _context.Categories
					.Include(c => c.ParentCategory)
					.Where(c => c.ParentCategoryId != null)
					.ToList()
					.Select(c => new CategoriesTypeDto(c.Id, c.Name + "-" + c.ParentCategory.Name))
					.ToList();

				return new ResultDto<List<CategoriesTypeDto>>()
				{
					IsSuccess = true,
					Data = result,
					Message = "دسته بندی های مختلف ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<List<CategoriesTypeDto>>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new List<CategoriesTypeDto>(),
				};
			}

		}
	}
}
