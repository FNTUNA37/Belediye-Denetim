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
       // GET: Admin/Users
       [Authorize(Roles="admin")]
         public class UsersController : Controller
        {
           
            public ActionResult Index()
            {
                return View(new UsersIndex()
                {
                    Users = Database.Session.Query<User>().ToList()
                });
            }


            public ActionResult New()
            {
                return View(new UsersNew()
                {
                    Firmalar=Database.Session.Query<Firma>().ToList(),
                    Rol = Database.Session.Query<Role>().Select(role =>
                     new RoleCheckBox()
                     {
                         RolId = role.RolId,
                         IsChecked = false,
                         RolAdı = role.RolAdı
                     }
                    ).ToList()
                });
            }

            private void SyncRoles(IList<RoleCheckBox> checkBoxes, IList<Role> roles)
            {
                var selectedRoles = new List<Role>();

                foreach (var role in Database.Session.Query<Role>())
                {
                    var checkbox = checkBoxes.Single(c => c.RolId == role.RolId);
                    checkbox.RolAdı = role.RolAdı;

                    if (checkbox.IsChecked)
                    {
                        selectedRoles.Add(role);
                    }
                }

                foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
                {
                    roles.Add(toAdd);
                }

                foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
                {
                    roles.Remove(toRemove);
                }

            }

            [HttpPost]
            public ActionResult New(UsersNew formData)
            {


                if (Database.Session.Query<User>().Any(u => u.KullanıcıAdı == formData.KullanıcıAdı))
                {
                    ModelState.AddModelError("Username", "Username must be unique");
                }

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }

            var user = new User()
            {
                Ad = formData.Ad,
                Soyad = formData.Soyad,
                KullanıcıAdı = formData.KullanıcıAdı,
                Password_Hash = formData.Sifre,
                FirmaId = formData.FirmaId
                  
                };

                SyncRoles(formData.Rol, user.Rol);


                user.SetPassword(formData.Sifre);
                Database.Session.Save(user); //insert into Users (USername,password_hash,email) values ....
                Database.Session.Flush();
                return RedirectToAction("Index");


            }

            public ActionResult Edit(int KullanıcıId)
            {
                var user = Database.Session.Load<User>(KullanıcıId);

                if (user == null)
                {
                    return HttpNotFound();
                }


                return View(
                    new UsersEdit()
                    {
                        Ad=user.Ad,
                        Soyad=user.Soyad,
                        KullanıcıAdı = user.KullanıcıAdı,
                        FirmaId=user.FirmaId,
                        Firmalar = Database.Session.Query<Firma>().ToList(),
                        Rol = Database.Session.Query<Role>().Select(role => new RoleCheckBox()
                        {
                            RolId = role.RolId,
                            RolAdı = role.RolAdı,
                            IsChecked = user.Rol.Contains(role)
                        }).ToList()
                    }
                );
            }

            [HttpPost]
            public ActionResult Edit(int KullanıcıId, UsersEdit formData)
            {

                var user = Database.Session.Load<User>(KullanıcıId);
                if (user == null)
                {
                    return HttpNotFound();
                }


                if (Database.Session.Query<User>().Any(u => u.KullanıcıAdı == formData.KullanıcıAdı && u.KullanıcıId != KullanıcıId))
                {
                    ModelState.AddModelError("Username", "Username must be unique");
                }

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }

                user.KullanıcıAdı = formData.KullanıcıAdı;
                user.Ad = formData.Ad;
                user.Soyad = formData.Soyad;
            user.FirmaId = formData.FirmaId;
                SyncRoles(formData.Rol, user.Rol);
                Database.Session.Update(user); 
                Database.Session.Flush();
                return RedirectToAction("Index");


            }


            public ActionResult ResetPassword(int KullanıcıId)
            {
                var user = Database.Session.Load<User>(KullanıcıId);

                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(new UsersResetPassword()
                {
                    KullanıcıAdı = user.KullanıcıAdı
                });
            }

            [HttpPost]
            public ActionResult ResetPassword(int KullanıcıId, UsersResetPassword formData)
            {

                var user = Database.Session.Load<User>(KullanıcıId);
                if (user == null)
                {
                    return HttpNotFound();
                }

                formData.KullanıcıAdı = user.KullanıcıAdı;

                if (Database.Session.Query<User>().Any(u => u.KullanıcıAdı == formData.KullanıcıAdı && u.KullanıcıId != KullanıcıId))
                {
                    ModelState.AddModelError("Username", "Username must be unique");
                }

                if (!ModelState.IsValid)
                {
                    return View(formData);
                }

                user.SetPassword(formData.Sifre);
                Database.Session.Update(user); //insert into Users (USername,password_hash,email) values ....
                Database.Session.Flush();
                return RedirectToAction("Index");


            }



            [HttpPost]
            public ActionResult Delete(int KullanıcıId)
            {
                var user = Database.Session.Load<User>(KullanıcıId);
                if (user == null)
                {
                    return HttpNotFound();
                }

                Database.Session.Delete(user);
                Database.Session.Flush();

                return RedirectToAction("Index");

            }
        }
    }
