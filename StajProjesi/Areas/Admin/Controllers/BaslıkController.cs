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
    public class BaslıkController : Controller
    {
        // GET: Admin/Baslık
        public ActionResult Index()
        {
            return View(new BaslıkIndex()
            {
                Baslıklar = Database.Session.Query<Baslık>().ToList(),
                Firmalar = Database.Session.Query<Firma>().ToList()
            });
        }
        public ActionResult New()
        {
            return View(new BaslıkNew
            {
                Firmalar = Database.Session.Query<Firma>().ToList()
            });
        }
        [HttpPost]
        public ActionResult New(BaslıkNew formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var baslık = new Baslık()
            {
                BaslıkAdı = formData.BaslıkAdı,
                FirmaId = formData.FirmaId

            };
            Database.Session.Save(baslık);
            Database.Session.Flush();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int BaslıkId)
        {
            var baslık = Database.Session.Load<Baslık>(BaslıkId);

            if (baslık == null)
            {
                return HttpNotFound();
            }


            return View(
                new BaslıkEdit()
                {
                    BaslıkAdı=baslık.BaslıkAdı,
                    Firmalar = Database.Session.Query<Firma>().ToList()
                }
            );
        }

        [HttpPost]
        public ActionResult Edit(int BaslıkId, BaslıkEdit formData)
        {

            var baslık = Database.Session.Load<Baslık>(BaslıkId);
            if (baslık == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            baslık.BaslıkAdı = formData.BaslıkAdı;
            baslık.FirmaId = formData.FirmaId;
            Database.Session.Update(baslık);
            Database.Session.Flush();
            return RedirectToAction("Index");


        }


        [HttpPost]
        public ActionResult Delete(int BaslıkId)
        {
            var baslık = Database.Session.Load<Baslık>(BaslıkId);
            if (baslık == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(baslık);
            Database.Session.Flush();

            return RedirectToAction("Index");

        }
    }
}
