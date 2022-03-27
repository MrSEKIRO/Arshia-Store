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
		ResultDto<ResultProductForSiteDto> Execute(Ordering ordernig, string SearchKey, int Page = 1, int? CategoryId = null, int PageSize = 5);
	}

	public enum Ordering
	{
		NotOrder,
		/// <summary>
		/// پر بازدید ترین
		/// </summary>
		MostVisited,
		/// <summary>
		/// پر فروش ترین
		/// </summary>
		BestSelling,
		MostPopular,
		TheNewest,
		Cheapest,
		MostExpensive,
	}

	public class GetProductsForSiteService : IGetProductsForSiteService
	{
		private readonly IStoreDbContext _context;

		public GetProductsForSiteService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<ResultProductForSiteDto> Execute(Ordering ordernig, string SearchKey, int Page = 1, int? CategoryId = null, int PageSize = 5)
		{
			try
			{
				int rowCount = 0;

				var allProducts = _context.Products
					.Include(p => p.ProductImages)
					.Include(p => p.Category)
					.AsQueryable();

				if(CategoryId != null)
				{
					allProducts = allProducts.Where(p => p.CategoryId == CategoryId || p.Category.ParentCategoryId == CategoryId).AsQueryable();
				}

				if(string.IsNullOrEmpty(SearchKey) == false)
				{
					allProducts = allProducts.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey)).AsQueryable();
				}

				if(ordernig != Ordering.NotOrder)
				{
					switch(ordernig)
					{
						case Ordering.MostVisited:
							allProducts = allProducts.OrderByDescending(p => p.ViewCount).AsQueryable();
							break;
						// not implemented correctlly
						case Ordering.BestSelling:
							//allProducts = allProducts.OrderBy(p => p.Inventory).AsQueryable();
							break;
						case Ordering.MostPopular:
							//allProducts = allProducts.OrderByDescending(p => p.).AsQueryable();
							break;
						case Ordering.TheNewest:
							allProducts = allProducts.OrderByDescending(p => p.InsertTime).AsQueryable();
							break;
						case Ordering.Cheapest:
							allProducts = allProducts.OrderBy(p => p.Price).AsQueryable();
							break;
						case Ordering.MostExpensive:
							allProducts = allProducts.OrderByDescending(p => p.Price).AsQueryable();
							break;
						default:
							break;
					}
				}

				var products = allProducts
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
