﻿namespace Core.Utilities.Results
{
    // Starting point for basic 'void's
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}