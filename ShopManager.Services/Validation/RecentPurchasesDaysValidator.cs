using FluentValidation;

namespace ShopManager.Services.Validation
{
    public class RecentPurchasesDaysValidator : AbstractValidator<int>
    {
        public RecentPurchasesDaysValidator()
        {
            RuleFor(days => days)
                .Must(days => days >= 0)
                .WithMessage("Days can't be lower than zero!");
        }
    }
}
