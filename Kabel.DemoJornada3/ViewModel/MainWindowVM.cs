using System.Collections.ObjectModel;
using System.Windows.Input;
using Kabel.DemoWPF3.Common;
using Kabel.DemoWPF3.Model;

namespace Kabel.DemoWPF3.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        private readonly WebViewer _wb = new WebViewer();
        private News _current;
        private ObservableCollection<News> _list;
        private ICommand _readUrl;
        private string _url;

        public ObservableCollection<News> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged("List");
            }
        }

        public News Current
        {
            get { return _current; }
            set
            {
                _current = value;
                if (!_wb.IsVisible)
                    _wb.Show();
                _wb.DataContext = value;
                OnPropertyChanged();
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }

        public ICommand ReadUrl
        {
            get { return _readUrl ?? (_readUrl = new RelayCommand(GetNews)); }
        }

        private async void GetNews(object sender)
        {
            List = await Client.ReadAsync(Url);
        }
    }
}