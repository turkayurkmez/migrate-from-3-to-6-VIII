using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOfNETSix
{
    public class EmployeeService
    {
        private List<Employee> employees = new()
        {
            new(){ Id=1, FullName="Türkay Ürkmez", Salary=65000, City="Eskişehir"},
            new(){ Id=2, FullName="Damla Akdemir", Salary=100000, City="İstanbul"},
            new(){ Id=3, FullName="Buse Doğan", Salary=75000, City="İstanbul"}

        };

        public List<Employee> GetEmployees() => employees;
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
    }
}
