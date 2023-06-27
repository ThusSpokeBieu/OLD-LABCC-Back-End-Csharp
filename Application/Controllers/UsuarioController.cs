using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using LABCC.BackEnd.Domain.Exceptions;
using LABCC.BackEnd.Domain.ValueObjects;
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
  async public Task<IActionResult> GetAll([FromQuery] UsuarioParamsWithoutDefault? param)
  {
    return Ok(await UseCase.GetAll(param));
  }

  [HttpGet("{id}")]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Get(long id)
  {
    var usuario = await UseCase.GetById(id);
    if (usuario == null) return NotFound( new NotFoundException("Usuário não foi encontrado pelo Identificador."));
    return Ok(await UseCase.GetById(id));
  }

  [HttpPost]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Post([FromBody] UsuarioDTO value)
  {
    var document = new UsuarioParams { CpfOuCnpj = value.CpfOuCnpj };
    var exists = await UseCase.FindFirstByParam(document);
    if (exists != null) return Conflict(new ConflictException("Cpf ou Cnpj do usuário já foi cadastrado"));

    var user = await UseCase.CreateUser(value);
    if (user == null) return BadRequest(new BadRequestException("Algo de errado aconteceu durante a requisição"));

    return Ok(user);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] UsuarioParams value)
  {
    var usuario = await UseCase.GetById(id);
    if (usuario == null) return NotFound(new NotFoundException("Usuário não foi encontrado pelo Identificador."));

    var usuarioAtualizado = await UseCase.Update(id, value);
    if (usuarioAtualizado == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

    return Ok(usuarioAtualizado);
  }

  [HttpPut("{id}/status")]
  [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] Status status)
  {
    try
    {
      var usuario = await UseCase.GetById(id);
      if (usuario == null) return NotFound(new NotFoundException("Usuário não foi encontrado pelo Identificador."));
      if (usuario.StatusDoUsuario.ToLower() == status.Value.ToLower()) return Conflict(new ConflictException($"Coleção já está {usuario.StatusDoUsuario}"));

      var param = new UsuarioParams { Status = status.Value };

      var usuarioAtualizado = await UseCase.Update(id, param);
      if (usuario == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

      return Ok(usuarioAtualizado);
    } catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }



  // DELETE api/<UserController>/5
  // [HttpDelete("{id}")]
  // public async Task Delete(long id) => await UseCase.DeleteById(id);
}
