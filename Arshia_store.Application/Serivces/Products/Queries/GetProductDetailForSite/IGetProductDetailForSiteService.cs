using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForSite
{
	public interface IGetProductDetailForSiteService
	{
		ResultDto<ProductDetailForSiteDto> Execute(int ProductId);
	}

	public class GetProductDetailForSiteService : IGetProductDetailForSiteService
	{
		private readonly IStoreDbContext _context;

		public GetProductDetailForSiteService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<ProductDetailForSiteDto> Execute(int ProductId)
		{
			try
			{
				var product = _context.Products
					.Where(p => p.Id == ProductId)
					.Include(p => p.Category)
					.Include(p => p.ProductImages)
					.Include(p => p.ProductFeatures).AsQueryable();

				// add a view to product
				product.FirstOrDefault().ViewCount++;
				_context.SaveChanges();

				var productDetail = product
					.Select(p => new ProductDetailForSiteDto()
					{
						Id = p.Id,
						Title = p.Name,
						Brand = p.Brand,
						Category = p.Category.Name,
						Description = p.Description,
						Price = p.Price,
						Star = 3,
						Images = p.ProductImages.Select(image => image.Src).ToList(),
						Features = p.ProductFeatures.Select(feature => new ProductDetailForSite_FeaturesDto()
						{
							DisplayName = feature.DisplayName,
							Value = feature.Value,
						}).ToList(),
					}).FirstOrDefault();

				return new ResultDto<ProductDetailForSiteDto>()
				{
					Data = productDetail,
					IsSuccess = true,
					Message = "جزئیات کالا با موفقیت ارسال شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<ProductDetailForSiteDto>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new ProductDetailForSiteDto(),
				};
			};
		}

	}
	public class ProductDetailForSiteDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Brand { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Star { get; set; }
		public List<string> Images { get; set; } = new();
		public List<ProductDetailForSite_FeaturesDto> Features { get; set; } = new();
	}

	public class ProductDetailForSite_FeaturesDto
	{
		public string DisplayName { get; set; }
		public string Value { get; set; }
	}
}
