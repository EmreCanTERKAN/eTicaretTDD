using eTicaret.Domain.Repositories;

namespace eTicaret.Tests.Unit.TestDoubles;

public sealed class StubUnitOfWork : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return 1;
    }
}