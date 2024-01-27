using FluentValidation;
using PresentationLayer.Models.ViewModels.AppUserVMs;

namespace PresentationLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserSignUpValidator : AbstractValidator<AppUserSignUpVM>
    {
        public AppUserSignUpValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please enter your name !");
            RuleFor(user => user.Name).MaximumLength(30).WithMessage("Name is up to 30 characters can be entered !");
            RuleFor(user => user.Name).MinimumLength(3).WithMessage("Minimum 3 characters can be entered for name !");

            RuleFor(user => user.Surname).NotEmpty().WithMessage("Please enter your surname !");
            RuleFor(user => user.Surname).MaximumLength(30).WithMessage("Surname is up to 30 characters can be entered !");
            RuleFor(user => user.Surname).MinimumLength(3).WithMessage("Minimum 3 characters can be entered for surname !");

            RuleFor(user => user.Username).NotEmpty().WithMessage("Please enter your username !");
            RuleFor(user => user.Username).MaximumLength(20).WithMessage("Username is up to 30 characters can be entered !");
            RuleFor(user => user.Username).MinimumLength(3).WithMessage("Minimum 3 characters can be entered for username !");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Please enter your email !");
            RuleFor(user => user.Email).MaximumLength(50).WithMessage("Email is up to 50 characters can be entered !");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email address is invalid !");

            RuleFor(user => user.Password).NotEmpty().WithMessage("Please enter your password !");
            RuleFor(user => user.Password).MaximumLength(20).WithMessage("Password is up to 20 characters can be entered !");
            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Password must have been eight characters at least !");

            RuleFor(user => user.ConfirmPassword).NotEmpty().WithMessage("Please enter your confirm password !");
            RuleFor(user => user.ConfirmPassword).MaximumLength(20).WithMessage("Password is up to 20 characters can be entered !");
            RuleFor(user => user.ConfirmPassword).MinimumLength(10).WithMessage("Minimum 10 characters can be entered for password confirm !");

            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Password must be equal confirmed password !");

        }
    }
}
