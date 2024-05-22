using ADSET.Domain.Entities;

namespace ADSET.Infra.Data.Seed
{
    public static class OpcionalSeed
    {
        public static List<Opcional> CreateSeed()
        {
            return new List<Opcional>() 
            { 
                new("Ar Condicionado"),
                new("Teto Solar"),
                new("Alarme"),
                new("Air Bag"),
                new("Som"),
                new("Trava Elétrica"),
                new("Vidro Elétrico"),
                new("Sensor de Ré"),
                new("Câmera de Ré"),
                new("Banco de Couro")
            };
        }
    }
}
