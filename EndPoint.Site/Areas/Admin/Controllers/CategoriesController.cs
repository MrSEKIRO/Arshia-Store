using Arshia_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	public class CategoriesController : Controller
	{
		private readonly IProductFacad _productFacad;

		public CategoriesController(IProductFacad productFacad)
		{
			_productFacad = productFacad;
		}

		public IActionResult AddNewCategory(int? parentId)
		{
			ViewBag.parentId = parentId;
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
