using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocksMessaging.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly? assembly = null)
    {
        services.AddMassTransit(config =>
        {
            // Use kebab-case for endpoint names
            config.SetKebabCaseEndpointNameFormatter();

            // Register consumers if assembly is provided
            if (assembly != null)
                config.AddConsumers(assembly);

            // Configure RabbitMQ
            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(
                    new Uri(configuration["MessageBroker:Host"]!),
                    host =>
                    {
                        host.Username(configuration["MessageBroker:UserName"]);
                        host.Password(configuration["MessageBroker:Password"]);
                    });

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
