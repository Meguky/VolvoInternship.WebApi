using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolvoIntershipWebApi.Model;
using VolvoIntershipWebApi.Repositories;

namespace VolvoIntershipWebApiTests
{
    class EmployeesRepositoryTests
    {
        List<Employee> list;

        [SetUp]
        public void setup()
        {
            list = initData();
        }

        [Test]
        public void CreateEmployees_ShouldReturnTwoEmployees()
        {
            
            EmployeeRepository controller = new EmployeeRepository();
            controller.create(new Employee()
            {
                Id = 0,
                FirstName = "John",
                LastName = "Johnson",
                Salary = 1500
            });

            controller.create(new Employee()
            {
                Id = 1,
                FirstName = "Ann",
                LastName = "Mason",
                Salary = 1700
            });
            Assert.AreEqual(2, controller.employees.Count);
        }

        public void CreateEmployeesWithExistingId_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;
            Assert.AreEqual(false, controller.create(new Employee() {
                Id = 1,
                FirstName = "Another",
                LastName = "IdTheSame",
                Salary = 1700
            }));
        }

        [Test]
        public void getEmployees_ShouldReturnAllEmployes()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(2, controller.get().Count);
        }
        [Test]
        public void getEmployeeById_ShouldReturnJohnJohnson()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;
            Assert.AreEqual("John", controller.get(0).FirstName);
            Assert.AreEqual("Johnson", controller.get(0).LastName);
        }

        [Test]
        public void deleteEmployeeByIdMinusOne_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.delete(-1));
        }

        [Test]
        public void deleteEmployeeByIdZero_ShouldReturnTrue()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(true, controller.delete(0));
        }

        [Test]
        public void modifyEmployeeGoodData_ShouldReturnTrue()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(true, controller.modify(0, new Employee(){
                FirstName = "Another",
                LastName = "EmployeeModified",
                Salary = 3000
            }));
        }
        [Test]
        public void modifyEmployeeBadFirstName_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.modify(0, new Employee()
            {
                FirstName = "",
                LastName = "EmployeeModified",
                Salary = 3000
            }));
        }
        [Test]
        public void modifyEmployeeBadLastName_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.modify(0, new Employee()
            {
                FirstName = "Another",
                LastName = "",
                Salary = 3000
            }));
        }
        [Test]
        public void modifyEmployeeBadSalary_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.modify(0, new Employee()
            {
                FirstName = "Another",
                LastName = "EmployeeModified",
                Salary = -1200
            }));
        }
        [Test]
        public void modifyEmployeeBadIdMinusOne_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.modify(-1, new Employee()
            {
                FirstName = "Another",
                LastName = "EmployeeModified",
                Salary = 1200
            }));
        }
        [Test]
        public void modifyEmployeeBadIdNotExisting_ShouldReturnFalse()
        {
            EmployeeRepository controller = new EmployeeRepository();
            controller.employees = list;

            Assert.AreEqual(false, controller.modify(5, new Employee()
            {
                FirstName = "Another",
                LastName = "EmployeeModified",
                Salary = 1200
            }));
        }

        public List<Employee> initData()
        {
            return new List<Employee>()
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
    }
}
