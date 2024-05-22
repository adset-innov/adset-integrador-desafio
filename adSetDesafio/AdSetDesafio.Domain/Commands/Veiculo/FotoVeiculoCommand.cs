using System;
using System.Collections.Generic;

namespace AdSetDesafio.Domain.Commands.Veiculo
{
    public abstract class FotoVeiculoCommand : Command
    {
        public int IdVeiculo { get; set; }
        public int IdGuid { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
    }
}