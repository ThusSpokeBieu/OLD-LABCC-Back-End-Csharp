using AutoMapper;
using LABCC.BackEnd.Application.DTO.Usuarios;
using LABCC.BackEnd.Utils;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Domain.Entities.Usuarios.Params;

namespace LABCC.BackEnd.Application.Mappers;

public sealed class UsuarioMapper : Profile
{
  public UsuarioMapper()
  {
    CreateMap<UsuarioDTO, Usuario>()
      .ForMember(dest => dest.CpfOuCnpj,
          opt => opt.MapFrom(src =>
            RegexConst.NotNumerical.Replace(src.CpfOuCnpj, "")))

      .ForMember(dest => dest.Telefone,
          opt => opt.MapFrom(src =>
            RegexConst.NotNumerical.Replace(src.Telefone, "")))

      .ForMember(dest => dest.DataDeNascimento,
          opt => opt.MapFrom(src => 
            new DateTime(
              src.DataDeNascimento.Year,
              src.DataDeNascimento.Month,
              src.DataDeNascimento.Day)))

      .ForMember(dest => dest.StatusId,
          opt => opt.MapFrom(src => (byte) (StatusEnum) StringEnumConverter
            .StringToEnum(src.StatusDoUsuario, typeof(StatusEnum))))

      .ForMember(dest => dest.TipoDeUsuarioId,
          opt => opt.MapFrom(src => (byte)(TipoDeUsuarioEnum)StringEnumConverter
            .StringToEnum(src.TipoDeUsuario, typeof(TipoDeUsuarioEnum))))

      .ForMember(dest => dest.GeneroId,
          opt => opt.MapFrom(src => (byte)(GeneroEnum) StringEnumConverter
            .StringToEnum(src.Genero, typeof(GeneroEnum))))

      .ForMember(dest => dest.TipoDeUsuario, opt => opt.Ignore())
      .ForMember(dest => dest.Status, opt => opt.Ignore())
      .ForMember(dest => dest.Genero, opt => opt.Ignore());


    CreateMap<Usuario, UsuarioDTOResponse>()
      .ForMember(dest => dest.Identificador,
        opt => opt.MapFrom(src => src.Id))

      .ForMember(dest => dest.StatusDoUsuario,
        opt => opt.MapFrom(src => src.Status.Value ?? "Inativo"))

      .ForMember(dest => dest.Genero,
        opt => opt.MapFrom(src => src.Genero.Value ?? "Outro"))

      .ForMember(dest => dest.TipoDeUsuario,
        opt => opt.MapFrom(src => src.TipoDeUsuario.Value ?? "Outro"))
      
      .ForMember(dest => dest.DataDeNascimento,
        opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DataDeNascimento)));

    CreateMap<UsuarioParamsWithoutDefault, UsuarioParams>();

  }
}
