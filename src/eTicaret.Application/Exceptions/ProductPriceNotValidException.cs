namespace eTicaret.Application.Exceptions;

public sealed class ProductPriceNotValidException : Exception
{
    public ProductPriceNotValidException() : base("Price must be greater than 0")
    {

    }
}
