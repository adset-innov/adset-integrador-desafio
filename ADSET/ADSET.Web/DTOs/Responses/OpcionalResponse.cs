namespace ADSET.Web.DTOs.Responses
{
    public class OpcionalResponse
    {
        public OpcionalResponse()
        { }

        public OpcionalResponse(Guid id, string nome, bool selected)
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
