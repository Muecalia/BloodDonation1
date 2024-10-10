using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface IDonationRepository
    {
        Task<Donation> Create(Donation donation, CancellationToken cancellationToken);
        Task Update(Donation donation, CancellationToken cancellationToken);
        Task Delete(Donation donation, CancellationToken cancellationToken);
        //Task<bool> IsDateDonationValide(int IdDonor, DateTime date, CancellationToken cancellationToken);
        Task<Donation?> GetDonation(int Id, CancellationToken cancellationToken);
        Task<Donation?> GetDonorLastDonation(int IdDonor, CancellationToken cancellationToken);
        Task<Donation?> GetDonationDetail(int Id, CancellationToken cancellationToken);
        Task<List<Donation>> GetAllDonations(CancellationToken cancellationToken);
        Task<List<Donation>> GetAllDonationsByDonor(int IdDonor, CancellationToken cancellationToken);
        Task<List<Donation>> GetAllDonationsByEmployee(int IdEmployee, CancellationToken cancellationToken);
    }
}
