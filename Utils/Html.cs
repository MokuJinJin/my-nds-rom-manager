
namespace Utils
{
    using System.IO;
    using System.Net;
    
    public static class Html
    {
        /// <summary>
        /// Retreive HTML from a web Page
        /// </summary>
        /// <param name="resource">The Web Page</param>
        /// <returns>Html Code from the Web Page</returns>
        /// <remarks>Taken from C# 3.0 Cookbook</remarks>
        public static string GetHtmlFromUri(string resource)
        {
            string html = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }
            return html;
        } 
    }
}