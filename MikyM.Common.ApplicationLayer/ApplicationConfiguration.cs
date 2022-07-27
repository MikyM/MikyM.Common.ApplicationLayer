using Autofac;
using Microsoft.Extensions.Options;

namespace MikyM.Common.ApplicationLayer;

/// <summary>
/// Registration extension configuration.
/// </summary>
public sealed class ApplicationConfiguration : IOptions<ApplicationConfiguration>
{
    internal readonly ContainerBuilder Builder;

    internal  ApplicationConfiguration(ContainerBuilder builder)
    {
        Builder = builder;
    }

    /// <inheritdoc />
    public ApplicationConfiguration Value => this;
}
