using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IList<Employee> Employees;

        public EmployeeRepository(IList<Employee> employees)
        {
            Employees = employees;
        }

        public Employee GetEmployeeByID(int ID)
        {
            return Employees.FirstOrDefault(e => e.ID == ID);
        }
    }
}
