using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly BloodDonationContext _context;

        public CityRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<City> Create(City city, CancellationToken cancellationToken)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync(cancellationToken);
            return city;
        }

        public async Task Delete(City city, CancellationToken cancellationToken)
        {
            city.IsDeleted = true;
            city.DeletedAt = DateTime.Now;
            _context.Cities.Update(city);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<City>> GetAllCities(CancellationToken cancellationToken)
        {
            return await _context.Cities
                .Include(c => c.State)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<City>> GetAllCitiesByState(int IdState, CancellationToken cancellationToken)
        {
            return await _context.Cities
                .Where(c => c.IdState == IdState)
                .ToListAsync(cancellationToken);
        }

        public async Task<City?> GetCity(int Id, CancellationToken cancellationToken)
        {
            return await _context.Cities.FindAsync(Id, cancellationToken);
        }

        public async Task<City?> GetCityDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Cities
                .Include(c => c.State)
                .FirstOrDefaultAsync(c => c.Id == Id, cancellationToken);
        }

        public async Task<bool> IsCityExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Cities.AnyAsync(c => string.Equals(c.Name, name), cancellationToken);
        }

        public async Task Update(City city, CancellationToken cancellationToken)
        {
            city.UpdatedAt = DateTime.Now;
            _context.Cities.Update(city);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
