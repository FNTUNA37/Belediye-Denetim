using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Rapor
    {
        public virtual int RaporId { get; set; }
        public virtual int FirmaId { get; set; }
        public virtual int KullanıcıId { get; set; }
        public virtual string RaporTarihi { get; set; }
        public virtual string RaporSaati { get; set; }

       

        public virtual IList<Konular> Hata { get; set; }
        public Rapor()
        {

            Hata = new List<Konular>();
        }
    }

    public class RaporMap : ClassMapping<Rapor>
    {
        public RaporMap()
        {
            Table("Raporlar");
            Id(x => x.RaporId, x => x.Generator(Generators.Identity));
            Property(x => x.FirmaId, x => x.NotNullable(true));
            Property(x => x.KullanıcıId, x => x.NotNullable(true));
            Property(x => x.RaporId, x => x.NotNullable(true));
            Property(x => x.RaporSaati, x => x.NotNullable(true));
            Property(x => x.RaporTarihi, x => x.NotNullable(true));
            
            Bag(x => x.Hata, x =>
            {
                x.Table("Hatalar");
                x.Key(k => k.Column("RaporId"));
            }, x => x.ManyToMany(k => k.Column("KonuId")));

        }
    }
}
