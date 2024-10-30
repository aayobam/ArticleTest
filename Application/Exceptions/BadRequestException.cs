﻿namespace Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message):base(message)
    {
    }

    public BadRequestException(string message, string code) : base(message)
    {
    }
}