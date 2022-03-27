using Arshia_Store.Application.Interfaces.FacadPatterns;
using Arshia_Store.Application.Serivces.Products.Queries.GetProductsForSite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EndPoint.Site.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductFacad _productFacad;

		public ProductController(IProductFacad productFacad)
		{
			_productFacad = productFacad;
		}
		public IActionResult Index(Ordering ordering, string SearchKey, int Page = 1, int? CategoryId = null, int PageSize = 5)
		{
			var result = _productFacad.GetProductsForSiteService.Execute(ordering, SearchKey, Page, CategoryId, PageSize);

			return View(result.Data);
		}

		public IActionResult Detail(int ProductId)
		{
			var result = _productFacad.GetProductDetailForSite.Execute(ProductId);

			return View(result.Data);
		}
	}
}
