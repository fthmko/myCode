using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Farmer
{
    class WebPost
    {
        private string url;
        private string data;
        private WebPostCallBack callback;
        private CookieContainer cookie;

        public WebPost(string url, string data, WebPostCallBack callback, CookieContainer webCookie)
        {
            this.url = url;
            this.data = data;
            this.callback = callback;
            this.cookie = webCookie;

            HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(url);
            loHttp.Timeout = 10000;
            loHttp.CookieContainer = webCookie;

            if (String.IsNullOrEmpty(data))
            {
                loHttp.Method = "GET";
            }
            else
            {
                loHttp.Method = "POST";
                loHttp.ContentType = "application/x-www-form-urlencoded";
                loHttp.BeginGetRequestStream(new AsyncCallback(RequestReady), loHttp);
            }

            // 模拟IPhone3
            //loHttp.UserAgent = "Mozilla/5.0 (iPhone; U; CPU iPhone OS 3_0 like Mac OS X; en-us) AppleWebKit/528.18 (KHTML, like Gecko) Version/4.0 Mobile/7A341 Safari/528.16";

            loHttp.BeginGetResponse(new AsyncCallback(ResponseReady), loHttp);
        }
        void RequestReady(IAsyncResult asyncResult)
        {
            WebRequest request = asyncResult.AsyncState as WebRequest;
            Stream requestStream = request.EndGetRequestStream(asyncResult);
            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(data);
            }
        }
        void ResponseReady(IAsyncResult asyncResult)
        {
            HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                SetText(reader.ReadToEnd());
                request.CookieContainer.Add(response.Cookies);
            }
        }
        private void SetText(string text)
        {
            callback(text);
        }
        public delegate void WebPostCallBack(String response);
    }
}
