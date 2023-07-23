using AutoMapper;
using LABCC.BackEnd.Application.DTO;
using LABCC.BackEnd.Application.DTO.Colecoes;
using LABCC.BackEnd.Application.DTO.Modelos;
using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Domain.Entities.Modelos;
using LABCC.BackEnd.Domain.Enum;
using LABCC.BackEnd.Utils;

namespace LABCC.BackEnd.Application.Mappers;

public sealed class ModeloMapper : Profile
{
  public ModeloMapper()
  {

    CreateMap<ModeloDTO, Modelo>()

         .ForMember(
            dest => dest.LayoutId,
            opt => opt.MapFrom(
                src => (byte)(ModeloLayoutEnum)StringEnumConverter
                .StringToEnum(src.Layout, typeof(ModeloLayoutEnum))))

        .ForMember(
            dest => dest.TipoDeModeloId,
            opt => opt.MapFrom(
                src => (byte)(TipoDeModeloEnum) StringEnumConverter
                .StringToEnum(src.TipoDeModelo, typeof(TipoDeModeloEnum))))

        .ForMember(
            dest => dest.StatusId,
            opt => opt.MapFrom(
                src => (byte)(StatusEnum)StringEnumConverter
                .StringToEnum(src.Status, typeof(StatusEnum))))

        .ForMember(dest => dest.Status, opt => opt.Ignore())
        .ForMember(dest => dest.TipoDeModelo, opt => opt.Ignore())
        .ForMember(dest => dest.Layout, opt => opt.Ignore());


    CreateMap<Modelo, ModeloDTOResponse>()

      .ForMember(
          dest => dest.Layout,
          opt => opt.MapFrom(
              src => src.Layout.Value))

      .ForMember(
          dest => dest.TipoDeModelo,
          opt => opt.MapFrom(
              src => src.TipoDeModelo.Value))

      .ForMember(
          dest => dest.Status,
          opt => opt.MapFrom(
              src => src.Status.Value));
  }
}
