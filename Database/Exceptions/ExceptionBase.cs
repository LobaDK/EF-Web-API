using System;

namespace Database.Exceptions;

/// <summary>
/// Exception thrown when a requested entry is not found in the database.
/// </summary>
/// <remarks>
/// This exception is thrown when a user tries to retrieve an entry that does not exist in the database.
/// </remarks>
public class EntryNotFoundException : Exception
{
    public EntryNotFoundException()
    {
    }

    public EntryNotFoundException(string message) : base(message)
    {
    }

    public EntryNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Exception thrown when a requested entry already exists in the database.
/// </summary>
/// <remarks>
/// This exception is thrown when a user tries to create an entry that already exists in the database.
/// </remarks>
public class EntryAlreadyExistsException : Exception
{
    public EntryAlreadyExistsException()
    {
    }

    public EntryAlreadyExistsException(string message) : base(message)
    {
    }

    public EntryAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

/// <summary>
/// Exception thrown when a user tries to purchase an item but does not have enough money.
/// </summary>
/// <remarks>
/// This exception is thrown when a user tries to purchase an item but does not have enough money to do so.
/// </remarks>
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException()
    {
    }

    public InsufficientFundsException(string message) : base(message)
    {
    }

    public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class CharacterCreationLimitReachedException : Exception
{
    public CharacterCreationLimitReachedException()
    {
    }

    public CharacterCreationLimitReachedException(string message) : base(message)
    {
    }

    public CharacterCreationLimitReachedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}