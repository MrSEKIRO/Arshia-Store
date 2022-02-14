using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Users.Queries.GetRoles
{
	public interface IGetRolesService
	{
		ResultDto<List<RolesDto>> Execute();
	}
}
