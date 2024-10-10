using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface ICityRepository
    {
        Task<City> Create(City city, CancellationToken cancellationToken);
        Task Update(City city, CancellationToken cancellationToken);
        Task Delete(City city, CancellationToken cancellationToken);
        Task<bool> IsCityExist(string name, CancellationToken cancellationToken);
        Task<City?> GetCity(int Id, CancellationToken cancellationToken);
        Task<City?> GetCityDetail(int Id, CancellationToken cancellationToken);
        Task<List<City>> GetAllCities(CancellationToken cancellationToken);
        Task<List<City>> GetAllCitiesByState(int IdState, CancellationToken cancellationToken);
    }
}
