using AdSet.Dominio.Models;

namespace AdSet.Dominio.Services
{
    public interface IRepositoryService
    {
        Veiculo Get(Guid a_VeiculoId);
        List<Veiculo> GetAll();
        bool Save(Veiculo a_Veiculo);
        bool Update(Veiculo a_Veiculo);
        bool Delete(Veiculo a_Veiculo);
    }   

}
