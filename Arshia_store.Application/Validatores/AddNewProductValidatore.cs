using Arshia_Store.Application.Serivces.Products.Commands.AddNewProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Validatores
{
	public class AddNewProductValidatore : AbstractValidator<RequestAddNewProductDto>
	{
		public AddNewProductValidatore()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("اسم محصول را وارد کنید")
				.MinimumLength(3).WithMessage("نام محصول باید حداقل 3 کاراکتر باشد")
				.MaximumLength(45).WithMessage("نام محصول می تواند حداکثر 45 کاراکتر باشد");
			
			RuleFor(x => x.Brand)
				//.NotEmpty().WithMessage("")
				//.MinimumLength(3).WithMessage("")
				.MaximumLength(35).WithMessage("برند محصول می تواند حداکثز 35 کاراکتر باشد");

			RuleFor(x => x.Price).NotEmpty().WithMessage("قیمت محصول را وارد کنید")
				.GreaterThanOrEqualTo(0).WithMessage("قیمت محصول باید بزگرتر مساوی 0 باشد");

			RuleFor(x => x.Inventory)
				.GreaterThanOrEqualTo(0).WithMessage("تعدا محصولات موجود باید بزرگتر یا مساوی 0 باشد ");
		}
	}
}
