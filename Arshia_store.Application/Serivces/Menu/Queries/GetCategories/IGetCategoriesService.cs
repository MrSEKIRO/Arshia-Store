using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Menu.Queries.GetCategories
{
	public interface IGetCategoriesService
	{
		public ResultDto<List<CategoryDto>> Execute();
	}

	public class GetCategoriesService : IGetCategoriesService
	{
		private readonly IStoreDbContext _context;

		public GetCategoriesService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<CategoryDto>> Execute()
		{
			try
			{
				var categories = _context.Categories
					.Where(c => c.ParentCategoryId == null)
					.Select(c => new CategoryDto()
					{
						Id = c.Id,
						Name = c.Name,
					})
					.ToList();

				return new ResultDto<List<CategoryDto>>()
				{
					IsSuccess = true,
					Data = categories,
					Message = "دسته بندی ها با موفقیت ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<List<CategoryDto>>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new List<CategoryDto>(),
				};
			}
		}
	}
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
