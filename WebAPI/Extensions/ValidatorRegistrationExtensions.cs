using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ValidatorRegistrationExtensions
{
    public static IServiceCollection AddValidatorsFromAssemblyContaining<T>(this IServiceCollection services)
    {
        var assembly = typeof(T).GetTypeInfo().Assembly;

        var validatorTypes = assembly.GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .Select(type => new
            {
                Implementation = type,
                Interface = type.GetInterfaces().FirstOrDefault(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>))
            })
            .Where(x => x.Interface != null);

        foreach (var validator in validatorTypes)
        {
            services.AddScoped(validator.Interface, validator.Implementation);
        }

        return services;
    }
}
