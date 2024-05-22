using System.Collections.Generic;

namespace ClassLibrary
{
    public class Car
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public double? Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public List<string> Opcionais { get; set; }
        public List<byte[]> Fotos { get; set; }
        public string Pacote { get; set; } 

        public Car()
        {
            Opcionais = new List<string>();
            Fotos = new List<byte[]>();
        }
    }
}
