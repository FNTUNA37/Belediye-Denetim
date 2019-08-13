using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StajProjesi.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }

    public class UsersNew
    {
        public IList<RoleCheckBox> Rol { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string KullanıcıAdı { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public int FirmaId { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }


    }

    public class UsersEdit
    {

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string KullanıcıAdı { get; set; }

        public int FirmaId { get; set; }
        public IEnumerable<Firma> Firmalar { get; set; }
        public IList<RoleCheckBox> Rol { get; set; }
      
    }

    public class UsersResetPassword
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128)]
        public string KullanıcıAdı { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!"), MaxLength(128), DataType(DataType.Password)]
        public string Sifre { get; set; }
    }

    public class RoleCheckBox
    {
        public int RolId { get; set; }
        public bool IsChecked { get; set; }
        public string RolAdı { get; set; }
    }
  
}
