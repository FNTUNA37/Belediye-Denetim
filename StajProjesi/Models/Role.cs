using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Models
{
    public class Role
    {
        public virtual int RolId { get; set; }
        public virtual string RolAdı { get; set; }

    }

    public class RoleMap : ClassMapping<Role>
    {
        public RoleMap()
        {
            Table("roller");

            Id(x => x.RolId, x => x.Generator(Generators.Identity));
            Property(x => x.RolAdı, x => x.NotNullable(true));


        }
    }
}