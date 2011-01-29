using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using System.Json;
using System.Windows.Browser;

namespace SilverGraph
{
    public partial class MainPage : UserControl
    {
        string xKey, xValue, xPath,xTitle,xType;
        DataPointSeries series;

        public MainPage(string type,string path, string key, string value, string title)
        {
            InitializeComponent();
            xPath = path;
            xKey = key;
            xValue = value;
            xTitle = title;
            xType = type;
            loadData();
        }

        private void loadData()
        {
            Uri destAddr = new Uri(HtmlPage.Document.DocumentUri,xPath);
            WebClient wc = new WebClient();
            series = new ColumnSeries();
            if (xType == "column")
            {
                series.Title = xTitle;
            }
            else if (xType == "pie")
            {
                series = new PieSeries();
            }
            series.IndependentValueBinding = new System.Windows.Data.Binding("Key");
            series.DependentValueBinding = new System.Windows.Data.Binding("Value");
            testChart.Series.Add(series);

            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(destAddr);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JsonArray ja = (JsonArray)JsonArray.Parse(e.Result);
                List<KeyValuePair<String, int>> src = new List<KeyValuePair<string, int>>();

                foreach (JsonObject d in ja)
                {
                    src.Add(new KeyValuePair<string, int>(d[xKey], d[xValue]));
                }
                series.ItemsSource = src;
            }
            catch
            {
                testChart.Title = "数据加载失败！";
                series.Visibility = Visibility.Collapsed;
            }
        }
    }
}
