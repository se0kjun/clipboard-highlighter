using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

using System.Windows.Forms;

namespace ClipboardHtmlProj
{
    class SyntaxHighlighter
    {
        private const string url = "http://128.199.75.155/syntax_request_server/main.php";

        private WebRequest request;
        private WebResponse response;

        public SyntaxHighlighter(string code, string language)
        {
            request = WebRequest.Create(url + "?code=" + HttpUtility.UrlEncode(code) + "&lang=" + language + "&size=" + ClipboardHighlighterProperty.instance.FontSize);
        }


        public string GetHighlightCode()
        {
            using(response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }
    }
}
