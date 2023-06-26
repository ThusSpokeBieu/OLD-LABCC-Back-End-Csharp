using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Domain.Exceptions;

public class ConflictException : ProblemDetails
{
  public ConflictException(string message) : base()
  {
    Type = $"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
    Title = "Conflict Exception";
    Status = StatusCodes.Status409Conflict;
    Detail = message;
  }

}
