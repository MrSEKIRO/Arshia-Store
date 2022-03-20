using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common;
using Arshia_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetProductsForSite
{
	public interface IGetProductsForSiteService
	{
		ResultDto<ResultProductForSiteDto> Execute(int Page = 1, int PageSize = 25);
	}

	public class GetProductsForSiteService : IGetProductsForSiteService
	{
		private readonly IStoreDbContext _context;

		public GetProductsForSiteService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<ResultProductForSiteDto> Execute(int Page = 1, int PageSize = 5)
		{
			try
			{
				int rowCount = 0;

				var products = _context.Products
					.Include(p => p.ProductImages)
					.ToPaged(Page, PageSize, out rowCount)
					.Select(p => new ProductForSiteDto()
					{
						Id = p.Id,
						Title = p.Name,
						Price = p.Price,
						// what if images are null ?
						ImageSrc = p.ProductImages.Count != 0 ? p.ProductImages.FirstOrDefault().Src : string.Empty,
						Star = 3,
					})
					.ToList();

				return new ResultDto<ResultProductForSiteDto>()
				{
					Data = new ResultProductForSiteDto()
					{
						Products = products,
						TotalRow = rowCount,
					},
					IsSuccess = true,
					Message = "کالا ها با موفقیت ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<ResultProductForSiteDto>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new ResultProductForSiteDto(),
				};
			}
		}
	}

	public class ResultProductForSiteDto
	{
		public List<ProductForSiteDto> Products { get; set; }
		public int TotalRow { get; set; }
	}

	public class ProductForSiteDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Price { get; set; }
		public string ImageSrc { get; set; }
		public int Star { get; set; }
	}
}
