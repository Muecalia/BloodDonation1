using BloodDonation.Core.Entities;
using BloodDonation.Core.Enuns;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodDonationContext _context;

        public BloodStockRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<BloodStock> Create(BloodStock bloodstock, CancellationToken cancellationToken)
        {
            _context.BloodStocks.Add(bloodstock);
            await _context.SaveChangesAsync(cancellationToken);
            return bloodstock;
        }

        public async Task Delete(BloodStock bloodstock, CancellationToken cancellationToken)
        {
            bloodstock.IsDeleted = true;
            bloodstock.DeletedAt = DateTime.Now;
            _context.BloodStocks.Update(bloodstock);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BloodStock>> GetAllBloodStocks(CancellationToken cancellationToken)
        {
            return await _context.BloodStocks.ToListAsync(cancellationToken);
        }

        public async Task<BloodStock?> GetBloodStock(int Id, CancellationToken cancellationToken)
        {
            return await _context.BloodStocks.FindAsync(Id, cancellationToken);
        }

        public Task<BloodStock?> GetBloodStockByType(BloodType BloodType, CancellationToken cancellationToken)
        {
            return _context.BloodStocks.FirstOrDefaultAsync(bs => bs.BloodType == BloodType, cancellationToken);
        }

        public async Task Update(BloodStock bloodstock, CancellationToken cancellationToken)
        {
            bloodstock.UpdatedAt = DateTime.Now;
            _context.BloodStocks.Update(bloodstock);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
