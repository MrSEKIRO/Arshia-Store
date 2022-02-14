using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Users.Queries.GetUsers
{
	public class GetUsersService : IGetUsersService
	{
		private readonly IStoreDbContext _context;
		public GetUsersService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResulteGetUserDto Execute(RequestGetUserDto request)
		{
			var users = _context.Users.AsQueryable();

			if(string.IsNullOrWhiteSpace(request.SearchKey) == false)
			{
				users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
			}

			int rowsCount = 0;

			var userList = users.ToPaged(request.Page, 20, out rowsCount)
				.Select(p => new GetUsersDto
				{
					Id = p.Id,
					FullName = p.FullName,
					Email = p.Email,
					IsActive = p.IsActive,
				}).ToList();

			return new ResulteGetUserDto()
			{
				Users = userList,
				Rows = rowsCount,
			};
		}
	}
}
