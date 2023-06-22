namespace Customer.Domain.Exceptions;

/// <summary>Not Found Exception</summary>
public class NotFoundException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="NotFoundException" /> class.</summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="identifier">The identifier.</param>
    public NotFoundException(string entityName, object identifier)
        : base($"{entityName} with ID {identifier} not found.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="NotFoundException" /> class.</summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="identifier">The identifier.</param>
    /// <param name="innerException">The inner exception.</param>
    public NotFoundException(string entityName, object identifier, Exception innerException)
        : base($"{entityName} with ID {identifier} not found.", innerException)
    {
    }
}
