using FluentAssertions;

namespace eTicaret.Tests.Unit;

public class ProductSpecification
{
    [Fact]
    public async Task Create_Should_Be_Throw_Argument_Exception_If_Name_Less_Then_3_Chars()
    {
        // Arrange
        CreateProductCommand request = new("La", 1);
        CreateProductCommandHandler command = new();
        // Act
        var action = async () => await command.Handle(request, default);
        // Assert
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Name must be greater than 3 characters");
    }

    [Fact]
    public async Task Create_Should_Be_Throw_Argument_Exception_If_Product_Price_Null_Or_Zero()
    {
        //Arrange
        CreateProductCommand request = new("laptop", 0);
        CreateProductCommandHandler command = new();
        //Act
        var action = async () => await command.Handle(request, default);
        //Assert
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("Price must be greater than 0");
    }
}


public sealed record CreateProductCommand(string Name, decimal Price);

public sealed class CreateProductCommandHandler
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Name.Length < 3)
        {
            throw new ArgumentException("Name must be greater than 3 characters");
        }
        if (request.Price == 0 || request.Price == -1)
        {
            throw new ArgumentException("Price must be greater than 0");
        }

        await Task.CompletedTask;
    }
}