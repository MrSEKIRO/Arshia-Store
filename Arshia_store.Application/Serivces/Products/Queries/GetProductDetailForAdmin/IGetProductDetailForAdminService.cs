using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Arshia_Store.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin
{
	public interface IGetProductDetailForAdminService
	{
		ResultDto<ProductDetailDto> Execute(int ProductId);
	}

	public class GetProductDetailForAdminService : IGetProductDetailForAdminService
	{
		private readonly IStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetProductDetailForAdminService(IStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public ResultDto<ProductDetailDto> Execute(int ProductId)
		{
			try
			{
				var product = _context.Products
					.Where(p => p.Id == ProductId)
					.Include(p => p.Category)
					.ThenInclude(p => p.ParentCategory)
					.Include(p => p.ProductImages)
					.Include(p => p.ProductFeatures)
					.Select(p => _mapper.Map<ProductDetailDto>(p))
					.FirstOrDefault();

				return new ResultDto<ProductDetailDto>()
				{
					IsSuccess = true,
					Message = "جزئیات کالا با موفقیت دریافت شد",
					Data = product,
				};
			}
			catch(Exception e)
			{
				return new ResultDto<ProductDetailDto>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new ProductDetailDto(),
				};
			}

			//var product = _context.Products
			//		.Include(p => p.Category)
			//		.ThenInclude(p => p.ParentCategory)
			//		.Include(p => p.ProductImages)
			//		.Include(p => p.ProductFeatures)
			//		.Where(p => p.Id == ProductId)
			//		.FirstOrDefault();

			//var productDetail = _mapper.Map<ProductDetailDto>(product);

			//return new ResultDto<ProductDetailDto>()
			//{
			//	IsSuccess = true,
			//	Message = "جزئیات کالا با موفقیت دریافت شد",
			//	Data = productDetail,
			//};
		}
	}

	public class ProductDetailDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Display { get; set; } = true;
		public string Category { get; set; }
		public List<ProductDetailImageDto> Images { get; set; }
		public List<ProductDetailFeatureDto> Features { get; set; }
	}

	public class ProductDetailFeatureDto
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public string Value { get; set; }
	}

	public class ProductDetailImageDto
	{
		public int Id { get; set; }
		public string Src { get; set; }
	}
}
