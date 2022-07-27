using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MikyM.CommandHandlers.Helpers;
using MikyM.Common.Utilities;

namespace MikyM.Common.ApplicationLayer;

/// <summary>
/// DI extensions for <see cref="ContainerBuilder"/>.
/// </summary>
[PublicAPI]
public static class DependancyInjectionExtensions
{
    /// <summary>
    /// Registers application layer with the <see cref="ContainerBuilder"/>.
    /// </summary>
    /// <param name="builder">Builder.</param>
    /// <param name="options">Configuration options.</param>
    /// <returns>Current <see cref="ApplicationConfiguration"/> instance</returns>
    public static ContainerBuilder AddApplicationLayer(this ContainerBuilder builder, Action<ApplicationConfiguration> options)
    {
        // register automapper
        builder.RegisterAutoMapper(opt => opt.AddExpressionMapping(), false, AppDomain.CurrentDomain.GetAssemblies());
        //register async interceptor adapter
        builder.RegisterGeneric(typeof(AsyncInterceptorAdapter<>));
        //register async interceptor

        var config = new ApplicationConfiguration(builder);
        config.AddInterceptor(x =>
            new LoggingInterceptor(x.Resolve<ILoggerFactory>().CreateLogger(nameof(LoggingInterceptor))), Lifetime.SingleInstance);
        options(config);
        
        builder.Register(x => config).As<IOptions<ApplicationConfiguration>>().SingleInstance();

        return builder;
    }

    /// <summary>
    /// Registers attribute defined services using <see cref="MikyM.Autofac.Extensions.DependancyInjectionExtensions.AddAttributeDefinedServices"/>.
    /// </summary>
    /// <param name="applicationConfiguration">Configuration.</param>
    /// <param name="options">Configuration action.</param>
    /// <returns>Current <see cref="ApplicationConfiguration"/> instance</returns>
    public static ApplicationConfiguration AddAttributeDefinedServices(
        this ApplicationConfiguration applicationConfiguration, Action<AttributeRegistrationOptions>? options = null)
    {
        if (options is not null)
        {
            var config = new AttributeRegistrationOptions(applicationConfiguration.Builder);
            options.Invoke(config);
            applicationConfiguration.Builder.AddAttributeDefinedServices(options);
        }
        else
        {
            applicationConfiguration.Builder.AddAttributeDefinedServices();
        }


        return applicationConfiguration;
    }

    /// <summary>
    /// Registers an interceptor with <see cref="ContainerBuilder"/>.
    /// </summary>
    /// <param name="applicationConfiguration">Configuration.</param>
    /// <param name="factoryMethod">Factory method for the registration.</param>
    /// <param name="interceptorLifetime">Lifetime of the registered interceptor.</param>
    /// <returns>Current instance of the <see cref="ApplicationConfiguration"/></returns>
    public static ApplicationConfiguration AddInterceptor<T>(this ApplicationConfiguration applicationConfiguration, Func<IComponentContext, T> factoryMethod, Lifetime interceptorLifetime) where T : notnull
    {
        _ = interceptorLifetime switch
        {
            Lifetime.SingleInstance => applicationConfiguration.Builder.Register(factoryMethod).AsSelf().SingleInstance(),
            Lifetime.InstancePerRequest => applicationConfiguration.Builder.Register(factoryMethod).AsSelf().InstancePerRequest(),  
            Lifetime.InstancePerLifetimeScope => applicationConfiguration.Builder.Register(factoryMethod).AsSelf().InstancePerLifetimeScope(),  
            Lifetime.InstancePerMatchingLifetimeScope => throw new NotSupportedException(),
            Lifetime.InstancePerDependancy => applicationConfiguration.Builder.Register(factoryMethod).AsSelf().InstancePerDependency(), 
            Lifetime.InstancePerOwned => throw new NotSupportedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(interceptorLifetime), interceptorLifetime, null)
        }; 
        
        return applicationConfiguration;
    }

    /// <summary>
    /// Registers an async executor with the container.
    /// </summary>
    /// <param name="applicationConfiguration">Configuration.</param>
    /// <returns>Current instance of the <see cref="ApplicationConfiguration"/>.</returns>
    public static ApplicationConfiguration AddAsyncExecutor(this ApplicationConfiguration applicationConfiguration)
    {
        applicationConfiguration.Builder.AddAsyncExecutor();
        return applicationConfiguration;
    }

    /// <summary>
    /// Registers command handlers with the <see cref="ContainerBuilder"/>.
    /// </summary>
    /// <param name="applicationConfiguration">Configuration.</param>
    /// <param name="options">Optional command handler configuration.</param>
    /// <returns>Current instance of the <see cref="ApplicationConfiguration"/></returns>
    public static ApplicationConfiguration AddCommandHandlers(this ApplicationConfiguration applicationConfiguration, Action<CommandHandlerConfiguration>? options = null)
    {
        applicationConfiguration.Builder.AddCommandHandlers(options);
        return applicationConfiguration;
    }
}
