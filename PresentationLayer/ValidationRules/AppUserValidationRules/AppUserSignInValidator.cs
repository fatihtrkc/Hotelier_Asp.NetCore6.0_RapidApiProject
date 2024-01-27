using FluentValidation;
using PresentationLayer.Models.ViewModels.AppUserVMs;

namespace PresentationLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInVM>
    {
        public AppUserSignInValidator()
        {
            RuleFor(user => user.UsernameOrEmail).NotEmpty().WithMessage("Please enter your username or email !");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Please enter your password !");
        }
    }
}
