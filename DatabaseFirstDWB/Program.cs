using System;

namespace DatabaseFirstDWB
{
    class Program
    {
        #region Services
        public static EmployeeSC employeeService = new EmployeeSC();
        #endregion
       
        public static void Exercise()
        {
            var employeeQry = employeeService.GetAllEmployees().Select(s => new
            {
                title = s.TitleOfCourtesy,
                name = s.FirstName,
                familyName = s.LastName
            }).Where(w => w.title == "Mr.");

            var result = employeeQry.ToList();
            result.ForEach(fe => Console.WriteLine(fe.title + " " + fe.name + " " + fe.familyName));
        }
      
        static void Main(string[] args)
        {
            Exercise();
        }
    }
}
