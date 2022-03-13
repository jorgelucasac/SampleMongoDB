using Estudos.MongoDb.Domain.Entities;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations
{
    internal class RestaurantValidation : AbstractValidator<Restaurant>
    {
        public RestaurantValidation()
        {
            ValidateName();
            ValidateCountry();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(30);
        }

        private void ValidateCountry()
        {
            RuleFor(c => c.Country)
                .NotEmpty();
        }
    }
}