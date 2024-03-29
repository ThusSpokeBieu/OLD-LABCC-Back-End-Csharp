﻿using LABCC.BackEnd.Domain.Entities.EntidadesBase.Interfaces;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;

namespace LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
public interface IUsuarioRepository : IBaseRepository<Usuario, UsuarioParams>
{
    Task Activate(long id);
}
