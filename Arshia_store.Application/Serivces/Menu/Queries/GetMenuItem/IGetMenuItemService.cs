using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Menu.Queries
{
	public interface IGetMenuItemService
	{
		ResultDto<List<MenuItemDto>> Execute();
	}

	public class GetMenuItemService : IGetMenuItemService
	{
		private readonly IStoreDbContext _context;

		public GetMenuItemService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<MenuItemDto>> Execute()
		{
			try
			{
				var result = _context.Categories
					.Where(p => p.ParentCategoryId == null)
					.Include(p => p.SubCategories)
					.Select(p => new MenuItemDto()
					{
						CategoryId = p.Id,
						Name = p.Name,
						MenuItems = p.SubCategories.Select(p => new MenuItemDto()
						{
							CategoryId = p.Id,
							Name = p.Name,
						}).ToList()
					})
					.ToList();

				return new ResultDto<List<MenuItemDto>>()
				{
					Data = result,
					IsSuccess = true,
					Message = "دسته بندی ها ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<List<MenuItemDto>>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new List<MenuItemDto>(),
				};
			}
		}
	}

	public class MenuItemDto
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public List<MenuItemDto> MenuItems { get; set; }
	}
}
