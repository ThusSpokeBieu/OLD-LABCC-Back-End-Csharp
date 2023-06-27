using AutoMapper;
using LABCC.BackEnd.Application.DTO.Colecoes;
using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Utils;

namespace LABCC.BackEnd.Application.Mappers;

public class ColecaoMapper : Profile
{

  public ColecaoMapper() 
  {
    CreateMap<ColecaoDTO, Colecao>()

      .ForMember(
          dest => dest.EstacaoId,
          opt => opt.MapFrom(
              src => (byte) (EstacoesEnum) StringEnumConverter
              .StringToEnum(src.Estacao, typeof(EstacoesEnum))))

      .ForMember(
          dest => dest.StatusId,
          opt => opt.MapFrom(
              src => (byte) (StatusEnum) StringEnumConverter
              .StringToEnum(src.Status, typeof(StatusEnum))))
      
      .ForMember(dest => dest.Status, opt => opt.Ignore())
      .ForMember(dest => dest.Estacao, opt => opt.Ignore());

    CreateMap<Colecao, ColecaoDTOResponse>()

      .ForMember(
          dest => dest.Estacao,
          opt => opt.MapFrom(
              src => src.Estacao.Value))

      .ForMember(
          dest => dest.Status,
          opt => opt.MapFrom(
              src => src.Status.Value));

    CreateMap<Colecao, ColecaoDTOResponseOnlyId>()

      .ForMember(
          dest => dest.Estacao,
          opt => opt.MapFrom(
              src => src.Estacao.Value))

      .ForMember(
          dest => dest.Status,
          opt => opt.MapFrom(
              src => src.Status.Value));
  }

}
