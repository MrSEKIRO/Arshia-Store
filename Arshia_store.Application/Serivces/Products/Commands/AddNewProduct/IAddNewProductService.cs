using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Validatores;
using Arshia_Store.Common.Dto;
using Arshia_Store.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct
{
	public interface IAddNewProductService
	{
		ResultDto Execute(RequestAddNewProductDto requestAddProduct);
	}

	public class AddNewProductService : IAddNewProductService
	{
		private readonly IStoreDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public AddNewProductService(IStoreDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}
		public ResultDto Execute(RequestAddNewProductDto requestAddProduct)
		{
			try
			{
				AddNewProductValidatore validationRules = new AddNewProductValidatore();
				var validationResult= validationRules.Validate(requestAddProduct);

				if(validationResult.IsValid == false)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = validationResult.Errors[0].ErrorMessage,
					};
				}

				var category = _context.Categories.Find(requestAddProduct.CategoryId);

				var product = new Product()
				{
					Name = requestAddProduct.Name,
					Brand = requestAddProduct.Brand,
					Description = requestAddProduct.Description,
					Price = requestAddProduct.Price,
					Inventory = requestAddProduct.Inventory,
					Display = requestAddProduct.Display,
					Category = category,
				};


				_context.Products.Add(product);

				List<ProductImage> productImages = ExtractImages(requestAddProduct, product, _environment);
				_context.ProductImages.AddRange(productImages);

				List<ProductFeature> productFeatures = ExtractFeatures(requestAddProduct, product);
				_context.ProductFeatures.AddRange(productFeatures);

				_context.SaveChanges();
				return new ResultDto()
				{
					IsSuccess = true,
					Message = "کالا با موفقیت اضافه شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = e.Message,
				};
			}
		}

		private static List<ProductFeature> ExtractFeatures(RequestAddNewProductDto requestAddProduct, Product product)
		{
			List<ProductFeature> productFeatures = new List<ProductFeature>();
			foreach(var item in requestAddProduct.Features)
			{
				productFeatures.Add(new ProductFeature()
				{
					DisplayName = item.DisplayName,
					Value = item.Value,
					Product = product,
				});
			}

			return productFeatures;
		}

		private static List<ProductImage> ExtractImages(RequestAddNewProductDto requestAddProduct, Product product, IWebHostEnvironment environment)
		{
			List<ProductImage> productImages = new List<ProductImage>();
			foreach(var item in requestAddProduct.Images)
			{
				var uploadResult = UploadFile(item, environment);
				productImages.Add(new ProductImage()
				{
					Product = product,
					Src = uploadResult.FileNameAddress,
				});
			}

			return productImages;
		}

		private static UploadDto UploadFile(IFormFile file, IWebHostEnvironment environment)
		{
			if(file != null)
			{
				string folder = $@"images\ProductImages\";
				var uploadsRootFolder = Path.Combine(environment.WebRootPath, folder);
				if(Directory.Exists(uploadsRootFolder) == false)
				{
					Directory.CreateDirectory(uploadsRootFolder);
				}

				if(file == null || file.Length == 0)
				{
					return new UploadDto()
					{
						Status = false,
						FileNameAddress = string.Empty,
					};
				}

				string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
				var filePath = Path.Combine(uploadsRootFolder, fileName);
				using(var fileStream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				return new UploadDto()
				{
					Status = true,
					FileNameAddress = folder + fileName,
				};
			}
			else
			{
				return new UploadDto()
				{
					Status = false,
					FileNameAddress = String.Empty,
				};
			}
		}
	}

	public class UploadDto
	{
		public bool Status { get; set; }
		public string FileNameAddress { get; set; }
	}

	public class RequestAddNewProductDto
	{
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Display { get; set; } = true;

		public int CategoryId { get; set; }

		public List<AddNewProduct_Feature> Features { get; set; }
		public List<IFormFile> Images { get; set; }
	}

	public class AddNewProduct_Feature
	{
		public string DisplayName { get; set; }
		public string Value { get; set; }
	}
}
