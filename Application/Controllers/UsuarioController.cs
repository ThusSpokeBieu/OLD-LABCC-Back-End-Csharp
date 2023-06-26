using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Params;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
  private readonly UsuarioUseCases UseCase;

  public UsuarioController(UsuarioUseCases useCase)
  {
    UseCase = useCase;
  }

  [HttpGet]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  async public Task<IActionResult> GetAll() => Ok(await UseCase.GetAll());

  [HttpGet("{id}")]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Get(long id)
  {
    var usuario = await UseCase.GetById(id);
    if (usuario == null) return NotFound();
    return Ok(await UseCase.GetById(id));
  }

  [HttpPost]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Post([FromBody] UsuarioDTO value)
  {
    var document = new UsuarioParams { CpfOuCnpj = value.CpfOuCnpj };
    var exists = await UseCase.FindFirstByParam(document);
    if (exists != null) return Conflict();

    var user = await UseCase.CreateUser(value);
    if (user == null) return BadRequest();

    return Ok(user);
  }

  // PUT api/<UserController>/5
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value)
  {
  }

  // DELETE api/<UserController>/5
  [HttpDelete("{id}")]
  public async Task Delete(long id) => await UseCase.DeleteById(id);
}
