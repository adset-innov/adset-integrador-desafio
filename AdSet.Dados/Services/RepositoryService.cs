using AdSet.Dados.Contexts;
using AdSet.Dominio.Models;
using AdSet.Dominio.Services;

namespace AdSet.Dados.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly AppDbContext _context;
        public RepositoryService(AppDbContext a_Context)
        {
            _context = a_Context;
        }

        public bool Delete(Veiculo a_Veiculo)
        {
            throw new NotImplementedException();
        }

        public Veiculo Get(Guid a_VeiculoId)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> GetAll()
        {
            return new List<Veiculo>() { };
        }

        public bool Save(Veiculo a_Veiculo)
        {
            throw new NotImplementedException();
        }

        public bool Update(Veiculo a_Veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
