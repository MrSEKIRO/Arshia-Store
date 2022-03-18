using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	public class ProductsController : Controller
	{
		private readonly IProductFacad _productFacad;

		public ProductsController(IProductFacad productFacad)
		{
			_productFacad = productFacad;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult AddNewProduct()
		{
			var result = _productFacad.GetAllCategoriesTypes.Execute();
			ViewBag.Categories = new SelectList(result.Data, "Id", "Name");

			return View();
		}

		[HttpPost]
		public IActionResult AddNewProduct(RequestAddNewProductDto request,List<AddNewProduct_Feature> Features)
		{
			List<IFormFile> Images = new List<IFormFile>();

			for(int i = 0; i < Request.Form.Files.Count; i++)
			{
				var file = Request.Form.Files[i];
				Images.Add(file);
			}

			request.Images = Images;
			request.Features = Features;

			var result = _productFacad.AddNewProductService.Execute(request);

			return Json(result);
		}
	}
}
