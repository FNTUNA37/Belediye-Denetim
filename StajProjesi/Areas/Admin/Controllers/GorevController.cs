using NHibernate.Linq;
using StajProjesi.Areas.Admin.ViewModels;
using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class GorevController : Controller
    {
        // GET: Admin/Gorev
        public ActionResult Index()
        {
            return View(new GorevIndex
            {
                Gorevler=Database.Session.Query<Gorev>().OrderByDescending(x=>x.Tarih).ToList()
            });
        }
        public ActionResult New()
        {
            return View(new GorevNew {

                Firmalar=Database.Session.Query<Firma>().ToList(),
                Kullanıcılar=Database.Session.Query<User>().ToList()
            });
        }
        public int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;

        }
        [HttpPost]
        public ActionResult New(GorevNew formData,string Tarih)
        {
           

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            string[] Tarihler = Tarih.Split(',');
            foreach (string tarih in Tarihler)
            {
                var gorev = new Gorev
                {
                    KullanıcıId=formData.KullanıcıId,
                    Tarih=tarih,
                    FirmaId=formData.FirmaId,
                    Hafta=GetWeekNumber(Convert.ToDateTime(tarih))
                    
                };
                Database.Session.Save(gorev);
                Database.Session.Flush();
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int GorevId)
        {
            var gorev = Database.Session.Load<Gorev>(GorevId);

            if (gorev == null)
            {
                return HttpNotFound();
            }

          
            return View(
                new GorevEdit()
                {
                    KullanıcıId = gorev.KullanıcıId,
                    Tarih = gorev.Tarih,
                    Hafta=gorev.Hafta,
                    Firmalar = Database.Session.Query<Firma>().ToList(),
                    Kullanıcılar = Database.Session.Query<User>().ToList()
                    
                }
            );
        }
        [HttpPost]
        public ActionResult Edit(int GorevId, GorevEdit formData)
        {

            var gorev = Database.Session.Load<Gorev>(GorevId);
            if (gorev == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            gorev.KullanıcıId = formData.KullanıcıId;
            gorev.Tarih = formData.Tarih;
            gorev.Hafta = GetWeekNumber(Convert.ToDateTime(formData.Tarih));
            Database.Session.Update(gorev);
            Database.Session.Flush();
            return RedirectToAction("Index");


        }


        [HttpPost]
        public ActionResult Delete(int GorevId)
        {
            var gorev = Database.Session.Load<Konular>(GorevId);
            if (gorev == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(gorev);
            Database.Session.Flush();

            return RedirectToAction("Index");

        }
    }
}
