using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Kabel.DemoWPF.CustomControl.Assets
{
    public class ButtonExtended : Button
    {
        public ButtonExtended()
        {
            Text = String.Empty;
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
                               DependencyProperty.Register("Text", 
                                                           typeof(string), 
                                                           typeof(ButtonExtended), 
                                                           new PropertyMetadata());

    }
}
