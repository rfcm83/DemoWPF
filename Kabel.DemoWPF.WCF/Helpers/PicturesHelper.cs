using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web;

namespace Kabel.DemoWPF.WCF.Helpers
{
    public static class PicturesHelper
    {
        const string PATH_PICTURES = "~/Pictures/{0}";
        public static bool ExistsPicture(string path)
        {
            path = HttpContext.Current.Server.MapPath(String.Format(PATH_PICTURES, path));
            return File.Exists(path);
        }
        public static String CreatePicture(byte[] input, string path)
        {
            var fullPath = HttpContext.Current.Server.MapPath(String.Format(PATH_PICTURES, path));
            if (File.Exists(fullPath)) return fullPath;
            if (input == null) throw new ArgumentNullException();
            try
            {
                File.WriteAllBytes(fullPath, input);
                return GetAbsoluteUrl(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static String GetAbsoluteUrl(string path)
        {
            var relativeUrl = new Uri(String.Format(PATH_PICTURES, path), UriKind.RelativeOrAbsolute).ToString();
            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;
            return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }

        private static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}