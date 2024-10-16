using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Crud_Api.Data
{
    public class EmpRepo
    {
        private readonly AppDbContext _context;

        public EmpRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmp()
        {
            return await _context.employees.ToListAsync();

        }

        public async Task<Employee> GetEmpById(int id)
        {
            return await _context.employees.FindAsync(id);
        }



        public async Task AddEmp(Employee emp)
        {
            await _context.employees.AddAsync(emp);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEmp(int id )
        {
           var deleteEmp =  await _context.employees.FindAsync(id);
             _context.Remove(deleteEmp);

            await _context.SaveChangesAsync();
        }


        public async Task UpdateaEmp(int id, Employee emp)
        {
            var exitingEmp = await _context.employees.FindAsync(id);
            if (exitingEmp != null)
            {
                exitingEmp.Name = emp.Name;
                exitingEmp.Email = emp.Email;
                exitingEmp.Salary = emp.Salary;
                exitingEmp.Age = emp.Age;
                exitingEmp.Contact = emp.Contact;

                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Bad Request"); ;
            }



        }

    }
}