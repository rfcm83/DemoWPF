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

namespace Kabel.DemoWPF.Graphics
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
                case "Ellipse":
                    window.Content = new Assets.EllipseSample();
                    break;
                case "Line":
                    window.Content = new Assets.LineSample();
                    break;
                case "Path":
                    window.Content = new Assets.PathSample();
                    break;
                case "Polygon":
                    window.Content = new Assets.PolygonSample();
                    break;
                case "Polyline":
                    window.Content = new Assets.PolylineSample();
                    break;
                case "Rectangle":
                    window.Content = new Assets.RectangleSample();
                    break;
                case "Image":
                    window.Content = new Assets.ImageSample();
                    break;
                default:
                    return;
            }
            window.Title = title;
            window.ShowDialog();
        }
    }
}
