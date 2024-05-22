using ADSET.Application.DTOs.Responses;
using ADSET.Domain.Entities;
using AutoMapper;

namespace ADSET.Application.Mapper
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<DTOs.Request.FilterPaginationRequest, Domain.DTOs.Request.FilterPaginationRequest>();
            CreateMap<Domain.DTOs.Response.VeiculoPaginatedResponse, DTOs.Response.VeiculoPaginatedResponse>()
                .ForMember(v => v.TotalPaginas, map => map.MapFrom(src => (int) Math.Ceiling((decimal)(src.TotalDados / src.QtdPerPage))));

            CreateMap<Veiculo, VeiculoResponse>()
                .ForMember(v => v.NomeModelo, map => map.MapFrom(src => src.Modelo.Nome))
                .ForMember(v => v.NomeMarca, map => map.MapFrom(src => src.Marca.Nome))
                .ForMember(v => v.Opcionais, map => map.MapFrom(src => src.VeiculoOpcionais.Select(vo => vo.Opcional.Nome)))
                .ForMember(v => v.Pacotes, map => map.MapFrom(src => src.Pacotes.Select(p => p.Tipo)));

            CreateMap<Domain.Enums.TipoPacote, Application.DTOs.Enums.TipoPacote>()
                .ReverseMap();
        }
    }
}
