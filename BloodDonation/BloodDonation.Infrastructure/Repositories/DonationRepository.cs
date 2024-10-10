using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodDonationContext _context;

        public DonationRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Donation> Create(Donation donation, CancellationToken cancellationToken)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync(cancellationToken);
            return donation;
        }

        public async Task Delete(Donation donation, CancellationToken cancellationToken)
        {
            donation.IsDeleted = true;
            donation.DeletedAt = DateTime.Now;
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Donation>> GetAllDonations(CancellationToken cancellationToken)
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Employee)
                .ToListAsync();
        }

        public async Task<List<Donation>> GetAllDonationsByDonor(int IdDonor, CancellationToken cancellationToken)
        {
            return await _context.Donations
                .Include(d => d.Employee)
                .Where(d => d.IdDonor == IdDonor)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Donation>> GetAllDonationsByEmployee(int IdEmployee, CancellationToken cancellationToken)
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Where(d => d.IdEmployee == IdEmployee)
                .ToListAsync(cancellationToken);
        }

        public async Task<Donation?> GetDonation(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donations.FindAsync(Id, cancellationToken);
        }

        public async Task<Donation?> GetDonationDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donations
                .Include (d => d.Donor)
                .Include (d => d.Employee)
                .FirstOrDefaultAsync(d => d.Id == Id, cancellationToken);
        }

        public async Task<Donation?> GetDonorLastDonation(int IdDonor, CancellationToken cancellationToken)
        {
            return await _context.Donations.LastOrDefaultAsync(d => d.IdDonor == IdDonor, cancellationToken);
        }

        public async Task Update(Donation donation, CancellationToken cancellationToken)
        {
            donation.UpdatedAt = DateTime.Now;
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
