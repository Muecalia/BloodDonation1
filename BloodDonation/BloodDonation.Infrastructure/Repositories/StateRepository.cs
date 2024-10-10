using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly BloodDonationContext _context;

        public StateRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<State> Create(State state, CancellationToken cancellationToken)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync(cancellationToken);
            return state;
        }

        public async Task Delete(State state, CancellationToken cancellationToken)
        {
            state.IsDeleted = true;
            state.DeletedAt = DateTime.Now;
            _context.States.Update(state);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<State>> GetAllStates(CancellationToken cancellationToken)
        {
            return await _context.States.ToListAsync(cancellationToken);
        }

        public async Task<State?> GetState(int Id, CancellationToken cancellationToken)
        {
            return await _context.States.FindAsync(Id, cancellationToken);
        }

        public async Task<bool> IsStateExist(string name, CancellationToken cancellationToken)
        {
            return await _context.States.AnyAsync(s => string.Equals(s.Name, name), cancellationToken);
        }

        public async Task Update(State state, CancellationToken cancellationToken)
        {
            state.UpdatedAt = DateTime.Now;
            _context.States.Update(state);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
