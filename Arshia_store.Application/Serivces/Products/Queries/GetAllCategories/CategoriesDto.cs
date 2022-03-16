namespace Arshia_Store.Application.Serivces.Products.Queries.GetAllCategories
{
	//public record CategoriesDto(int Id,string Name,bool HasChild,ParentCategoryDto ParentCategoryDto);
	public record CategoriesDto
	{
		public int Id { get; init; }
		public string Name { get; init; }
		public bool HasChild { get; init; }
		public ParentCategoryDto ParentCategoryDto { get; init; }
	}
}
