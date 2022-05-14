using Microsoft.Extensions.Options;

namespace MikyM.Common.ApplicationLayer;

/// <summary>
/// Registration extension configuration
/// </summary>
public abstract class ServiceApplicationConfiguration : IOptions<ServiceApplicationConfiguration>
{
    internal ServiceApplicationConfiguration(ApplicationConfiguration config)
    {
        Config = config;
    }

    internal ApplicationConfiguration Config { get; set; }

    internal Action<AttributeRegistrationOptions>? AttributeOptions { get; private set; }

    /// <summary>
    /// Configures attribute services registration options
    /// </summary>
    /// <returns>Current instance of the <see cref="ServiceApplicationConfiguration"/></returns>
    public ServiceApplicationConfiguration ConfigureAttributeServices(Action<AttributeRegistrationOptions> action)
    {
        AttributeOptions = action;
        return this;
    }

    /// <inheritdoc />
    public ServiceApplicationConfiguration Value => this;
}