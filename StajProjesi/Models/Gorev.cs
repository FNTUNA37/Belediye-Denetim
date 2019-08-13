using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Gorev
    {
        public virtual int GorevId { get; set; }
        public virtual int KullanıcıId { get; set; }
        public virtual int FirmaId { get; set; }
        public virtual int Hafta { get; set; }
        public virtual string Tarih { get; set; }
    }
        public class GorevMap : ClassMapping<Gorev>
      {
        public GorevMap()
        {
            Table("Gorevler");
            Id(x => x.GorevId, x => x.Generator(Generators.Identity));
            Property(x => x.KullanıcıId, x => x.NotNullable(true));
            Property(x => x.FirmaId, x => x.NotNullable(true));
            Property(x => x.Tarih, x => x.NotNullable(true));
            Property(x => x.Hafta, x => x.NotNullable(true));
        }
    }
    
}