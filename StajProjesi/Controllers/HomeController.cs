using NHibernate.Linq;
using StajProjesi.Models;
using StajProjesi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProjesi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            User gorevli = new User();
            bool Rapor=false;
            string tarih = DateTime.Now.ToString("yyyy/MM/dd").Substring(0,10);
            User user = Database.Session.Query<User>().SingleOrDefault(x => x.KullanıcıAdı.Equals(User.Identity.Name));
            Gorev gorev = Database.Session.Query<Gorev>().SingleOrDefault(x => x.Tarih.Equals(tarih));
            Rapor rapor = Database.Session.Query<Rapor>().SingleOrDefault(x => x.RaporTarihi.Equals(tarih));
            if (gorev != null)
            {
                 gorevli = Database.Session.Load<User>(gorev.KullanıcıId);
            }
            if (rapor != null)
            {
                Rapor = true;
            }
            return View(new HomeIndex()
            {
            
                Rapor=Rapor,
            Gorevli =gorevli.Ad+" "+gorevli.Soyad,
               FirmaId=user.FirmaId,
                Baslıklar=Database.Session.Query<Baslık>().ToList(),
                Gorevler = Database.Session.Query<Gorev>().ToList(),                             
                Konu = Database.Session.Query<Konular>().Select(konu =>
                    new KonuCheckBox()
                    {
                        KonuId = konu.KonuId,
                        IsChecked = false,
                        Konu = konu.Konu,
                        BaslıkId=konu.BaslıkId,
                        FirmaId=user.FirmaId
                    }
                    ).ToList()
            });       
        }
       
        [HttpPost]
        public ActionResult Index(HomeIndex formData)
        {         
            User user = Database.Session.Query<User>().SingleOrDefault(x => x.KullanıcıAdı.Equals(User.Identity.Name));
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var rapor = new Rapor()
            {
                RaporTarihi = DateTime.Now.ToString("yyyy/MM/dd").Substring(0,10),
                KullanıcıId = user.KullanıcıId,
                RaporSaati = DateTime.Now.ToShortTimeString(),              
                FirmaId = user.FirmaId
            };

            SyncHatalar(formData.Konu, rapor.Hata);
            Database.Session.Save(rapor);
            Database.Session.Flush();
            return RedirectToAction("Index"); 

        }
        private void SyncHatalar(IList<KonuCheckBox> checkBoxes, IList<Konular> konular)
        {
            User user = Database.Session.Query<User>().SingleOrDefault(x => x.KullanıcıAdı.Equals(User.Identity.Name));
            var selectedKonu = new List<Konular>();

            foreach (var konu in Database.Session.Query<Konular>())
            {
                var baslık = Database.Session.Load<StajProjesi.Models.Baslık>(konu.BaslıkId);
                if (baslık.FirmaId == user.FirmaId)
                {
                    var checkbox = checkBoxes.Single(c => c.KonuId == konu.KonuId);
                    checkbox.Konu = konu.Konu;

                    if (checkbox.IsChecked)
                    {
                        selectedKonu.Add(konu);
                    }
                }

                foreach (var toAdd in selectedKonu.Where(t => !konular.Contains(t)))
                {
                    konular.Add(toAdd);
                }

                foreach (var toRemove in konular.Where(t => !selectedKonu.Contains(t)).ToList())
                {
                    konular.Remove(toRemove);
                }
            }

        }
    }
}