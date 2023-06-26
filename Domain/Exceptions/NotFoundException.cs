using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Domain.Exceptions;

public class NotFoundException : ProblemDetails
{
  public NotFoundException(string message) : base()
  {
    Type = $"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
    Title = "Not Found Exception";
    Status = StatusCodes.Status404NotFound;
    Detail = message;
  }
}
