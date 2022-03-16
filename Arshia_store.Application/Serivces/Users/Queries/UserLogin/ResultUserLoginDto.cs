namespace Arshia_Store.Application.Serivces.Users.Queries.UserLogin
{
	public class ResultUserLoginDto
	{
		public int UserId { get; set; }
		public string FullName { get; set; }

		// string of roles together
		// ex : UserAdmin
		public string Roles { get; set; }
	}
}
