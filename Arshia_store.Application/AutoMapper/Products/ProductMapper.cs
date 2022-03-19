using Arshia_Store.Application.Serivces.Products.Queries.GetProductDetailForAdmin;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductForAdmin;
using Arshia_Store.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.AutoMapper.Products
{
	public class ProductMapper : Profile
	{
		public ProductMapper()
		{
			CreateMap<Product, ProductForAdminDto>()
				.ForMember(p => p.Category,
				opt => opt.MapFrom(p => p.Category.Name));

			CreateMap<ProductImage, ProductDetailImageDto>();

			CreateMap<ProductFeature, ProductDetailFeatureDto>();

			CreateMap<Product, ProductDetailDto>()
				.ForMember(p=>p.Category,
				opt=> opt.MapFrom(p=> GetCategory(p.Category)))
				.ForMember(p => p.Features,
				opt => opt.MapFrom(p =>  p.ProductFeatures))
				.ForMember(p => p.Images,
				opt => opt.MapFrom(p => p.ProductImages));
		}

		private string GetCategory(Category category)
		{
			string result = string.Empty;
			if(category.ParentCategory != null)
			{
				result += $"{category.ParentCategory.Name} - ";
			}
			result += category.Name;

			return result;
		}
	}
}
