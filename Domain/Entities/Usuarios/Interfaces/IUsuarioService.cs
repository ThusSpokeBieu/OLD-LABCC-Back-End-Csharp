using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
using LABCC.BackEnd.Domain.Params;

namespace LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
public interface IUsuarioService : IBaseService<Usuario, UsuarioParams>
{
  Task<Usuario> SelectOneByQueryParams(UsuarioParams param);
  Task<IList<Usuario>> SelectAllByQueryParams(UsuarioParams param);
}
