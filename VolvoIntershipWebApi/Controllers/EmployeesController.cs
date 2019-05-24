using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolvoIntershipWebApi.Repositories;
using VolvoIntershipWebApi.Model;
using Newtonsoft.Json;

namespace VolvoIntershipWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeeRepository.get();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return _employeeRepository.get(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Employee>> Delete(int id)
        {
            _employeeRepository.delete(id);
            return _employeeRepository.get();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Employee>> Post([FromBody] Employee employee)
        {
            _employeeRepository.create(employee);
            return _employeeRepository.get();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Employee>> Put([FromBody] Employee employee, int id)
        {
            _employeeRepository.modify(id, employee);
            return _employeeRepository.get();
        }

    }
}