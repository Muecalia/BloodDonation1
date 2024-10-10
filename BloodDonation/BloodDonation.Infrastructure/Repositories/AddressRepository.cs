using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;

namespace BloodDonation.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BloodDonationContext _context;

        public AddressRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Address> Create(Address address, CancellationToken cancellationToken)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync(cancellationToken);
            return address;
        }

        public async Task Delete(Address address, CancellationToken cancellationToken)
        {
            address.IsDeleted = true;
            address.DeletedAt = DateTime.Now;
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Address address, CancellationToken cancellationToken)
        {
            address.DeletedAt = DateTime.Now;
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
