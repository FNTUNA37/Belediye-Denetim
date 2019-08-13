using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.ViewModels
{
 
    public class HomeIndex
    {
        public string  Gorevli { get; set; }
        public bool Rapor { get; set; }
        public int FirmaId { get; set; }
        public IList<KonuCheckBox> Konu { get; set; }
        public IEnumerable<Konular> Konular { get; set; }
        public IEnumerable<Baslık> Baslıklar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Gorev> Gorevler { get; set; }
        public IEnumerable<Rapor> Raporlar { get; set; }
    }
    public class KonuCheckBox
    {
      
        public int KonuId { get; set; }
        public bool IsChecked { get; set; }
        public string Konu { get; set; }
        public int BaslıkId { get; set; }
        public int FirmaId { get; set; }

    }
}