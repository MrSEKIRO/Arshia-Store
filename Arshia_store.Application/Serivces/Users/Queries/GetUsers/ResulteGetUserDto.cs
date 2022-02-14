using System.Collections.Generic;

namespace Arshia_Store.Application.Serivces.Users.Queries.GetUsers
{
	public class ResulteGetUserDto
	{
		public List<GetUsersDto> Users { get; set; }
		public int Rows { get; set; }
	}
}
