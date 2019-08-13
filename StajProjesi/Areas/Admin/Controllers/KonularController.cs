using NHibernate.Linq;
using StajProjesi.Areas.Admin.ViewModels;
using StajProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class KonularController : Controller
    {
     
        public ActionResult Index()
        {
            return View(new KonuIndex()
            {
                Baslıklar = Database.Session.Query<Baslık>().ToList(),
                 Konular = Database.Session.Query<Konular>().ToList()
            });
        }
        public ActionResult New()
        {

            return View(new KonuNew()
            {
                
                Baslıklar = Database.Session.Query<Baslık>().ToList(),
                Firmalar=Database.Session.Query<Firma>().ToList()
            });
        }
        [HttpPost]
        public ActionResult New(KonuNew formData)
        {

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var konu = new Konular()
            {
                Konu = formData.Konu,
                BaslıkId = formData.BaslıkId

            };
            Database.Session.Save(konu);
            Database.Session.Flush();
            return RedirectToAction("New");
        }
        public ActionResult Edit(int KonuId)
        {
            var konu = Database.Session.Load<Konular>(KonuId);

            if (konu == null)
            {
                return HttpNotFound();
            }


            return View(
                new KonuEdit()
                {
                    Konu = konu.Konu,
                    BaslıkId = konu.BaslıkId,
                    Baslıklar = Database.Session.Query<Baslık>().ToList(),
                      Firmalar = Database.Session.Query<Firma>().ToList()
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(int KonuId, KonuEdit formData)
        {

            var konu = Database.Session.Load<Konular>(KonuId);
            if (konu == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            konu.Konu = formData.Konu;
            konu.BaslıkId = formData.BaslıkId;
            Database.Session.Update(konu);
            Database.Session.Flush();
            return RedirectToAction("Index");


        }


        [HttpPost]
        public ActionResult Delete(int KonuId)
        {
            var konu = Database.Session.Load<Konular>(KonuId);
            if (konu == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(konu);
            Database.Session.Flush();

            return RedirectToAction("Index");

        }
    }
}
