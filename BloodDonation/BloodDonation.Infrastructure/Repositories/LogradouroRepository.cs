using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly BloodDonationContext _context;

        public LogradouroRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Logradouro> Create(Logradouro logradouro, CancellationToken cancellationToken)
        {
            _context.Logradouro.Add(logradouro);
            await _context.SaveChangesAsync();
            return logradouro;
        }

        public async Task Delete(Logradouro logradouro, CancellationToken cancellationToken)
        {
            logradouro.IsDeleted = true;
            logradouro.DeletedAt = DateTime.Now;
            _context.Logradouro.Update(logradouro);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Logradouro>> GetAllLogradouros(CancellationToken cancellationToken)
        {
            return await _context.Logradouro.ToListAsync(cancellationToken);
        }

        public async Task<Logradouro?> GetLogradouro(int Id, CancellationToken cancellationToken)
        {
            return await _context.Logradouro.FindAsync(Id, cancellationToken);
        }

        public async Task<bool> IsLogradouroExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Logradouro.AnyAsync(l => string.Equals(l.Name, name), cancellationToken);
        }

        public async Task Update(Logradouro logradouro, CancellationToken cancellationToken)
        {
            logradouro.UpdatedAt = DateTime.Now;
            _context.Logradouro.Update(logradouro);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
