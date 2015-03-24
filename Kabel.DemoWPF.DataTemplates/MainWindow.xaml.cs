using Kabel.DemoWPF.Proxy;
using Kabel.DemoWPF.Proxy.NorthWindServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kabel.DemoWPF.DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Employee> _headers;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            GetEmployees();
        }

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public ObservableCollection<Employee> Headers
        {
            get { return _headers; }
            set
            {
                _headers = value;
                OnPropertyChanged("Headers");
            }
        }

        private void GetEmployees()
        {
            Services.Client.GetEmployeesCompleted += GetEmployeesCompleted;
            Services.Client.GetEmployeesAsync();
        }

        private void GetEmployeesCompleted(object sender, GetEmployeesCompletedEventArgs e)
        {
            Services.Client.GetEmployeesCompleted -= GetEmployeesCompleted;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                Employees = e.Result;
                Headers = new ObservableCollection<Employee>(Employees.Where(x => x.ReportsTo == null).ToList());
            }

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
