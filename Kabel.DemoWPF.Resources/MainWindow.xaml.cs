using System;
using System.Collections;
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

namespace Kabel.DemoWPF.Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Brushes = new ObservableCollection<DictionaryEntry>();
            foreach (DictionaryEntry item in Resources)
            {
                if (item.Value is Brush)
                    Brushes.Add(item);
            }
            Brushes = new ObservableCollection<DictionaryEntry>(Brushes.OrderBy(x => x.Key).ToList());
            DataContext = this;
        }
        public ObservableCollection<DictionaryEntry> Brushes { get; set; }
    }
}
