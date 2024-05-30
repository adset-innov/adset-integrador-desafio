using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AdSetDesafio.Domain.Commands.Veiculo
{
    public abstract class VeiculoCommand : Command
    {

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public int Opcional { get; set; }
        public int PacoteICarros { get; set; }
        public int PacoteWebMotors { get; set; }
        public List<string> Fotos { get; set; }
    }
}