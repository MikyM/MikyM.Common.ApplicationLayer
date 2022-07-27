using MikyM.Common.Utilities.Results;

namespace MikyM.Common.ApplicationLayer.Interfaces;

/// <summary>
/// Defines a base data service.
/// </summary>
[PublicAPI]
public interface IDataServiceBase<out TContext> : IDisposable where TContext : class
{
    /// <summary>
    /// Current database context.
    /// </summary>
    TContext Context { get; }
    /// <summary>
    /// Current Unit of Work.
    /// </summary>
    IUnitOfWorkBase UnitOfWork { get; }
    /// <summary>
    /// Commits pending changes.
    /// </summary>
    Task<Result> CommitAsync();
    /// <summary>
    /// Commits pending changes with specifying user that is responsible for them.
    /// </summary>
    /// <param name="auditUserId">Id of the user that's responsible for the changes.</param>
    Task<Result> CommitAsync(string auditUserId);
    /// <summary>
    /// Rolls the current transaction back.
    /// </summary>
    /// <returns>Task with a <see cref="Result"/> representing the async operation.</returns>
    Task<Result> RollbackAsync();
}
