using CatalogoVeiculo.Dados.Data;
using CatalogoVeiculo.Dados.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVeiculo.Dados.Services
{
    public interface IRepositoryService
    {
        IEnumerable<Veiculo> ObterTodosVeiculos();
        IEnumerable<Opcional> ObterTodosOpcionais();
    }
    public class RepositoryService : IRepositoryService
    {
        private readonly DataContext _context;
        public RepositoryService(DataContext a_Context)
        {
            _context = a_Context;
        }

        public IEnumerable<Veiculo> ObterTodosVeiculos()
        {         
            var l_retorno = _context.Set<Veiculo>()
                                .AsNoTracking()
                                .Include(x=>x.Opcionais)
                                .Include(x=>x.Fotos)
                                .ToList();
            return l_retorno;            
        }

        public IEnumerable<Opcional> ObterTodosOpcionais()
        {
            var l_retorno = _context.Set<Opcional>()
                                .AsNoTracking()                            
                                .ToList();
            return l_retorno;
        }
    }
}
