using Castle.Core.Resource;
using FluentValidation;

namespace ShopManager.Services.Validation
{
    public class PopularCategoriesCustomerIdValidator : AbstractValidator<int>
    {
        public PopularCategoriesCustomerIdValidator()
        {
            RuleFor(customerId => customerId)
                .Must(customerId => customerId > 0)
                .WithMessage("Customer Id is invalid. Must be greater that zero!");
        }
    }
}
