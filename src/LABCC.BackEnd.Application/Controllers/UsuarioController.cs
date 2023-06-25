using AutoMapper;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
  private readonly IMapper Mapper;

  public UsuarioController(IMapper mapper)
  {
    Mapper = mapper;
  }

  [HttpGet("{id}")]
  public string Get(int id)
  {
    return "value";
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTOResponse))]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  public IActionResult Post([FromBody] UsuarioDTO value)
  {
    return Ok(Mapper.Map<Usuario>(value));
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
