namespace eTicaret.Application.Exceptions;

public sealed class ProductNameNotValidException : Exception
{
    public ProductNameNotValidException() : base("Name must be greater than 3 characters")
    {

    }
}
