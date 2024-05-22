using ADSET.Application.DTOs.Responses;
using ADSET.Domain.Entities;
using AutoMapper;

namespace ADSET.Application.Mapper
{
    public class OpcionalProfile : Profile
    {
        public OpcionalProfile()
        {
            CreateMap<Opcional, OpcionalResponse>();
        }
    }
}
