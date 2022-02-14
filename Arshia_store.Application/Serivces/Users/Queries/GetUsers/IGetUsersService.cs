using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Users.Queries.GetUsers
{
	public interface IGetUsersService
	{
		ResulteGetUserDto Execute(RequestGetUserDto request);
	}
}
