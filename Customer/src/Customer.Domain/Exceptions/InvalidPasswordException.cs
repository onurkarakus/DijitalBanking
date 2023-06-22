namespace Customer.Domain.Exceptions;

/// <summary>Invalid Password Exception</summary>
public class InvalidPasswordException: Exception
{
    /// <summary>Initializes a new instance of the <see cref="InvalidPasswordException" /> class.</summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="identifier">The identifier.</param>
    public InvalidPasswordException(string entityName, object identifier)
        : base($"{entityName} with ID {identifier} not found.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="InvalidPasswordException" /> class.</summary>
    /// <param name="entityName">Name of the entity.</param>
    /// <param name="identifier">The identifier.</param>
    /// <param name="innerException">The inner exception.</param>
    public InvalidPasswordException(string entityName, object identifier, Exception innerException)
        : base($"{entityName} with ID {identifier} not found.", innerException)
    {
    }
}
