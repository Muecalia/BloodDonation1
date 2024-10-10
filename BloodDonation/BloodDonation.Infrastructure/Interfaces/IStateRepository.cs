using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface IStateRepository
    {
        Task<State> Create(State state, CancellationToken cancellationToken);
        Task Update(State state, CancellationToken cancellationToken);
        Task Delete(State state, CancellationToken cancellationToken);
        Task<bool> IsStateExist(string name, CancellationToken cancellationToken);
        Task<State?> GetState(int Id, CancellationToken cancellationToken);
        //Task<State?> GetStateDetail(int Id, CancellationToken cancellationToken);
        Task<List<State>> GetAllStates(CancellationToken cancellationToken);
    }
}
