using eTicaret.Domain.Models;
using System.Linq.Expressions;

namespace eTicaret.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Delete(Product product);
    Task<bool> IsNameExists(string name, CancellationToken cancellationToken);
    Task CreateAsync(Product product, CancellationToken cancellationToken);
}
