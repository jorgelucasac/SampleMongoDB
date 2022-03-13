﻿using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestauranteInputValidation : AbstractValidator<CreateRestauranteInput>
{
    public CreateRestauranteInputValidation()
    {
        ValidarLogradouro();
        ValidarCidade();
        ValidarUf();
        ValidarCep();
        ValidarNome();
        ValidarCozinha();
    }

    private void ValidarNome()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Name não pode ser vazio.")
            .MaximumLength(30).WithMessage("Name pode ter no maximo 30 caracteres.");
    }

    private void ValidarCozinha()
    {
        RuleFor(c => c.Cozinha)
            .NotEmpty().WithMessage("Country não pode ser vazio.");
    }

    private void ValidarLogradouro()
    {
        RuleFor(c => c.Logradouro)
            .NotEmpty().WithMessage("PublicPlace não pode ser vazio.")
            .MaximumLength(50).WithMessage("PublicPlace pode ter no maximo 50 caracteres.");
    }

    private void ValidarCidade()
    {
        RuleFor(c => c.Cidade)
            .NotEmpty().WithMessage("City não pode ser vazio.")
            .MaximumLength(100).WithMessage("City pode ter no maximo 100 caracteres.");
    }

    private void ValidarUf()
    {
        RuleFor(c => c.UF)
            .NotEmpty().WithMessage("State não pode ser vazio.")
            .Length(2).WithMessage("State deve ter 2 caracteres.");
    }

    private void ValidarCep()
    {
        RuleFor(c => c.Cep)
            .NotEmpty().WithMessage("ZipCode não pode ser vazio.")
            .Length(8).WithMessage("ZipCode deve ter 8 caracteres.");
    }
}