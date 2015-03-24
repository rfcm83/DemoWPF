using Kabel.DemoWPF.Client.Common;
using Kabel.DemoWPF.Proxy.NorthWindServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kabel.DemoWPF.Client.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        private readonly ServicesClient _proxy;
        private ICommand _newItem;
        private ICommand _saveItem;
        private ICommand _deleteItem;
        private ICommand _refreshItems;

        private ObservableCollection<Customer> _customers;
        private Customer _current;
        private bool _isEditing;
        private bool _isAdding;
        private bool _isBusy;

        public MainWindowVM()
        {
            _proxy = new ServicesClient();
            _proxy.GetCustomersCompleted += GetCustomersCompleted;
            _proxy.GetCustomerCompleted += GetCustomerCompleted;
            _proxy.NewCustomerCompleted += NewCustomerCompleted;
            _proxy.UpdateCustomerCompleted += UpdateCustomerCompleted;
            _proxy.DeleteCustomerCompleted += DeleteCustomerCompleted;
            Customers = new ObservableCollection<Customer>();
            Refresh(null);
            IsBusy = true;
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChange("Customers");
            }
        }

        public Customer Current
        {
            get { return _current; }
            set
            {
                if (!IsEditing || (IsEditing && PromptUser("Cancel Edit Item")))
                {
                    _current = value;
                }
                OnPropertyChange("Current");
            }
        }

        public bool IsAdding
        {
            get { return _isAdding; }
            set
            {
                _isAdding = value;
                OnPropertyChange("IsAdding");
            }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChange("IsEditing");
                if (!_isEditing) Cancel();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChange("IsBusy");
            }
        }

        public ICommand NewItem
        {
            get { return _newItem ?? (_newItem = new RelayCommand(Add)); }
        }

        public ICommand SaveItem
        {
            get { return _saveItem ?? (_saveItem = new RelayCommand(Save)); }
        }

        public ICommand DeleteItem
        {
            get { return _deleteItem ?? (_deleteItem = new RelayCommand(Delete)); }
        }

        public ICommand RefreshItems
        {
            get { return _refreshItems ?? (_refreshItems = new RelayCommand(Refresh)); }
        }

        private void Add(object sender)
        {
            var customer = new Customer();
            Customers.Add(customer);
            Current = customer;
            IsAdding = true;
            IsEditing = true;
        }

        private void Cancel()
        {
            if (IsAdding)
            {
                IsAdding = false;
                Customers.Remove(Current);
                Current = Customers.LastOrDefault();
            }
            else
            {
                Refresh(null);
            }
        }

        private void Save(object sender)
        {
            if (IsEditing && IsAdding)
            {
                IsBusy = true;
                _proxy.NewCustomerAsync(Current);
            }
            else if (IsEditing && !IsAdding)
            {
                IsBusy = true;
                _proxy.UpdateCustomerAsync(Current);
            }
        }

        private void Delete(object sender)
        {
            if (!IsEditing)
            {
                var result = PromptUser("Delete Item");
                if (result)
                {
                    IsBusy = true;
                    _proxy.DeleteCustomerAsync(Current);
                }
            }
        }

        private void Refresh(object sender)
        {
            IsBusy = true;
            if (IsEditing)
            {
                _proxy.GetCustomerAsync(Current.CustomerID);
            }
            else
            {
                _proxy.GetCustomersAsync();
            }
        }

        private bool PromptUser(string title)
        {
            var result = MessageBox.Show("Are you sure?", title, MessageBoxButton.YesNo);
            return result == MessageBoxResult.Yes;
        }

        private void GetCustomersCompleted(object sender, GetCustomersCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Customers = e.Result;
                if (Current == null)
                {
                    Current = Customers.FirstOrDefault();
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            IsBusy = false;
        }

        private void GetCustomerCompleted(object sender, GetCustomerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Current = e.Result;
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            IsBusy = false;
        }

        private void NewCustomerCompleted(object sender, NewCustomerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IsAdding = false; 
                IsEditing = false;
                Current = e.Result;
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            IsBusy = false;
        }

        private void UpdateCustomerCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IsEditing = false;
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            IsBusy = false;
        }

        private void DeleteCustomerCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Customers.Remove(Current);
                IsEditing = false;
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
            IsBusy = false;
        }
    }
}
