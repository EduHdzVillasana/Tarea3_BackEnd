using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.BackEnd
{
    public class CustomerSC : BaseSC
    {
        public IQueryable<Customer> GetAllCustomers ()
        {
            return dbContext.Customers.Select(s => s);
        }

        public Customer GetCustomerById (string id)
        {
            return GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
        }

        public void RemoveCustomer (string id)
        {
            var removedCustomer = GetCustomerById(id);
            dbContext.Customers.Remove(removedCustomer);
            dbContext.SaveChanges();
        }

        public void UpdateCustomer (string id, CustomerModel customer)
        {
            Customer currentCustomer = GetCustomerById(id);
            if (currentCustomer == null)
            {
                throw new Exception("No se encontró el cliente con el ID proporcionado");
            }
            currentCustomer.CompanyName = customer.name;
            currentCustomer.City = customer.cityName;
            currentCustomer.Phone = customer.phoneNumber;

            dbContext.SaveChanges();
        }

        public void AddCustomer (CustomerModel newCustomer)
        {
            var newCustomerRegister = new Customer()
            {
                CustomerId = newCustomer.idString,
                CompanyName = newCustomer.name,
                City = newCustomer.cityName,
                Phone = newCustomer.phoneNumber
            };

            dbContext.Customers.Add(newCustomerRegister);
            dbContext.SaveChanges();
        }
    }
}
