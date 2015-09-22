using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kabel.DemoWPF3.Model
{
    public class Client
    {
        public async static Task<ObservableCollection<News>> ReadAsync(string url)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentNullException("url");

            try
            {
                var xDocument = XDocument.Load(url);
                var items = from x in xDocument.Descendants("item")
                            select new News
                            {
                                Description = x.Elements().First(y => y.Name == "description").Value,
                                Title = x.Elements().First(y => y.Name == "title").Value,
                                Url = new Uri(x.Elements().First(y => y.Name == "link").Value)
                            };
                await Task.Run(() => System.Threading.Thread.Sleep(2000));
                return new ObservableCollection<News>(items);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ObservableCollection<News> Read(string url)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentNullException("url");

            try
            {
                var xDocument = XDocument.Load(url);
                var items = from x in xDocument.Descendants("item")
                            select new News()
                            {
                                Description = x.Elements().First(y => y.Name == "description").Value,
                                Title = x.Elements().First(y => y.Name == "title").Value,
                                Url = new Uri(x.Elements().First(y => y.Name == "link").Value)
                            };
                
                return new ObservableCollection<News>(items);
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
