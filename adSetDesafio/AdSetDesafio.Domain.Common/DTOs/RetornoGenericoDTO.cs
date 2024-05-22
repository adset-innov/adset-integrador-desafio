namespace AdSetDesafio.Domain.Common.DTOs
{
    public class RetornoGenericoDTO<T>
    {
        public long Id { get; set; }
        public T Item { get; set; }
        public string Mensagem { get; set; }
    }
}