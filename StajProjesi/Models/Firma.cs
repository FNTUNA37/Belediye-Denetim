using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Firma
    {
        public virtual int FirmaId { get; set; }
        public virtual string FirmaAdı { get; set; }
        public virtual string TeslimSaati { get; set; }

    }

    public class FirmaMap : ClassMapping<Firma>
    {
        public FirmaMap()
        {
            Table("Firmalar");

            Id(x => x.FirmaId, x => x.Generator(Generators.Identity));
            Property(x => x.FirmaAdı, x => x.NotNullable(true));
            Property(x => x.TeslimSaati, x => x.NotNullable(true));


        }
    }
}