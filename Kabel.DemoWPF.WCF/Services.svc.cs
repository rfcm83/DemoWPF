using Kabel.DemoWPF.Model;
using Kabel.DemoWPF.WCF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;

namespace Kabel.DemoWPF.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Services : IServices
    {
        private readonly NorthWindEntities _context;

        public Services()
        {
            _context = new NorthWindEntities();
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        public Employee[] GetEmployees()
        {
            List<Employee> list = _context.Employees.ToList();
            foreach (Employee employee in list)
            {
                employee.PhotoPath = PicturesHelper.ExistsPicture(employee.PhotoPath)
                                   ? PicturesHelper.GetAbsoluteUrl(employee.PhotoPath)
                                   : PicturesHelper.CreatePicture(employee.Photo, employee.PhotoPath);

                employee.Photo = null;
            }
            return list.ToArray();
        }

        public Employee GetEmployee(int id)
        {
            return GetEmployees().FirstOrDefault(x => x.EmployeeID == id);
        }

        public Category[] GetCategories()
        {
            return _context.Categories.ToArray();
        }

        public Customer[] GetCustomers()
        {
            return _context.Customers.ToArray();
        }

        public Customer GetCustomer(string id)
        {
            if (String.IsNullOrEmpty(id)) throw new ArgumentNullException();
            return _context.Customers.FirstOrDefault(x => x.CustomerID == id);
        }

        public Customer NewCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();
            try
            {
                customer = _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();
            try
            {
                var original = _context.Customers.Find(customer.CustomerID);

                if (original != null)
                {
                    _context.Entry(original).CurrentValues.SetValues(customer);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            try
            {
                var original = _context.Customers.Find(customer.CustomerID);

                if (original != null)
                {
                    _context.Customers.Remove(original);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
