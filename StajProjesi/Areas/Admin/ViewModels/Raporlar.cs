using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class RaporIndex
    {
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Rapor> Raporlar { get; set; }
        public IEnumerable<Gorev> Gorevler { get; set; }
        public string Hafta { get; set; }
        public string Yıl { get; set; }
        public int FirmaId { get; set; }
    }
    public class GenelIndex
    {
        public IEnumerable<User> Kullanıcılar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Rapor> Raporlar { get; set; }
        public IEnumerable<Gorev> Gorevler { get; set; }
        public string Yıl { get; set; }
        public int FirmaId { get; set; }
    }
    public class ArızaIndex
    {
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Konular> Konular { get; set; }
        public IEnumerable<Rapor> Raporlar { get; set; }
        public IEnumerable<Gorev> Gorevler { get; set; }
        public string Ay { get; set; }
        public string Yıl { get; set; }
       
        public int FirmaId { get; set; }
    }
    public class AylıkIndex
    {
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Konular> Konular { get; set; }
        public IEnumerable<Rapor> Raporlar { get; set; }
        public IEnumerable<Gorev> Gorevler { get; set; }
        public string Ay { get; set; }
        public string Yıl { get; set; }
        public int günSayısı { get; set; }
        public int FirmaId { get; set; }
    }
}