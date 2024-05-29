using ADSET.Application.DTOs.Requests;
using ADSET.Domain.Entities;
using AutoMapper;

namespace ADSET.Application.Mapper
{
    public class PacoteProfile : Profile
    {
        public PacoteProfile() 
        {
            CreateMap<SavePacoteRequest, Pacote>();
        }
    }
}
