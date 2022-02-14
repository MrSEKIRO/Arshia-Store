namespace Arshia_Store.Application.Serivces.Users.Queries.GetUsers
{
	public class GetUsersDto
	{
		public long Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }
	}
}
