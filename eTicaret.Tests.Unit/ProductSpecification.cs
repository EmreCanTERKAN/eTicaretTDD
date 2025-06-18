using FluentAssertions;

namespace eTicaret.Tests.Unit;

public class ProductSpecification
{
    [Fact]
    public async Task Create_Should_Be_Throw_Argument_Exception_If_Name_Less_Then_3_Chars()
    {
        // Arrange
        CreateProductCommand request = new("La");
        CreateProductCommandHandler command = new();
        // Act
        var action = async () => await command.Handle(request, default);
        // Assert
        await action.Should().ThrowAsync<ArgumentException>();
    }
}


public sealed record CreateProductCommand(string name);

public sealed class  CreateProductCommandHandler
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new ArgumentException("Name must be greater than 3 characters");
        await Task.CompletedTask;
    }
}