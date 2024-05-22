namespace ADSET.Web.DTOs.Responses
{
    public class ModeloResponse
    {
        public ModeloResponse()
        { }

        public ModeloResponse(Guid id, string nome, bool selected)
        {
            this.Id = id;
            this.Nome = nome;
            this.Selected = selected;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Selected { get; set; }

    }
}
