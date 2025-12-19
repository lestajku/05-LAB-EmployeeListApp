using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        private readonly AppDbContext _db;

        public EmployeesService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _db.Employees.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Id))
                employee.Id = Guid.NewGuid().ToString();

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
        }
    }
}
