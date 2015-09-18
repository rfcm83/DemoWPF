using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kabel.DemoJornada2.Assets
{
    public class ButtonExtended : Button
    {
        private int _clicks;

        public ButtonExtended()
        {
            this.Click += Clicked;
        }

        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            "IsBusy", typeof(bool), typeof(ButtonExtended), new PropertyMetadata(default(bool)));

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(ImageSource), typeof(ButtonExtended), new PropertyMetadata(default(ImageSource)));

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty ClicksProperty = DependencyProperty.Register(
            "Clicks", typeof(string), typeof(ButtonExtended), new PropertyMetadata(default(string)));

        public string Clicks
        {
            get { return (string)GetValue(ClicksProperty); }
            set { SetValue(ClicksProperty, value); }
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                _clicks++;
                Clicks = _clicks.ToString();
            }
        }
    }
}
