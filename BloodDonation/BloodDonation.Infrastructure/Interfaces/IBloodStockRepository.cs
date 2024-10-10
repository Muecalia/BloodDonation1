using BloodDonation.Core.Entities;
using BloodDonation.Core.Enuns;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface IBloodStockRepository
    {
        Task<BloodStock> Create(BloodStock bloodstock, CancellationToken cancellationToken);
        Task Update(BloodStock bloodstock, CancellationToken cancellationToken);
        Task Delete(BloodStock bloodstock, CancellationToken cancellationToken);
        Task<BloodStock?> GetBloodStock(int Id, CancellationToken cancellationToken);
        //Task<BloodStock?> GetBloodStockByType(int BloodTypeId, CancellationToken cancellationToken);
        Task<BloodStock?> GetBloodStockByType(BloodType BloodType, CancellationToken cancellationToken);
        //Task<BloodStock?> GetBloodStockDetail(int Id, CancellationToken cancellationToken);
        Task<List<BloodStock>> GetAllBloodStocks(CancellationToken cancellationToken);
    }
}
