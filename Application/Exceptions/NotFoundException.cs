﻿namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message):base(message)
    {
    }

    public NotFoundException(string message, string code) : base(message)
    {
    }
}
