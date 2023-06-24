using AutoMapper;
using LABCC.BackEnd.Application.DTO.Users;
using LABCC.BackEnd.Domain.Entities.Usuarios;

namespace LABCC.BackEnd.Infrastructure.Config;

public class MapperConfiguration : Profile 
{
  public MapperConfiguration() 
  {
    CreateMap<UsuarioDTO, Usuario>();
  }
}
