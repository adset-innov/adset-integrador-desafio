using AutoMapper;
using AdSetDesafio.Infrastructure.AutoMapper.Mappings;

namespace AdSetDesafio.Infrastructure.AutoMapper.AutoMapper
{
    public class DefaultApiProfile : Profile
    {
        public DefaultApiProfile()
        {
            MapperVeiculo.MapVeiculo(this);
            //MapperFotoVeiculo.MapFotoVeiculo(this);
            //MapperOpcional.MapOpcional(this);
            MapperAdaptersXlsx.MapAdaptersXlsx(this);
        }
    }
}