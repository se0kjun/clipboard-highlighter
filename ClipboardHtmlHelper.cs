using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardHtmlProj
{
    public static class ClipboardHtmlHelper
    {
        private const string HEADER = @"Version:0.9
StartHTML:<<<<<<<<1
EndHTML:<<<<<<<<2
StartFragment:<<<<<<<<3
EndFragment:<<<<<<<<4
StartSelection:<<<<<<<<3
EndSelection:<<<<<<<<4";


        private const string START_FRAGMENT = "<!--StartFragment-->";
        private const string END_FRAGMENT = "<!--EndFragment-->";

        private const string OPEN_HTML = "<html>";
        private const string CLOSE_HTML = "</html>";

        private const string OPEN_BODY = "<body>";
        private const string CLOSE_BODY = "</body>";

        public static string GetHtmlClipboardFormat(string html)
        {
            StringBuilder result = new StringBuilder();
            int fragmentStart = 0, fragmentEnd = 0;
            result.AppendLine(HEADER);
            
            if (!html.Contains("<html") || !html.Contains("<body"))
            {
                if(!html.Contains("<html"))
                    result.Append(OPEN_HTML);
                if (!html.Contains("<body"))
                    result.Append(OPEN_BODY);
            }
            result.Append(START_FRAGMENT);
            fragmentStart = result.ToString().Length;
            result.Append(html);
            result.Append(END_FRAGMENT);
            fragmentEnd = result.ToString().Length;

            if (!html.Contains("</html") || !html.Contains("</body"))
            {
                if (!html.Contains("</html"))
                    result.Append(CLOSE_HTML);
                if (!html.Contains("</body"))
                    result.Append(CLOSE_BODY);
            }

            result.Replace("<<<<<<<<1", HEADER.Length.ToString("D9"));
            result.Replace("<<<<<<<<2", result.Length.ToString("D9"));
            result.Replace("<<<<<<<<3", fragmentStart.ToString("D9"));
            result.Replace("<<<<<<<<4", fragmentEnd.ToString("D9"));

            return result.ToString();
        }
    }
}
