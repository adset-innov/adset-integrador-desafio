using AutoMapper;
using AdSetDesafio.Adapters.XLSX.Models;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Infrastructure.Extensions;
using AdSetDesafio.Infrastructure.ViewModel;

namespace AdSetDesafio.Infrastructure.AutoMapper.Mappings
{
    public class MapperAdaptersXlsx
    {
        public static void MapAdaptersXlsx(IProfileExpression profile)
        {

            profile.CreateMap<Veiculo, VeiculoExport>()
                .ForMember(x => x.Marca, opt => opt.MapFrom(x => x.Marca))
                .ForMember(x => x.Modelo, opt => opt.MapFrom(x => x.Modelo))
                .ForMember(x => x.Ano, opt => opt.MapFrom(x => x.Ano))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.Placa))
                .ForMember(x => x.Km, opt => opt.MapFrom(x => x.Km))
                .ForMember(x => x.Cor, opt => opt.MapFrom(x => x.Cor))
                .ForMember(x => x.Preco, opt => opt.MapFrom(x => x.Preco));
        }
    }
}