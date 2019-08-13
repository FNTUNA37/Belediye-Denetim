using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class BaslıkIndex
    {
        public IEnumerable<Firma> Firmalar { get; set; }
        public IEnumerable<Baslık> Baslıklar { get; set; }
    }
    public class BaslıkNew
    {

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string BaslıkAdı { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int FirmaId { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
    }
    public class BaslıkEdit
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string BaslıkAdı { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public int FirmaId { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
    }
}