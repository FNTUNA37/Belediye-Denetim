using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class GorevIndex
    {
        public IEnumerable<Gorev> Gorevler { get; set; }       
    }
    public class GorevNew
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string Tarih { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int KullanıcıId { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int FirmaId { get; set; }
        public int Hafta { get; set; }
        public IEnumerable<User> Kullanıcılar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }

    }
    public class GorevEdit
    {

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string Tarih { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int KullanıcıId { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int FirmaId { get; set; }
        public int Hafta { get; set; }
        public IEnumerable<User> Kullanıcılar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }

    }
  
}