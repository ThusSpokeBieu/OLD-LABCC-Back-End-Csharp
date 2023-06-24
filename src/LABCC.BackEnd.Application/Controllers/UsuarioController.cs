using LABCC.BackEnd.Application.DTO.Users;
using LABCC.BackEnd.Application.DTO.Usuarios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
  // GET api/<UserController>/5
  [HttpGet("{id}")]
  public string Get(int id)
  {
    return "value";
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTOResponse))]
  //[ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Conflict))]
  public UsuarioDTO Post([FromBody] UsuarioDTO value)
  {
    return value;
  }

  // PUT api/<UserController>/5
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value)
  {
  }

  // DELETE api/<UserController>/5
  [HttpDelete("{id}")]
  public void Delete(int id)
  {
  }
}
