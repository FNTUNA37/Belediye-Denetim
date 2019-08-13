using NHibernate;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using NHibernate.Cfg;
using System.Linq;
using System.Web;
using StajProjesi.Models;
namespace StajProjesi
{
    public static class Database
    {
        private const string SessionKey = "StajProjesi.Database.SessionKey";
        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items[SessionKey];
            }
        }


        public static void Configure()
        {
         
            var config = new Configuration();
            config.Configure();
        
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<FirmaMap>();
            mapper.AddMapping<GorevMap>();
            mapper.AddMapping<KonularMap>();
            mapper.AddMapping<RaporMap>();
            mapper.AddMapping<BaslıkMap>();
          

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

         
            _sessionFactory = config.BuildSessionFactory();

        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {

            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove("Session");

        }
    }
}