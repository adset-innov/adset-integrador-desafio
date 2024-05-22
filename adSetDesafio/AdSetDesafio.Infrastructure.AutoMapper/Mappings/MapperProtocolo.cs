using AutoMapper;
using AdSetDesafio.Domain.Commands.Veiculo;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Infrastructure.Extensions;
using AdSetDesafio.Infrastructure.ViewModel;

namespace AdSetDesafio.Infrastructure.AutoMapper.Mappings
{
    public class MapperVeiculo
    {
        public static void MapVeiculo(IProfileExpression profile)
        {

            profile.CreateMap<FotoVeiculo, FotoVeiculoViewModel>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<Veiculo, VeiculoViewModel>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<VeiculoViewModel, VeiculoCommandCreate>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<VeiculoViewModel, VeiculoCommandUpdate>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<VeiculoCommandCreate, Veiculo>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<VeiculoCommandUpdate, Veiculo>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();

            profile.CreateMap<PaginacaoDTO<Veiculo>, PaginacaoDTO<VeiculoViewModel>>()
                .IgnoreAllNonExisting()
                .ReverseMap()
                .IgnoreAllNonExisting();
        }
    }
}