namespace ADSET.Domain.DTOs.Request
{
    public class VeiculoFotoRequest
    {
        public Guid VeiculoId { get; set; }
        public string Nome { get; set; }
        public Stream Stream { get; set; }
        public string ContentType { get; set; }

        public void ProcessName()
        {
            switch (this.ContentType)
            {
                case "image/jpg":
                    this.Nome += ".jpg";
                    break;
                case "image/jpeg":
                    this.Nome += ".jpeg";
                    break;
                case "image/png":
                    this.Nome += ".png";
                    break;
                default:
                    this.Nome += ".png";
                    break;
            }
        }
    }
}
