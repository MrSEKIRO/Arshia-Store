using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Products.Commands.DeleteProduct
{
	public interface IDeleteProductService
	{
		ResultDto Execute(int ProductId);
	}

	public class DeleteProductService : IDeleteProductService
	{
		private readonly IStoreDbContext _context;

		public DeleteProductService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto Execute(int ProductId)
		{
			try
			{
				var product = _context.Products.Find(ProductId);

				if(product == null)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "کالا یافت نشد!",
					};
				}

				product.IsRemoved = true;
				product.RemoveTime = DateTime.Now;

				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = "کالا با موفقیت حذف شد",
				};
			}
			catch(Exception e)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = e.Message,
				};
			}
		}
	}
}
