namespace eTicaret.Application.Exceptions;

public sealed class ProductNameNotUniqueException : Exception
{
    public ProductNameNotUniqueException() : base("Product name must be unique")
    {

    }
}
