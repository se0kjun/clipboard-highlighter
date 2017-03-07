using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

using System.Text.RegularExpressions;

namespace ClipboardHtmlProj
{
    class GoogleApiConnector
    {
        public static string GetShortenURL(string url)
        {
            string key = "/*input your key*/";
            string data = "{\"longUrl\":\""+ url + "\"}";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);

            try
            {
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    string shortUrl = Regex.Match(responseText, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;

                    return shortUrl;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
