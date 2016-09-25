using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Primitives;
using System.Collections.ObjectModel;
using System.Net;
namespace _3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str;
        public MainWindow()
        {
            
            InitializeComponent();
            WebClient cl = new WebClient();
            cl.DownloadStringCompleted += new DownloadStringCompletedEventHandler(cl_DownloadStringCompleted);
            cl.DownloadStringAsync(new Uri("http://www.cbr.ru/scripts/XML_val.asp"));
        }
        void cl_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XDocument doc = XDocument.Parse(e.Result);
            vallist.ItemsSource = doc.Root.Elements("Item").Select<XElement, Valutes>
                (
                   i => new Valutes
                   {
                       EngName = i.Element("EngName").Value,
                       ParentCode = i.Element("ParentCode").Value
                   });
            vallist.DisplayMemberPath = "EngName";
            vallist.SelectedValuePath = "ParentCode";
        }

        private void getdata_Click(object sender, RoutedEventArgs e)
        {
            
            WebClient c = new WebClient();
            c.DownloadStringCompleted += new DownloadStringCompletedEventHandler(c_DownloadStringCompleted);
            if (dates.SelectedDates != null && dates.SelectedDates.Count > 1 && vallist.SelectedItem != null)
            {
                    c.DownloadStringAsync(new Uri("http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + dates.SelectedDates[0].ToString("dd/MM/yyyy") + 
                    "&date_req2=" + dates.SelectedDates[dates.SelectedDates.Count - 1].ToString("dd/MM/yyyy") + "&VAL_NM_RQ=" + vallist.SelectedValue));
            }
            else MessageBox.Show("Выберите отрезок времени | валюту");
            
        }
   
        void c_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XDocument xdoc = XDocument.Parse(e.Result);
            IEnumerable<CursOnDate> xt = xdoc.Root.Elements("Record").Select<XElement, CursOnDate>(
                i => new CursOnDate
                {
                    time = DateTime.Parse(i.Attribute("Date").Value),
                    Vcurs = Convert.ToDouble(i.Element("Value").Value)
                }
                );
            
            Charts.Series.Clear();
           
            switch (str)
            {
                case "pie": PieSeries PieChart = new PieSeries() { Title = "Динамика",DependentValuePath = "Vcurs",IndependentValuePath="time",ItemsSource = xt };
                    Charts.Series.Clear();
                    Charts.Series.Add(PieChart);
                    break;
                case "line": LineSeries LineChart = new LineSeries() { Title = "Динамика", DependentValuePath = "Vcurs", IndependentValuePath = "time", ItemsSource = xt };
                    Charts.Series.Clear();
                    Charts.Series.Add(LineChart);
                    break;
                case "area": AreaSeries AreaChart = new AreaSeries() { Title = "Динамика", DependentValuePath = "Vcurs", IndependentValuePath = "time", ItemsSource = xt };
                    Charts.Series.Clear();
                    Charts.Series.Add(AreaChart);
                    break;
                case "bar": BarSeries BarChart = new BarSeries() { Title = "Динамика", DependentValuePath = "Vcurs", IndependentValuePath = "time", ItemsSource = xt };
                    Charts.Series.Clear();
                    Charts.Series.Add(BarChart);
                    break;
                case "column": ColumnSeries ColumnChart = new ColumnSeries() { Title = "Динамика", DependentValuePath = "Vcurs", IndependentValuePath = "time", ItemsSource = xt };
                    Charts.Series.Clear();
                    Charts.Series.Add(ColumnChart);
                    break;
            }
           
        }

        private void pie_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton gr = sender as RadioButton;
            str = gr.Name;
        }
    }
    public class CursOnDate
    {
        public DateTime time { get; set; }
        public Double Vcurs { get; set; }

    }

    public class Valutes
    {
        public string EngName
        {
            set;
            get;
        }

        public string ParentCode
        {
            set;
            get;
        }
    }
}
