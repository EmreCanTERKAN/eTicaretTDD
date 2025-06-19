using eTicaret.Application.Exceptions;
using eTicaret.Domain.Models;
using eTicaret.Domain.Repositories;

namespace eTicaret.Application.Features.Products;

public sealed record CreateProductCommand(
    string Name,
    decimal Price);

public sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Name.Length < 3)
        {
            throw new ProductNameNotValidException();
        }
        if (request.Price <= 0)
        {
            throw new ProductPriceNotValidException();
        }

        var isNameUnique = await productRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (isNameUnique)
        {
            throw new ProductNameNotUniqueException();
        }

        Product product = new()
        {
            Name = request.Name,
            Price = request.Price
        };

        await productRepository.CreateAsync(product, cancellationToken);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);
        await Task.CompletedTask;
        return true;
    }
}
