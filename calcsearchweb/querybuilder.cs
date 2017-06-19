using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
namespace calcsearchweb
{
    public class querybuilder
    {
        public string queryPart = "";
        public string html = string.Empty;
        public void read_query(string key, string value, int count)
        {
            if (count == 0)
                queryPart += HttpUtility.UrlEncode("&$filter=");
            queryPart += HttpUtility.UrlEncode(key + " eq " + "'" + value + "'" + " and ");

        }

        public void keyword_search(string key)
        {
            queryPart += HttpUtility.UrlEncode(key);

        }
        public string exec_query()
        {

            int pos = queryPart.LastIndexOf("+and+");

            if (pos >= 0)
                queryPart = queryPart.Remove(pos);

            string url = $"https://agneevsearch.search.windows.net/indexes/trace-index/docs?api-version=2016-09-01&search={queryPart}";
            url = HttpUtility.UrlDecode(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["api-key"] = "62FBBB4DFF6DB1BA2E00836D43E8B85B";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            html = html.Replace("\\r\\n", "\r\n");
            html = html.Replace('\\', ' ');

            return html;

        }
    }
}