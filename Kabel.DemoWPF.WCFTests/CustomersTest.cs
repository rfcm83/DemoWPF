using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kabel.DemoWPF.WCF;
using Kabel.DemoWPF.Model;

namespace Kabel.DemoWPF.WCFTests
{
    [TestClass]
    public class CustomersTest
    {
        private readonly Services _target = new Services();

        [TestMethod]
        public void GetCustomers()
        {
            var list = _target.GetCustomers();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetCustomer()
        {
            var customer = _target.GetCustomer("ALFKI");
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCustomerNull()
        {
            _target.GetCustomer(String.Empty);
        }

        [TestMethod]
        public void NewCustomer()
        {
            var customer = DummyCustomer();
            var result = _target.NewCustomer(customer);
            Assert.IsNotNull(result);
            DeleteCustomer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewCustomerNull()
        {
            _target.NewCustomer(null);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var result = _target.GetCustomer("ALFKI");
            Assert.IsNotNull(result);
            result.City = "Madrid";
            _target.UpdateCustomer(result);
            var newResult = _target.GetCustomer("ALFKI");
            Assert.AreSame(result, newResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateCustomerNull()
        {
            _target.UpdateCustomer(null);
        }

        public void DeleteCustomer()
        {
            _target.DeleteCustomer(DummyCustomer());
            var newResult = _target.GetCustomer("RFDCM");
            Assert.IsNull(newResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteCustomerNull()
        {
            _target.DeleteCustomer(null);
        }

        private Customer DummyCustomer()
        {
            return new Customer()
                       {
                           CustomerID = "RFDCM",
                           CompanyName = "Kabel",
                           ContactName = "Raúl Test",
                           ContactTitle = "Software Architect",
                           Address = "Foronda 4",
                           City = "Loeches",
                           PostalCode = "28890",
                           Country = "Spain",
                           Phone = "91111111",
                           Fax = "91111112"
                       };
        }
    }
}
