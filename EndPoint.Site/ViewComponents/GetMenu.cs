using Arshia_Store.Application.Serivces.Menu.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
	public class GetMenu : ViewComponent
	{
		private readonly IGetMenuItemService _getMenuItemService;

		public GetMenu(IGetMenuItemService getMenuItemService)
		{
			_getMenuItemService = getMenuItemService;
		}

		public IViewComponentResult Invoke()
		{
			var menuItems = _getMenuItemService.Execute();
			return View(viewName: "GetMenu", menuItems.Data);
		}
	}
}
