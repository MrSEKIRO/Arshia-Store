using Arshia_Store.Application.Serivces.Menu.Queries;
using Arshia_Store.Application.Serivces.Menu.Queries.GetCategories;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
	public class SearchBarMenu : ViewComponent
	{
		private readonly IGetCategoriesService _getCategoriesService;

		public SearchBarMenu(IGetCategoriesService getCategoriesService)
		{
			_getCategoriesService = getCategoriesService;
		}
		public IViewComponentResult Invoke()
		{
			var result = _getCategoriesService.Execute();

			return View(viewName: "SearchBarMenu", result.Data);
		}
	}
}
