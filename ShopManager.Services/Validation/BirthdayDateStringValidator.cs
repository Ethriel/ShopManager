using FluentValidation;

namespace ShopManager.Services.Validation
{
    public class BirthdayDateStringValidator : AbstractValidator<string>
    {
        public BirthdayDateStringValidator()
        {
            RuleFor(dateStr => dateStr)
                .Custom((x, context) =>
                {
                    if (!DateOnly.TryParse(x, out DateOnly result))
                    {
                        context.AddFailure("Date string for birthday clients is not valid!");
                    }
                    else if (result > DateOnly.FromDateTime(DateTime.Today))
                    {
                        context.AddFailure("Date for birthday clients can't be a future date!");
                    }
                });
        }
    }
}
