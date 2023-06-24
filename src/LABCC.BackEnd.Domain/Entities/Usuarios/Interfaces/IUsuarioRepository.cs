using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;

namespace LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    public Task Activate(long id);
}
