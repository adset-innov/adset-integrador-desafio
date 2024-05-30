using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdSetDesafio.Infrastructure.ViewModel
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public List<string> Fotos { get; set; }
        public int Opcional { get; set; }
        public int PacoteICarros { get; set; }
        public int PacoteWebMotors { get; set; }

        public IEnumerable<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Placa))
                results.Add(new("Placa do veículo deve ser informada"));

            if (string.IsNullOrWhiteSpace(Marca))
                results.Add(new("Marca do veículo deve ser informado"));

            if (string.IsNullOrWhiteSpace(Modelo))
                results.Add(new("Modelo do veículo deve ser informado"));

            if (Ano < 2000 && Ano > 2024)
                results.Add(new("Ano do veículo deve ser igual ou superior a 2000"));

            if (string.IsNullOrWhiteSpace(Cor))
                results.Add(new("Cor do veículo deve ser informada"));

            if (Preco < 10000)
                results.Add(new("Preço do veículo deve ser igual ou superior a 10000"));

            if (Fotos.Count > 15)
                results.Add(new("Só é permitido inserir até 15 fotos do veículo"));

            return results;
        }
    }
}
