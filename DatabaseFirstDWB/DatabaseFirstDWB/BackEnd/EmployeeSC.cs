using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class EmployeeSC : BaseSC
    {

        public IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.Select(s => s);
        }
        public Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }
        public void FireEmployee(int id)
        {
            var firedEmployee = GetEmployeeById(id);
            //Console.WriteLine(firedEmployee.FirstName);
            dbContext.Employees.Remove(firedEmployee);
            dbContext.SaveChanges();
        }
        public void UpdateEmployeeFirstNameById(int id, string name)
        {
            Employee currentEmployee = GetEmployeeById(id);
            if (currentEmployee == null)
            {
                throw new Exception("No se encontro el empleado con el ID proporcionado");
            }

            currentEmployee.FirstName = name;
            dbContext.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeeModel employee)
        {
            Employee currentEmplpyee = GetEmployeeById(id);
            if (currentEmplpyee == null)
            {
                throw new Exception("No se encontró el empleado con el ID proporcionado");
            }
            currentEmplpyee.FirstName = employee.Name;
            currentEmplpyee.LastName = employee.FamilyName;
            dbContext.SaveChanges();
        }

        public void AddEmployee(EmployeeModel newEmployee)
        {
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.FamilyName
            };

            dbContext.Employees.Add(newEmployeeRegister);
            dbContext.SaveChanges();

        }

    }
}
