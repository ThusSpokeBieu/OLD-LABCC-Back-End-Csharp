using LABCC.BackEnd.Application.DTO.Colecoes;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Entities.Colecoes.Params;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;
using LABCC.BackEnd.Domain.Exceptions;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LABCC.BackEnd.Application.Controllers;

[Route("api/colecoes")]
[ApiController]
public class ColecaoController : Controller
{

  private readonly ColecaoUseCases UseCase;

  public ColecaoController(ColecaoUseCases useCase)
  {
    UseCase = useCase;
  }

  [HttpGet]
  [ProducesResponseType(typeof(ColecaoDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  async public Task<IActionResult> GetAll(
    [FromQuery] string? status,
    [FromQuery] string? nomeDaColecao,
    [FromQuery] string? marca,
    [FromQuery] int? anoDeLancamento,
    [FromQuery] long? responsavelId,
    [FromQuery] string? estacao
    )
  {
    var @params = new ColecaoParams
    {
      Status = status ?? null,
      NomeDaColecao = nomeDaColecao ?? null,
      Marca = marca ?? null,
      AnoDeLancamento = anoDeLancamento ?? null,
      ResponsavelId = responsavelId ?? null,
      Estacao = estacao ?? null
    };

    return Ok(await UseCase.GetAll(@params));
  }


  [HttpGet("{id}")]
  [ProducesResponseType(typeof(ColecaoDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  async public Task<IActionResult> GetAll(long id)
  {
    var colecao = await UseCase.GetById(id);
    if (colecao == null) return NotFound(new NotFoundException($"Coleção não foi encontrada pelo id: {id}"));

    return Ok(colecao);
  }
    

  [HttpPost]
  [ProducesResponseType(typeof(ColecaoDTOResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Post([FromBody] ColecaoDTO value)
  {
    var name = new ColecaoParams { NomeDaColecao = value.NomeDaColecao };
    var exists = await UseCase.FindFirstByParams(name);
    if (exists != null) return Conflict(new ConflictException("Nome da coleção já existe, escola outro."));

    var collection = await UseCase.Create(value);
    if (collection == null) return BadRequest(new BadRequestException("Algo de errado aconteceu durante a requisição da criação de coleções."));

    return Ok(collection);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(typeof(ColecaoDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] ColecaoParams @params)
  {

    var colecao = await UseCase.GetById(id);
    if (colecao == null) return NotFound(new NotFoundException("Colecao não foi encontrada pelo Identificador."));

    var colecaoAtualizada = await UseCase.Update(id, @params);
    if (colecaoAtualizada == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

    return Ok(colecaoAtualizada);
  }


  [HttpPut("{id}/status")]
  [ProducesResponseType(typeof(ColecaoDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] Status status)
  {
    try
    {
      var colecao = await UseCase.GetById(id);
      if (colecao == null) return NotFound(new NotFoundException("Coleção não foi encontrado pelo Identificador."));
      if (colecao.Status.ToLower() == status.Value.ToLower()) return Conflict(new ConflictException($"Coleção já está {colecao.Status}"));

      var param = new ColecaoParams { Status = status.Value };

      var colecaoAtualizada = await UseCase.Update(id, param);
      if (colecao == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

      return Ok(colecaoAtualizada);
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Delete(long id)
  {
    try
    {
      var colecao = await UseCase.GetById(id);
      if (colecao == null) return NotFound(new NotFoundException($"Coleção não foi encontrado pelo Identificador {id}."));
      if (colecao.Status.ToLower() == "ativo") return BadRequest(new NotFoundException($"Coleção de Id {id} está ativa. Só é possível deletar coleções inativas."));

      await UseCase.Delete(id);

      return NoContent();
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }
}
