using NHibernate.Linq;
using StajProjesi.Areas.Admin.ViewModels;
using StajProjesi.Models;
using System.Linq;
using System.Web.Mvc;
using System;

namespace StajProjesi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
           
            
            
            return View(new RaporIndex
            {
                  
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()

            });
        }
        [HttpPost]
        public ActionResult Index(RaporIndex formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var hafta = Convert.ToString(formData.Hafta).Substring(6, 2);
            var yıl = formData.Hafta.Substring(0, 4);
            
            return View(new RaporIndex
            {
                FirmaId=formData.FirmaId,
                Yıl=yıl,
                Hafta = hafta,
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList(),
                  Firmalar = Database.Session.Query<Firma>().ToList()
            });
        }
        public ActionResult Genel()
        {



            return View(new GenelIndex
            {
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Kullanıcılar = Database.Session.Query<User>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()

            });
        }
        [HttpPost]
        public ActionResult Genel(GenelIndex formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            if (formData.FirmaId == 0)
            {
                return View(new GenelIndex
                {
                    Firmalar = Database.Session.Query<Firma>().ToList(),
                    Kullanıcılar = Database.Session.Query<User>().ToList(),
                    Gorevler = Database.Session.Query<Gorev>().ToList(),
                    Raporlar = Database.Session.Query<Rapor>().ToList()
                });
            }

            return View(new GenelIndex
            {
                Yıl =formData.Yıl,
                FirmaId=formData.FirmaId,
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Kullanıcılar = Database.Session.Query<User>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()

            });
        }
        public ActionResult Arıza()
        {
            return View(new ArızaIndex
            {
               Konular = Database.Session.Query<Konular>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList(),             
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()
            });
        }
        [HttpPost]
        public ActionResult Arıza(ArızaIndex formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            if (formData.FirmaId == 0)
            {
                return View(new ArızaIndex
                {
                    Konular = Database.Session.Query<Konular>().ToList(),
                    Firmalar = Database.Session.Query<Firma>().ToList(),
                    Gorevler = Database.Session.Query<Gorev>().ToList(),
                    Raporlar = Database.Session.Query<Rapor>().ToList()
                });
            }
            return View(new ArızaIndex
            {
                Yıl = formData.Yıl,
                FirmaId = formData.FirmaId,
                Konular = Database.Session.Query<Konular>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()
            });
        }
        public ActionResult Aylık()
        {
            return View(new AylıkIndex
            {
                Konular = Database.Session.Query<Konular>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()
            });
        }
        [HttpPost]
        public ActionResult Aylık(AylıkIndex formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            if (formData.FirmaId == 0)
            {
                return View(new AylıkIndex
                {
                    Konular = Database.Session.Query<Konular>().ToList(),
                    Firmalar = Database.Session.Query<Firma>().ToList(),
                    Gorevler = Database.Session.Query<Gorev>().ToList(),
                    Raporlar = Database.Session.Query<Rapor>().ToList()
                });
            }
            var yıl =Convert.ToString( Convert.ToDateTime(formData.Ay).Year);
            var ay = Convert.ToString(Convert.ToDateTime(formData.Ay).Month);
            var günSayısı = DateTime.DaysInMonth(Convert.ToInt32(yıl), Convert.ToInt32(ay));
            return View(new AylıkIndex
            {
                günSayısı =günSayısı,
                Ay = ay,
                Yıl = yıl,
                FirmaId = formData.FirmaId,
                Konular = Database.Session.Query<Konular>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),
                Raporlar = Database.Session.Query<Rapor>().ToList()
            });
        }
    }

}