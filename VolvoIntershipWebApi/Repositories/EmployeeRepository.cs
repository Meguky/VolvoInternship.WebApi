using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoIntershipWebApi.Model;

namespace VolvoIntershipWebApi.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0,
                    FirstName = "John",
                    LastName = "Johnson",
                    Salary = 1500
                },
                new Employee()
                {
                    Id = 1,
                    FirstName = "Ann",
                    LastName = "Mason",
                    Salary = 1700
                }
            };
        }
        public void create(Employee employee)
        {
            if (employees.Where(e => e.Id == employee.Id).FirstOrDefault() == null)
            {
                employees.Add(employee);
            }
        }

        public List<Employee> get()
        {
            return employees;
        }

        public Employee get(int id)
        {
            return employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public void modify(int id, Employee employee)
        {
            if(employee.FirstName != null &&
               employee.FirstName != String.Empty &&
               employee.LastName != null  &&
               employee.LastName != String.Empty &&
               employees.Where(e => e.Id == id).FirstOrDefault() != null)
            {
                employees.Where(e => e.Id == id).FirstOrDefault().FirstName = employee.FirstName;
                employees.Where(e => e.Id == id).FirstOrDefault().LastName = employee.LastName;
                employees.Where(e => e.Id == id).FirstOrDefault().Salary = employee.Salary;
            }
        }

        public void delete(int id)
        {
            if(employees.Where(e => e.Id == id).FirstOrDefault() != null)
            {
                employees.Remove(employees.Where(p => p.Id == id).FirstOrDefault());
            }
        }
    }
}
