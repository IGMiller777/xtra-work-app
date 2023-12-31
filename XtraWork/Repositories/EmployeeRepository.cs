using Microsoft.EntityFrameworkCore;
using XtraWork.Entities;

namespace XtraWork.Repositories;

public class EmployeeRepository
{
    private readonly XtraWorkContext _context;

    public EmployeeRepository(XtraWorkContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Employees
            .Include(x => x.Title)
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync();
    }

    public async Task<Employee> Get(int id)
    {
        return await _context.Employees
            .Include(x => x.Title)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Employee>> Search(string keyword)
    {
        return await _context.Employees
            .Include(x => x.Title)
            .Where(a => a.FirstName.Contains(keyword) || a.LastName.Contains(keyword))
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .ToListAsync();
    }

    public async Task<Employee> Create(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        _context.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        _context.Remove(employee);
        await _context.SaveChangesAsync();
    }
}