using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee employee, CancellationToken cancellationToken);
        Task Update(Employee employee, CancellationToken cancellationToken);
        Task Delete(Employee employee, CancellationToken cancellationToken);
        Task<bool> IsEmployeeExist(string name, CancellationToken cancellationToken);
        Task<Employee?> GetEmployee(int Id, CancellationToken cancellationToken);
        Task<Employee?> GetEmployeeDetail(int Id, CancellationToken cancellationToken);
        Task<List<Employee>> GetAllEmployees(CancellationToken cancellationToken);
    }
}
