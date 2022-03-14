using Estudos.MongoDb.Domain.Validations;
using FluentValidation.Results;

namespace Estudos.MongoDb.Domain.ValueObjects;

public class Address
{
    public Address(string publicPlace, string number, string city, string state, string zipCode)
    {
        PublicPlace = publicPlace;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public string PublicPlace { get; private set; }
    public string Number { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public ValidationResult ValidationResult { get; private set; }

    public bool Validate()
    {
        ValidationResult = new AddressValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}