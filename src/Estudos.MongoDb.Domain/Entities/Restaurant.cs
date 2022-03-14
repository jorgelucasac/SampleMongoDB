using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.Validations;
using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation.Results;

namespace Estudos.MongoDb.Domain.Entities;

public class Restaurant
{
    public Restaurant(string name, Country country)
    {
        Name = name;
        Country = country;
    }

    public Restaurant(string id, string name, Country country)
    {
        Id = id;
        Name = name;
        Country = country;
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public Country Country { get; private set; }
    public Address Address { get; private set; }

    public ValidationResult ValidationResult { get; private set; }

    public void SetAddress(Address address)
    {
        Address = address;
    }

    public virtual bool Validate()
    {
        ValidationResult = new RestaurantValidation().Validate(this);

        ValidateAddress();

        return ValidationResult.IsValid;
    }

    private void ValidateAddress()
    {
        if (Address.Validate())
            return;

        foreach (var error in Address.ValidationResult.Errors)
            ValidationResult.Errors.Add(error);
    }
}