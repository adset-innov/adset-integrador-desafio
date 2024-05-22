using ADSET.Application.DTOs.Responses;
using ADSET.Domain.Entities;
using AutoMapper;

namespace ADSET.Application.Mapper
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<Marca, MarcaResponse>();
            CreateMap<Modelo, ModeloResponse>();
        }
    }
}
