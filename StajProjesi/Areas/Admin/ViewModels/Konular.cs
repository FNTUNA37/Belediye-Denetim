using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class KonuIndex
    {
        public IEnumerable<Konular> Konular { get; set; }
        public IEnumerable<Baslık> Baslıklar { get; set; }
    }
    public class KonuNew
    {

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Konu { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int BaslıkId { get; set; }  
        public IEnumerable<Baslık> Baslıklar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
    }
    public class KonuEdit
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Konu { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int BaslıkId { get; set; }
        public IEnumerable<Baslık> Baslıklar { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
    }
}