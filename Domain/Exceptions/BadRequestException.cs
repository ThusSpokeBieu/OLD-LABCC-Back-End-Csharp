using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Domain.Exceptions;

public class BadRequestException : ProblemDetails
{
    public BadRequestException(string message)
        : base()
    {
        Type = $"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        Title = "Bad Request Exception";
        Status = StatusCodes.Status400BadRequest;
        Detail = message;
    }
}
