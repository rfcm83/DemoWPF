using System;
using System.Collections.Generic;
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

namespace Kabel.DemoWPF.Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;
            var title = btn.Content.ToString();
            var window = new Assets.ContentDialog();
            switch (title)
            {
                case "StackPanel":
                    window.Content = new Assets.StackSample();
                    break;
                case "WrapPanel":
                    window.Content = new Assets.WrapSample();
                    break;
                case "DockPanel":
                    window.Content = new Assets.DockSample();
                    break;
                case "ScrollViewer":
                    window.Content = new Assets.ScrollSample();
                    break;
                case "Grid":
                    window.Content = new Assets.GridSample();
                    break;
                case "Canvas":
                    window.Content = new Assets.CanvasSample();
                    break;
                case "Viewbox":
                    window.Content = new Assets.ViewboxSample();
                    break;
                case "UniformGrid":
                    window.Content = new Assets.UniformGridSample();
                    break;
                default:
                    return;
            }
            window.Title = title;
            window.ShowDialog();
        }
    }
}
