using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class FirmaIndex
    {
        public IEnumerable<Firma> Firmalar { get; set; }
    }
    public class FirmaNew
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string FirmaAdı { get; set; }
        public DateTime TeslimSaati { get; set; }

    }
    public class FirmaEdit
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string FirmaAdı { get; set; }
        public DateTime TeslimSaati { get; set; }
    }
}