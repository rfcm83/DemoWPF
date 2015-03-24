using System.Collections.Generic;

namespace Kabel.DemoWPF.Binding.ViewModel
{
    public class MainWindowVM
    {
        public MainWindowVM()
        {
            Operations = new List<KeyValuePair<string, string>>() 
                                 { 
                                     new KeyValuePair<string, string>("+", "Addition"), 
                                     new KeyValuePair<string,string>("-", "Subtraction"),
                                     new KeyValuePair<string,string>("x", "Multiplication"),
                                     new KeyValuePair<string,string>("/", "Division")
                                 };
        }
        public List<KeyValuePair<string, string>> Operations { get; set; }
    }
}
