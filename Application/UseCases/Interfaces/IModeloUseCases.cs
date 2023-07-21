using LABCC.BackEnd.Application.DTO.Modelos;
using LABCC.BackEnd.Application.DTO;
using LABCC.BackEnd.Domain.Entities.Modelos.Params;

namespace LABCC.BackEnd.Application.UseCases.Interfaces;

public interface IModeloUseCases
{
    public Task<ICollection<ModeloDTOResponse>> GetAll();
    public Task<ICollection<ModeloDTOResponse>> GetAll(ModeloParams @params);
    public Task<ModeloDTOResponse> GetById(long id);
    public Task<ModeloDTOResponse> Create(ModeloDTO newCollection);
    public Task<ModeloDTOResponse> FindFirstByParams(ModeloParams param);
    public Task<ModeloDTOResponse?> Update(long id, ModeloParams @params);
    public Task Delete(long id);
}
