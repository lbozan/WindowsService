using System;
using System.IO;
using System.Net;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading;

namespace WinService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        private static DataBase _data;
        private static string path;
        protected override void OnStart(string[] args)
        {
            path = $"{AppDomain.CurrentDomain.BaseDirectory}GeoFile.txt";
            _data = DataBase.Instans;
            _data.TabloFulle();
            Thread thx = new Thread(new ThreadStart(Bir));
            Thread thv = new Thread(new ThreadStart(Iki));
            thx.Start();
            thv.Start();
        }

        private static string GeoData(string x, string y)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://maps.google.com/maps/api/geocode/xml?latlng={x},{y}&sensor=false");
            var response = (HttpWebResponse)request.GetResponse();
            Stream resultStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resultStream);
            string finish = reader.ReadToEnd();
            string pattern = @"<formatted_address>(.*)<\/formatted_address>";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = rgx.Match(finish);
            string son = m.Groups[0].ToString().Replace("<formatted_address>", "").Replace("</formatted_address>", "");
            return son;
        }

        private static void Bir()
        {
            _data.TabloBirList().ForEach(v =>
            {
                string adres = GeoData(v.X, v.Y);
                TabloUc newData = new TabloUc()
                {
                    X = v.X,
                    Y = v.Y,
                    Adres = adres
                };
                _data.TabloUcEkle(newData);
                Console.WriteLine($"X : {newData.X}\t Y : {newData.Y}\t Adres : {newData.Adres}");
                Thread.Sleep(4000);
            });
        }
        private static void Iki()
        {
            _data.TabloIkiList().ForEach(v => {
                string adres = GeoData(v.X, v.Y);
                TabloUc newData = new TabloUc()
                {
                    X = v.X,
                    Y = v.Y,
                    Adres = adres
                };
                _data.TabloUcEkle(newData);
                Console.WriteLine($"X : {newData.X}\t Y : {newData.Y}\t Adres : {newData.Adres}");
                Thread.Sleep(6000);
            });
            var asd = _data.Liste;


            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    _data.Liste.ForEach(v =>
                    {
                        sw.WriteLine($"X : {v.X}\t Y : {v.Y}\t Adres : {v.Adres}");
                    });
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                _data.Liste.ForEach(v =>
                {
                    sw.WriteLine($"X : {v.X}\t Y : {v.Y}\t Adres : {v.Adres}");
                });
            }
        }
        
        protected override void OnStop()
        {
            Console.WriteLine("On Stop");
        }
    }
}
