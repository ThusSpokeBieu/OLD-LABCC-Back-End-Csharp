using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using LABCC.BackEnd.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUsuarioUseCases UseCase;
    
    public AuthController(IUsuarioUseCases useCase, UserManager<Usuario> userManager)
    {
        UseCase = useCase;
    }

    [HttpPost("registrar")]
    [ProducesResponseType(typeof(UsuarioDTOResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register([FromBody] UsuarioDTO value)
    {
        var document = new UsuarioParams { CpfOuCnpj = value.CpfOuCnpj };
        var exists = await UseCase.FindFirstByParam(document);
        if (exists != null)
            return Conflict(new ConflictException("Cpf ou Cnpj do usuário já foi cadastrado"));

        var user = await UseCase.CreateUser(value);
        if (user == null)
            return BadRequest(
                new BadRequestException("Algo de errado aconteceu durante a requisição")
            );
        
        return Ok(user);
    }

}