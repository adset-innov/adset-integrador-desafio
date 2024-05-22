namespace ADSET.Web.DTOs.Responses
{
    public class MarcaResponse
    {

        public MarcaResponse()
        { }

        public MarcaResponse(Guid id, string nome, bool selected, List<ModeloResponse> modelos)
        {
            this.Id = id;
            this.Nome = nome;
            this.Selected = selected;
            this.Modelos = modelos;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Selected { get; set; }
        public List<ModeloResponse> Modelos { get; set; }
    }
}
