using Arshia_Store.Application.Serivces.HomePages.Command.AddNewSlider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	public class SliderController : Controller
	{
		private readonly IAddNewSliderService _addNewSlider;

		public SliderController(IAddNewSliderService addNewSlider)
		{
			_addNewSlider = addNewSlider;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(IFormFile file, string link)
		{
			var result = _addNewSlider.Execute(file, link);

			// opens json on google we can use ajax instead
			return Json(result);
		}
	}
}
