using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Konular
    {
        public virtual int KonuId { get; set; }
       
        public virtual string Konu { get; set; }

        public virtual int BaslıkId { get; set; }
    
    }
    public class KonularMap : ClassMapping<Konular>
    {
        public KonularMap()
        {
            Table("Konular");

            Id(x => x.KonuId, x => x.Generator(Generators.Identity));
            Property(x => x.Konu, x => x.NotNullable(true));      
            Property(x => x.BaslıkId, x => x.NotNullable(true));

        }
    }
}