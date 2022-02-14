using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Domain.Entities;
using FluentValidation;

namespace Arshia_Store.Application.Validatores
{
	public class RegisterUserValidatore : AbstractValidator<RequestRegisterUserDto>
	{
		public RegisterUserValidatore()
		{
			RuleFor(u => u.FullName)
				.NotEmpty().WithMessage("لطفا نام را وارد کنید")
				.MinimumLength(3).WithMessage("لطفا نام را کامل وارد کنید")
				.MaximumLength(30).WithMessage("اسم باید زیر 30 کاراکتر باشد");

			RuleFor(u => u.Email)
				.NotEmpty().WithMessage("ایمیل را وارد کنید")
				.EmailAddress().WithMessage("ایمیل صحیح نیست");

			RuleFor(u => u.Password)
				.NotEmpty().WithMessage("لطفا رمز خود را وارد کنید")
				.MinimumLength(5).WithMessage("پسورد باید حداقل شامل 5 کاراکتر باشد")
				.MaximumLength(12).WithMessage("رمز باید زیر 12 کاراکتر باشد");

			RuleFor(u => u.RePassword)
				.NotEmpty().WithMessage("لطفا  تکرار رمز خود را وارد کنید")
				.Equal(u => u.Password).WithMessage("رمز عبور و تکرار آن برابر نیست");
		}
	}
}
