namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories
{
	//public record ParentCategoryDto(int Id,string Name);
	public record ParentCategoryDto
	{
		public int Id { get; init; }
		public string Name { get; init; }
	}
}
