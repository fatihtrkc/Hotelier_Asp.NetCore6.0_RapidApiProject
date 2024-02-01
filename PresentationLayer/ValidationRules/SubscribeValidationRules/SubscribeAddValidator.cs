using FluentValidation;
using PresentationLayer.Models.ViewModels.SubscribeVMs;

namespace PresentationLayer.ValidationRules.SubscribeValidationRules
{
    public class SubscribeAddValidator : AbstractValidator<SubscribeAddVM>
    {
        public SubscribeAddValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("Please enter your email !");
            RuleFor(user => user.Email).MaximumLength(50).WithMessage("Email is up to 50 characters can be entered !");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email address is invalid !");
        }
    }
}
