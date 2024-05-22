namespace ADSET.Web.DTOs.Responses
{
    public class CorResponse
    {
        public CorResponse()
        { }

        public CorResponse(string nome, bool selected)
        {
            this.Nome = nome;
            this.Selected = selected;
        }

        public string Nome { get; set; }
        public bool Selected { get; set; }
    }
}
