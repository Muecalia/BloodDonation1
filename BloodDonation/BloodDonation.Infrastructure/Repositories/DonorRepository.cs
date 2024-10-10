using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        public readonly BloodDonationContext _context;

        public DonorRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Donor> Create(Donor donor, CancellationToken cancellationToken)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync(cancellationToken);
            return donor;
        }

        public async Task Delete(Donor donor, CancellationToken cancellationToken)
        {
            donor.IsDeleted = true;
            donor.DeletedAt = DateTime.Now;
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Donor>> GetAllDonors(CancellationToken cancellationToken)
        {
            return await _context.Donors
                .Include(d => d.Gender)
                .Include(d => d.Address)
                .Include(d => d.FactorRh)
                .ToListAsync(cancellationToken);
        }

        public async Task<Donor?> GetDonor(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donors.FindAsync(Id, cancellationToken);
        }

        public async Task<Donor?> GetDonorDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donors
                .Include(d => d.Gender)
                .Include(d => d.Address)
                .Include(d => d.FactorRh)
                .Include(d => d.Donations)
                .FirstOrDefaultAsync(d => d.Id == Id, cancellationToken);
        }

        public async Task<bool> IsDonorExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Donors.AnyAsync(d => string.Equals(d.Name, name), cancellationToken);
        }

        public async Task Update(Donor donor, CancellationToken cancellationToken)
        {
            donor.DeletedAt = DateTime.Now;
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
