using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.MongoDb.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatr();
        services.AddFailFastValidationBehavior();
        services.AddValidators();

        return services;
    }

    private static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(typeof(FailFastValidationBehavior<,>).Assembly);
    }

    private static IServiceCollection AddFailFastValidationBehavior(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidationBehavior<,>));

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        AssemblyScanner
            .FindValidatorsInAssembly(typeof(FailFastValidationBehavior<,>).Assembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

        return services;
    }
}