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

		public IActionResult Index(int? ParentId)
		{
			var result=_productFacad.GetCategoriesService.Execute(ParentId);

			return View(result.Data);
		}

		[HttpGet]
		public IActionResult AddNewCategory(int? parentId)
		{
			ViewBag.parentId = parentId;
			return View();
		}

		[HttpPost]
		public IActionResult AddNewCategory(int? ParentId, string Name)
		{
			var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);

			return Json(result);
		}
	}
}
