using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinService
{
    public class DataBase
    {
        private static DataBase instans;
        private List<TabloBir> _tablobir;
        private List<TabloIki> _tabloiki;
        private List<TabloUc> _tablouc;
        private DataBase()
        {
            _tablobir = new List<TabloBir>();
            _tabloiki = new List<TabloIki>();
            _tablouc = new List<TabloUc>();
        }
        public void TabloFulle()
        {
            _tablobir.Add(new TabloBir() { Id = 1, X = "41.063244", Y = "21.992814" });
            _tablobir.Add(new TabloBir() { Id = 2, X = "42.063244", Y = "22.992814" });
            _tablobir.Add(new TabloBir() { Id = 3, X = "43.063244", Y = "23.992814" });
            _tablobir.Add(new TabloBir() { Id = 4, X = "44.063244", Y = "24.992814" });
            _tablobir.Add(new TabloBir() { Id = 5, X = "45.063244", Y = "25.992814" });
            _tablobir.Add(new TabloBir() { Id = 6, X = "46.063244", Y = "26.992814" });
            _tablobir.Add(new TabloBir() { Id = 7, X = "47.063244", Y = "27.992814" });
            _tablobir.Add(new TabloBir() { Id = 8, X = "48.063244", Y = "28.992814" });
            _tablobir.Add(new TabloBir() { Id = 9, X = "49.063244", Y = "29.992814" });

            _tabloiki.Add(new TabloIki() { Id = 1, X = "51.063244", Y = "21.992814" });
            _tabloiki.Add(new TabloIki() { Id = 2, X = "52.063244", Y = "22.992814" });
            _tabloiki.Add(new TabloIki() { Id = 3, X = "53.063244", Y = "23.992814" });
            _tabloiki.Add(new TabloIki() { Id = 4, X = "54.063244", Y = "24.992814" });
            _tabloiki.Add(new TabloIki() { Id = 5, X = "55.063244", Y = "25.992814" });
            _tabloiki.Add(new TabloIki() { Id = 6, X = "56.063244", Y = "26.992814" });
            _tabloiki.Add(new TabloIki() { Id = 7, X = "57.063244", Y = "27.992814" });
            _tabloiki.Add(new TabloIki() { Id = 8, X = "58.063244", Y = "28.992814" });
            _tabloiki.Add(new TabloIki() { Id = 9, X = "59.063244", Y = "29.992814" });
        }
        public List<TabloBir> TabloBirList()
        {
            return _tablobir.ToList();
        }
        public List<TabloIki> TabloIkiList()
        {
            return _tabloiki.ToList();
        }
        public List<TabloUc> Liste
        {
            get
            {
                return _tablouc.ToList();
            }
        }
        public void TabloUcEkle(TabloUc data)
        {
            _tablouc.Add(data);
        }
        public static DataBase Instans
        {
            get
            {
                if (instans == null)
                {
                    instans = new DataBase();
                }
                return instans;
            }
        }
    }

    public class TabloBir
    {
        public int Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }
    public class TabloIki
    {
        public int Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }
    public class TabloUc
    {
        public int Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Adres { get; set; }
    }
}
