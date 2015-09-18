using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kabel.DemoJornada2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _texto;

        public MainWindow()
        {
            InitializeComponent();
            this.MouseEnter += OnMouseEnter;
            this.DataContext = this;
        }

        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                OnPropertyChanged("Texto");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Texto += "hola";
        }
    }
}
