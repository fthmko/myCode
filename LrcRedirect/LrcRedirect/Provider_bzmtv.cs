using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LrcRedirect
{
    public class Provider_bzmtv : LrcProvider
    {
        static string lrcSite = "http://lrc.bzmtv.com/";
        static string searchUrl = "So.asp?key={0}&go=go&y=1";

        static string encode = "GB2312";

        private string _str = "bzmtv";
        private HttpClient hc;
        private string temp;

        public string Str
        {
            get { return _str; }
        }

        public Provider_bzmtv(HttpClient client){
            hc = client;
        }

        public void Search(string song, string artist, List<String> result)
        {
            List<string> ret = new List<string>();
            String data = "";
            String url = lrcSite + String.Format(searchUrl, HttpUtility.UrlEncode(song, Encoding.GetEncoding(encode)));

            data = hc.GetSrc(url, encode, out temp).Replace(" ", "").Replace("\r", "").Replace("\n", "");

            MatchCollection mcs = Regex.Matches(data, "<li>.*?divclass=\"slmc\"><ahref=\"(LRC.*?.htm)\"target=_blank>(.*?)</a>.*?acll\">(.*?)</div>.*?acrr\">(.*?)</div>.*?</li>", RegexOptions.IgnoreCase);
            ret.Add(Main.GetSumLine(_str, mcs.Count));
            foreach (Match match in mcs)
            {
                data = String.Format(Main.xmlElementHeader, 0, Regex.Replace(match.Groups[3].Value.Replace("&nbsp;", "无"), "<.*?>", ""), match.Groups[2].Value, 1, "bzmtv", Regex.Replace(match.Groups[4].Value.Replace("&nbsp;", "无"), "<.*?>", ""));
                data += String.Format(Main.xmlElementData, "http://127.0.0.1/" + match.Groups[1].Value);
                data += Main.xmlElementFooter;
                ret.Add(data);
            }
            result.AddRange(ret);
        }

        public string Download(string path)
        {
            String url = lrcSite + path;
            String data = hc.GetSrc(url, encode, out temp).Replace(" ", "").Replace("\r", "");
            Match mc = Regex.Match(data, "(<divclass=\"lrc\">.*?</div>)", RegexOptions.Singleline);
            data = Regex.Replace(mc.Groups[1].Value, "<.*?>", "");
            return Main.ClearLrc(data);
        }
    }
}
