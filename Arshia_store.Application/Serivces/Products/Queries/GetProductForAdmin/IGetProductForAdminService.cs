using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common;
using Arshia_Store.Common.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin
{
	public interface IGetProductForAdminService
	{
		ResultDto<AllProductsForAdminDto> Execute(int Page = 1, int PageSize = 20);
	}

	public class GetProductForAdminService : IGetProductForAdminService
	{
		private readonly IStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetProductForAdminService(IStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public ResultDto<AllProductsForAdminDto> Execute(int Page = 1, int PageSize = 20)
		{
			try
			{
				int rowCount = 0;
				var products = _context.Products
					.Include(p => p.Category)
					.ToPaged(Page, PageSize, out rowCount)
					// Using AutoMapper instead of hard code
					.Select(p => _mapper.Map<ProductForAdminDto>(p))
					.ToList();


				return new ResultDto<AllProductsForAdminDto>()
				{
					Data = new AllProductsForAdminDto()
					{
						CurrentPage = Page,
						PageSize = PageSize,
						RowCount = rowCount,
						Products = products,
					},
					IsSuccess = true,
					Message = "کالا ها ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<AllProductsForAdminDto>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new AllProductsForAdminDto(),
				};
			}
		}
	}

	public class AllProductsForAdminDto
	{
		public int RowCount { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public List<ProductForAdminDto> Products { get; set; }
	}

	public class ProductForAdminDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Display { get; set; } = true;
		public string Category { get; set; }
	}
}
