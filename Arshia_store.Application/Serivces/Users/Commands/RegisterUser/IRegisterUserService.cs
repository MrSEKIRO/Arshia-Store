using Arshia_Store.Common.Dto;

namespace Arshia_Store.Application.Serivces.Users.Commands.RegisterUser
{
	public interface IRegisterUserService
	{
		ResultDto<ResultRegisterUser> Execute(RequestRegisterUserDto requestRegisterUser);
	}
}
