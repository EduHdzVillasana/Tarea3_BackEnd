using DatabaseFirstDWB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.Backend
{

    class EmployeeSC: BaseSC
    {

        public static IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.Select(s => s);

        }

        public static Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().Where(w => w.Employee.id == id).FirstOrDefault();
        }

    }
}