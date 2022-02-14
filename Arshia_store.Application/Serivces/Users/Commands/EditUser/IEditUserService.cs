using Arshia_Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Users.Commands.EditUser
{
	public interface IEditUserService
	{
		ResultDto Execute(int UserId, string FullName, string Email);
	}
}
