using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class User
    {
        public virtual int KullanıcıId { get; set; }
        public virtual int FirmaId { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Soyad { get; set; }
        public virtual string KullanıcıAdı { get; set; }    
        public virtual string Password_Hash { get; set; }
        public virtual IList<Role> Rol { get; set; }    
        public User()
        {          
        
                Rol = new List<Role>();
        }
        public virtual void SetPassword(string password)
        {
            Password_Hash = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password_Hash);
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("Kullanıcılar");
            Id(x => x.KullanıcıId, x => x.Generator(Generators.Identity));
              Property(x => x.FirmaId);
            Property(x => x.Ad, x => x.NotNullable(true));
            Property(x => x.Soyad, x => x.NotNullable(true));
            Property(x => x.KullanıcıAdı, x => x.NotNullable(true));           
            Property(x => x.Password_Hash, x =>
            {
                x.NotNullable(true);
                x.Column("password_hash");
            });
            Bag(x => x.Rol, x =>
            {
                x.Table("Kullanıcı_Rolleri");
                x.Key(k => k.Column("KullanıcıId"));
            }, x => x.ManyToMany(k => k.Column("RolId")));          

        }
    }
       
}
