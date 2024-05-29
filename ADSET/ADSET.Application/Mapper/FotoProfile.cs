using ADSET.Application.DTOs.Requests;
using ADSET.Application.DTOs.Responses;
using ADSET.Domain.Entities;
using AutoMapper;

namespace ADSET.Application.Mapper
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {
            CreateMap<VeiculoFotoRequest, Domain.DTOs.Request.VeiculoFotoRequest>();
            CreateMap<Foto, FotoResponse>();
        }
    }
}
