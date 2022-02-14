using System.Collections.Generic;

namespace Arshia_Store.Application.Serivces.Users.Commands.RegisterUser
{
	public class RequestRegisterUserDto
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RePassword { get; set; }
		public List<RolesInRegisterUserDto> roles { get; set; }
	}
}
