//-----------------------------------------------------------------------
// <copyright file="Html.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2012
// </copyright>
//-----------------------------------------------------------------------

namespace Utils
{
    using System.IO;
    using System.Net;
    
    /// <summary>
    /// Class which helps with the Html/Web
    /// </summary>
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
            var req = (HttpWebRequest)WebRequest.Create(resource);
            using (var resp = (HttpWebResponse)req.GetResponse())
            {
                var success = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                
                if (success)
                {
                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }

            return html;
        } 
    }
}