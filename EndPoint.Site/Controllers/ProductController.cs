using Arshia_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductFacad _productFacad;

		public ProductController(IProductFacad productFacad)
		{
			_productFacad = productFacad;
		}
		public IActionResult Index(int Page = 1, int PageSize = 25)
		{
			var result = _productFacad.GetProductsForSiteService.Execute(Page, PageSize);

			return View(result.Data);
		}

		public IActionResult Detail(int ProductId)
		{
			var result=_productFacad.GetProductDetailForSite.Execute(ProductId);

			return View(result.Data);
		}
	}
}
