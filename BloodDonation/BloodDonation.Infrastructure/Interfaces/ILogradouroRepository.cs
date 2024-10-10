using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> Create(Logradouro logradouro, CancellationToken cancellationToken);
        Task Update(Logradouro logradouro, CancellationToken cancellationToken);
        Task Delete(Logradouro logradouro, CancellationToken cancellationToken);
        Task<bool> IsLogradouroExist(string name, CancellationToken cancellationToken);
        Task<Logradouro?> GetLogradouro(int Id, CancellationToken cancellationToken);
        //Task<Logradouro?> GetLogradouroDetail(int Id, CancellationToken cancellationToken);
        Task<List<Logradouro>> GetAllLogradouros(CancellationToken cancellationToken);
    }
}
