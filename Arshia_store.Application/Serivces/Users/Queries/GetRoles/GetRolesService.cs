using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Users.Queries.GetRoles
{
	public class GetRolesService : IGetRolesService
	{
		private readonly IStoreDbContext _context;
		public GetRolesService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<RolesDto>> Execute()
		{
			var roles= _context.Roles.Select(r => new RolesDto
			{
				Id=r.Id,
				Name = r.Name,
			}).ToList();

			return new ResultDto<List<RolesDto>>()
			{
				Data = roles,
				IsSuccess = true,
				Message = "roles delivers",
			};
		}
	}
}
