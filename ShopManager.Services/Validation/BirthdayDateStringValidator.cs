using FluentValidation;

namespace ShopManager.Services.Validation
{
    public class BirthdayDateStringValidator : AbstractValidator<string>
    {
        public BirthdayDateStringValidator()
        {
            RuleFor(dateStr => dateStr)
                .Must(dateStr => DateOnly.TryParse(dateStr, out DateOnly result))
                .WithMessage("Date string for birthday customers is not valid!")
                .Must(dateStr =>
                {
                    var date = DateOnly.Parse(dateStr);

                    return DateOnly.FromDateTime(DateTime.Today) >= date;
                })
                .WithMessage("Date for birthday customers can't be a future date!");
        }
    }
}
