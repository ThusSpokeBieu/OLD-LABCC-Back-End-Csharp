using LABCC.BackEnd.Application.DTO.Colecoes;
using LABCC.BackEnd.Domain.Entities.Colecoes.Params;

namespace LABCC.BackEnd.Application.UseCases.Interfaces;

public interface IColecaoUseCases
{
    public Task<ICollection<ColecaoDTOResponse>> GetAll();
    public Task<ICollection<ColecaoDTOResponse>> GetAll(ColecaoParams @params);
    public Task<ColecaoDTOResponse> GetById(long id);
    public Task<ColecaoDTOResponse> Create(ColecaoDTO newCollection);
    public Task<ColecaoDTOResponse> FindFirstByParams(ColecaoParams param);
    public Task<ColecaoDTOResponse?> Update(long id, ColecaoParams @params);
    public Task Delete(long id);
}
