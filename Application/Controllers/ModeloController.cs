using LABCC.BackEnd.Application.DTO;
using LABCC.BackEnd.Application.DTO.Modelos;
using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Entities.Modelos.Params;
using LABCC.BackEnd.Domain.Exceptions;
using LABCC.BackEnd.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace LABCC.BackEnd.Application.Controllers;


[Route("api/modelos")]
[ApiController]
public class ModeloController : Controller
{

  private readonly ModeloUseCases UseCase;

  public ModeloController(ModeloUseCases useCase)
  {
    UseCase = useCase;
  }

  [HttpGet]
  [ProducesResponseType(typeof(ModeloDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  async public Task<IActionResult> GetAll(
    [FromQuery] string? status,
    [FromQuery] string? nomeDoModelo,
    [FromQuery] string? nomeDaColecao,
    [FromQuery] long? colecaoId,
    [FromQuery] string? layout,
    [FromQuery] byte? layoutId,
    [FromQuery] string? tipoDeModelo,
    [FromQuery] byte? tipoDeModeloId
    )
  {
    var @params = new ModeloParams
    {
      Status = status ?? null,
      Colecao = nomeDaColecao ?? null,
      ColecaoId = colecaoId ?? null,
      Layout = layout ?? null,
      LayoutId = layoutId ?? null,
      TipoDeModelo = tipoDeModelo ?? null,
      TipoDeModeloId = tipoDeModeloId ?? null
    };

    return Ok(await UseCase.GetAll(@params));
  }


  [HttpGet("{id}")]
  [ProducesResponseType(typeof(ModeloDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
  async public Task<IActionResult> GetAll(long id)
  {
    var modelo = await UseCase.GetById(id);
    if (modelo == null) return NotFound(new NotFoundException($"Modelo não foi encontrado pelo id: {id}"));

    return Ok(modelo);
  }


  [HttpPost]
  [ProducesResponseType(typeof(ModeloDTOResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Post([FromBody] ModeloDTO value)
  {
    var name = new ModeloParams { NomeDoModelo = value.NomeDoModelo };
    var exists = await UseCase.FindFirstByParams(name);
    if (exists != null) return Conflict(new ConflictException("Nome do modelo já existe, escolha outro."));

    var collection = await UseCase.Create(value);
    if (collection == null) return BadRequest(new BadRequestException("Algo de errado aconteceu durante a requisição da criação de modelo."));

    return Ok(collection);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(typeof(ModeloDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] ModeloParams @params)
  {

    var modelo = await UseCase.GetById(id);
    if (modelo == null) return NotFound(new NotFoundException($"Modelo não foi encontrada pelo Identificador {id}."));

    var modeloAtualizado = await UseCase.Update(id, @params);
    if (modeloAtualizado == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

    return Ok(modeloAtualizado);
  }


  [HttpPut("{id}/status")]
  [ProducesResponseType(typeof(ModeloDTOResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(BadRequestException), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ConflictException), StatusCodes.Status409Conflict)]
  public async Task<IActionResult> Put(long id, [FromBody] Status status)
  {
    try
    {
      var modelo = await UseCase.GetById(id);
      if (modelo == null) return NotFound(new NotFoundException("Coleção não foi encontrado pelo Identificador."));
      if (modelo.Status.ToLower() == status.Value.ToLower()) return Conflict(new ConflictException($"Coleção já está {modelo.Status}"));

      var param = new ModeloParams { Status = status.Value };

      var modeloAtualizado = await UseCase.Update(id, param);
      if (modeloAtualizado == null) return BadRequest(new BadRequestException("Algo deu errado durante a requisição"));

      return Ok(modeloAtualizado);
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
      var modelo = await UseCase.GetById(id);
      if (modelo == null) return NotFound(new NotFoundException($"Modeol não foi encontrado pelo Identificador {id}."));
      if (modelo.Status.ToLower() == "ativo") return BadRequest(new NotFoundException($"Modelo de Id {id} está ativo. Só é possível deletar modelos inativos."));

      await UseCase.Delete(id);

      return NoContent();
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }
  }
}
