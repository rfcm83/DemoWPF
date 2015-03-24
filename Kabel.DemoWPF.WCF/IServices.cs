using Kabel.DemoWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Kabel.DemoWPF.WCF
{
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        Employee[] GetEmployees();

        [OperationContract]
        Employee GetEmployee(int id);

        [OperationContract]
        Category[] GetCategories();

        [OperationContract]
        Customer[] GetCustomers();

        [OperationContract]
        Customer GetCustomer(string id);

        [OperationContract]
        Customer NewCustomer(Customer customer);

        [OperationContract]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        void DeleteCustomer(Customer customer);
    }
}
