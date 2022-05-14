namespace MikyM.Common.ApplicationLayer;

public abstract class DataServiceConfigurationBase
{
    /// <summary>
    /// Gets or sets the default lifetime for base generic data services
    /// </summary>
    public Lifetime BaseGenericDataServiceLifetime { get; set; } = Lifetime.InstancePerLifetimeScope;
    /// <summary>
    /// Gets or sets the default lifetime for custom data services that implement or derive from base data services
    /// </summary>
    public Lifetime DataServiceLifetime { get; set; } = Lifetime.InstancePerLifetimeScope;
    
    /// <summary>
    /// Gets data interceptor registration delegates
    /// </summary>
    protected Dictionary<Type, DataInterceptorConfiguration> DataInterceptors { get; private set; } = new();
    
    /// <summary>
    /// Marks an interceptor of a given type to be used for intercepting base data services.
    /// Please note you must also add this interceptor using <see cref="ApplicationConfiguration.AddInterceptor{T}"/>
    /// </summary>
    /// <param name="interceptor">Type of the interceptor</param>
    /// <param name="configuration">Interceptor configuration</param>
    /// <returns>Current instance of the <see cref="ServiceApplicationConfiguration"/></returns>
    public virtual DataServiceConfigurationBase AddDataServiceInterceptor(Type interceptor, DataInterceptorConfiguration configuration = DataInterceptorConfiguration.CrudAndReadOnly)
    {
        DataInterceptors.TryAdd(interceptor ?? throw new ArgumentNullException(nameof(interceptor)), configuration);
        return this;
    }
    /// <summary>
    /// Marks an interceptor of a given type to be used for intercepting base data services.
    /// Please note you must also add this interceptor using <see cref="ApplicationConfiguration.AddInterceptor{T}"/>
    /// </summary>
    /// <param name="configuration">Interceptor configuration</param>
    /// <returns>Current instance of the <see cref="ServiceApplicationConfiguration"/></returns>
    public virtual DataServiceConfigurationBase AddDataServiceInterceptor<T>(DataInterceptorConfiguration configuration = DataInterceptorConfiguration.CrudAndReadOnly) where T : notnull
    {
        DataInterceptors.TryAdd(typeof(T), configuration);
        return this;
    }
}

/// <summary>
/// Configuration for base data service interceptors
/// </summary>
public enum DataInterceptorConfiguration
{
    /// <summary>
    /// Crud and read-only
    /// </summary>
    CrudAndReadOnly,
    /// <summary>
    /// Crud
    /// </summary>
    Crud,
    /// <summary>
    /// Read-only
    /// </summary>
    ReadOnly
}