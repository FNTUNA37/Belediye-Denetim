using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Baslık
    {
        public virtual int BaslıkId { get; set; }
        
        public virtual string BaslıkAdı { get; set; }
        public virtual int FirmaId { get; set; }
    }

    public class BaslıkMap : ClassMapping<Baslık>
    {
        public BaslıkMap()
        {
            Table("Baslıklar");

            Id(x => x.BaslıkId, x => x.Generator(Generators.Identity));
            Property(x => x.BaslıkAdı, x => x.NotNullable(true));
            Property(x => x.FirmaId, x => x.NotNullable(true));
        }
    }
}