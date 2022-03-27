using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories
{
	public class GetCategoriesService : IGetCategoriesService
	{
		private readonly IStoreDbContext _context;

		public GetCategoriesService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<CategoriesDto>> Execute(int? ParentId)
		{
			try
			{
				var categories = _context.Categories
					.Include(c => c.ParentCategory)
					.Include(c => c.SubCategories)
					.Where(c => c.ParentCategoryId == ParentId)
					.ToList()
					.Select(c => new CategoriesDto()
					{
						Id = c.Id,
						Name = c.Name,
						ParentCategoryDto = c.ParentCategory != null ? new ParentCategoryDto()
						{
							Id = (int)c.ParentCategoryId,
							Name = c.ParentCategory.Name,
						} : null,
						HasChild = c.SubCategories.Count() != 0,
					}).ToList();

				return new ResultDto<List<CategoriesDto>>()
				{
					Data = categories,
					IsSuccess = true,
					Message = "لیست با موفقیت برگشت داده شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<List<CategoriesDto>>()
				{
					IsSuccess = false,
					Data = new List<CategoriesDto>(),
					Message = e.Message,
				};
			}
		}
	}
}
