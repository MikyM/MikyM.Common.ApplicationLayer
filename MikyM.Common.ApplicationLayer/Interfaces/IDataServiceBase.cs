﻿using MikyM.Common.Utilities.Results;

namespace MikyM.Common.ApplicationLayer.Interfaces;

/// <summary>
/// Base data service
/// </summary>
public interface IDataServiceBase : IDisposable
{
    /// <summary>
    /// Commits pending changes
    /// </summary>
    /// <returns> <see cref="Result"/> with number of affected rows</returns>
    Task<Result<int>> CommitAsync();
    /// <summary>
    /// Commits pending changes with specifying user that is responsible for them
    /// </summary>
    /// <param name="auditUserId">Id of the user that's responsible for the changes</param>
    /// <returns> <see cref="Result"/> with number of affected rows</returns>
    Task<Result<int>> CommitAsync(string? auditUserId);
    /// <summary>
    /// Rolls the current transaction back
    /// </summary>
    /// <returns>Task with a <see cref="Result"/> representing the async operation</returns>
    Task<Result> RollbackAsync();
}
