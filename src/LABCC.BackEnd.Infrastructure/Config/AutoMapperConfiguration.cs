using AutoMapper;
using LABCC.BackEnd.Application.DTO.Users;
using LABCC.BackEnd.Domain.Entities.Usuarios;

namespace LABCC.BackEnd.Infrastructure.Config;

public class AutoMapperConfiguration : Profile 
{
  public AutoMapperConfiguration() 
  {
    CreateMap<UsuarioDTO, Usuario>();
  }
}
