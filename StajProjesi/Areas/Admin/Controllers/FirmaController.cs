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
        public class FirmaController : Controller
        {
            // GET: Baslık
            public ActionResult Index()
            {
                return View(new FirmaIndex()
                {
                    Firmalar = Database.Session.Query<Firma>().ToList()
                });
            }
            public ActionResult New()
            {
                return View();
            }
            [HttpPost]
            public ActionResult New(FirmaNew formData)
            {

                if (Database.Session.Query<Firma>().Any(u => u.FirmaAdı == formData.FirmaAdı))
                {
                    ModelState.AddModelError("Firma", "Bu ada sahip bir Firma var");
                }

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }
                    
                var firma = new Firma()
                {
                    FirmaAdı = formData.FirmaAdı,
                    TeslimSaati = formData.TeslimSaati.ToShortTimeString()


        };
                Database.Session.Save(firma);
                Database.Session.Flush();
                return RedirectToAction("Index");
            }
            public ActionResult Edit(int FirmaId)
            {
                var firma = Database.Session.Load<Firma>(FirmaId);
                if (firma == null)
                {
                    return HttpNotFound();
                }

                return View(new FirmaEdit()
                {
                    FirmaAdı = firma.FirmaAdı,
                    
                    

                });
            }
            [HttpPost]
            public ActionResult Edit(int FirmaId, FirmaEdit formData)
            {

                var firma = Database.Session.Load<Firma>(FirmaId);
                if (firma == null)
                {
                    return HttpNotFound();
                }


                if (Database.Session.Query<Firma>().Any(u => u.FirmaAdı == formData.FirmaAdı && u.FirmaId != FirmaId))
                {
                    ModelState.AddModelError("FirmaAdı", "Bu ada sahip başka bir Firma var");
                }

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }

                firma.FirmaAdı = formData.FirmaAdı;
            firma.TeslimSaati = formData.TeslimSaati.ToShortTimeString();
                Database.Session.Update(firma);
                Database.Session.Flush();
                return RedirectToAction("Index");


            }
            [HttpPost]
            public ActionResult Delete(int FirmaId)
            {
                var firma = Database.Session.Load<Firma>(FirmaId);
                if (firma == null)
                {
                    return HttpNotFound();
                }

                Database.Session.Delete(firma);
                Database.Session.Flush();

                return RedirectToAction("Index");

            }
        }
    }


