using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BloodDonationContext _context;

        public EmployeeRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        public async Task Delete(Employee employee, CancellationToken cancellationToken)
        {
            employee.IsDeleted = true;
            employee.DeletedAt = DateTime.Now;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Employee>> GetAllEmployees(CancellationToken cancellationToken)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetEmployee(int Id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(Id, cancellationToken);
        }

        public async Task<Employee?> GetEmployeeDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Donations)
                .FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);
        }

        public async Task<bool> IsEmployeeExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Employees.AnyAsync(e => string.Equals(e.Name, name), cancellationToken);
        }

        public async Task Update(Employee employee, CancellationToken cancellationToken)
        {
            employee.DeletedAt = DateTime.Now;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
