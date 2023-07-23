using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using LABCC.BackEnd.Domain.Exceptions;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/usuarios")]
[ApiController]
public sealed class UsuarioController : ControllerBase
{
    private readonly IUsuarioUseCases UseCase;
    private readonly UserManager<Usuario> _userManager;

    public UsuarioController(IUsuarioUseCases useCase)
    {
        UseCase = useCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] UsuarioParamsWithoutDefault? param)
    {
        return Ok(await UseCase.GetAll(param));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        var usuario = await UseCase.GetById(id);
        if (usuario == null)
            return NotFound(
                new NotFoundException("Usuário não foi encontrado pelo Identificador.")
            );
        return Ok(await UseCase.GetById(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Put(string id, [FromBody] UsuarioParams value)
    {
        var usuario = await UseCase.GetById(id);
        if (usuario == null)
            return NotFound(
                new NotFoundException("Usuário não foi encontrado pelo Identificador.")
            );

        var usuarioAtualizado = await UseCase.Update(id, value);
        if (usuarioAtualizado == null)
            return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

        return Ok(usuarioAtualizado);
    }

    [HttpPut("{id}/status")]
    [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Put(string id, [FromBody] Status status)
    {
        try
        {
            var usuario = await UseCase.GetById(id);
            if (usuario == null)
                return NotFound(
                    new NotFoundException("Usuário não foi encontrado pelo Identificador.")
                );
            if (usuario.StatusDoUsuario.ToLower() == status.Value.ToLower())
                return Conflict(
                    new ConflictException($"Coleção já está {usuario.StatusDoUsuario}")
                );

            var param = new UsuarioParams { Status = status.Value };

            var usuarioAtualizado = await UseCase.Update(id, param);
            if (usuario == null)
                return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

            return Ok(usuarioAtualizado);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    // DELETE api/<UserController>/5
    // [HttpDelete("{id}")]
    // public async Task Delete(string id) => await UseCase.DeleteById(id);
}
