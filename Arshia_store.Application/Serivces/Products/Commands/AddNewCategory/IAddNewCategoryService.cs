using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Arshia_Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.AddNewCategory
{
	public interface IAddNewCategoryService
	{
		ResultDto Execute(int? parentId, string name);
	}

	public class AddNewCategoryService : IAddNewCategoryService
	{
		private readonly IStoreDbContext _context;

		public AddNewCategoryService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto Execute(int? parentId, string name)
		{
			if(string.IsNullOrEmpty(name) == true)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "لطفا نام را وارد کنید",
				};
			}

			var parent = _context.Categories.Find(parentId);

			Category category = new Category()
			{
				Name = name,
				ParentCategory = parent,
			};

			_context.Categories.Add(category);
			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "دسته بندی با موفقیت اضافه شد",
			};
		}
	}
}
