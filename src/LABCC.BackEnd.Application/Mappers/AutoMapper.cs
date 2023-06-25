using AutoMapper;
using AutoMapper.Internal.Mappers;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Application.Utils;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Enum;

namespace LABCC.BackEnd.Application.Mappers;

public class AutoMapper : Profile
{
  public AutoMapper()
  {
    CreateMap<UsuarioDTO, Usuario>()

      .ForMember(dest => dest.CpfOuCnpj,
          opt => opt.MapFrom(src =>
            RegexConst.NotNumerical.Replace(src.CpfOuCnpj, "")))

      .ForMember(dest => dest.Telefone,
          opt => opt.MapFrom(src =>
            RegexConst.NotNumerical.Replace(src.Telefone, "")))

      .ForMember(dest => dest.StatusId,
          opt => opt.MapFrom(src => StringEnumConverter
            .StringToEnumByteIndex(src.StatusDoUsuario, typeof(StatusEnum))))

      .ForMember(dest => dest.TipoDeUsuarioId,
          opt => opt.MapFrom(src => StringEnumConverter
            .StringToEnumByteIndex(src.TipoDeUsuario, typeof(TipoDeUsuarioEnum))))

      .ForMember(dest => dest.GeneroId,
          opt => opt.MapFrom(src => StringEnumConverter
            .StringToEnumByteIndex(src.Genero, typeof(GeneroEnum))))

      .ForMember(dest => dest.TipoDeUsuario, opt => opt.Ignore())
      .ForMember(dest => dest.Status, opt => opt.Ignore())
      .ForMember(dest => dest.Genero, opt => opt.Ignore());


    CreateMap<Usuario, UsuarioDTOResponse>();
  }
}
