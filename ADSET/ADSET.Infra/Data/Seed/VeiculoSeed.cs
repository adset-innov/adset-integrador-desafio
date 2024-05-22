using ADSET.Domain.Entities;

namespace ADSET.Infra.Data.Seed
{
    public class VeiculoSeed
    {
        private readonly List<Modelo> _modelos;
        private readonly List<Opcional> _opcionais;

        public VeiculoSeed(List<Modelo> modelos, List<Opcional> opcionais)
        {
            _modelos = modelos;
            _opcionais = opcionais;
        }

        public List<Veiculo> CreateSeed()
        {
            return new List<Veiculo>() 
            {
                CriaVeiculo(_modelos[1], 2015, "ABC1D34", 0, "Preto", 89999),
                CriaVeiculo(_modelos[2], 2011, "CBD1D34", 0, "Branco", 59999),
                CriaVeiculo(_modelos[3], 2012, "CNH1D34", 0, "Prata", 49999),
                CriaVeiculo(_modelos[4], 2019, "CAB1D34", 0, "Vermelho", 99999),
                CriaVeiculo(_modelos[5], 2020, "DCA1D34", 0, "Azul", 109999),
            };
        }

        private Veiculo CriaVeiculo(Modelo modelo, int ano, string placa, int Km, string cor, decimal preco)
        {
            var veiculo = new Veiculo(modelo.MarcaId, modelo.Id, ano, placa, cor, preco)
            {
                Marca = modelo.Marca,
                Modelo = modelo,
                HaveFoto = false,
                Km = Km,
            };

            var opcionais = _opcionais
                .Select(o => new VeiculoOpcional(veiculo.Id, o.Id)
                {
                    Veiculo = veiculo,
                    Opcional = o
                }).ToList();

            return veiculo;
        }
    }
}
