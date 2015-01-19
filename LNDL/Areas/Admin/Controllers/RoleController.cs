using LNDL.Models;
using LNDL.Controllers;
//using LNDL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using LNDL.Areas.Admin.ViewModels;
using System.Text;
using System.Reflection;


namespace LNDL.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        //ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Admin/Role
        public ActionResult Index()
        {
            var roles = ctx.Roles.ToList();
            return View(roles);

            //var rolesList = new List<RoleViewModel>();
            //foreach (var role in ctx.Roles)
            //{
            //    var roleModel = new RoleViewModel(role);
            //    rolesList.Add(roleModel);
            //}
            //return View(rolesList);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ctx.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                ctx.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //[Authorize(Roles = "Admin")]
        //public ActionResult Create(string message = "")
        //{
        //    ViewBag.Message = message;
        //    return View();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Create([Bind(Include ="RoleName")]RoleViewModel model)
        //{
        //    string message = "That role name has already been used";
        //    if (ModelState.IsValid)
        //    {
        //        //var role = new /*ApplicationRole*/IdentityRole(model.RoleName);//, model.Description);
        //        //var roleManager = new IdentityManager();

        //        if ( _db.Roles.ToList().Select(s=>s.Name = model.RoleName).FirstOrDefault()) == model.RoleName) )// .Any(model.RoleName))
        //        {
        //            return View(message);
        //        }
        //        else
        //        {
        //            _db.Roles.Add(
        //                new IdentityRole()
        //                    {
        //                        Name = model.RoleName
        //                    });//, model.Description);
        //            return RedirectToAction("Index", "Account");
        //        }
        //    }
        //    return View();
        //}

        //
        // GET: /Roles/Edit/5

        public ActionResult Edit(string roleName)
        {
            var thisRole = ctx.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                ctx.Entry(role).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Roles/Delete/5
        public ActionResult Delete(string RoleName)
        {
            var thisRole = ctx.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            ctx.Roles.Remove(thisRole);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        List<RoleSelectEditorViewModel> lur = new List<RoleSelectEditorViewModel>();
        [HttpGet]
        public ActionResult ManageUserRoles()
        {

            //lur.Id = 1;
            int count = 0;

            var listRole = ctx.Roles.OrderBy(r => r.Name).ToList(); //.Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.Roles = list;
            //lur.lr = listRole;

            var listUser = ctx.Users.OrderBy(r => r.UserName);//.ToList(); //.Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
            //ViewBag.Users = listUser;
            //lur.ls = listUser;

            foreach(var u in listUser)
            {
                RoleSelectEditorViewModel ur = new RoleSelectEditorViewModel();
                count++;
                ur.Id = count;
                foreach (var r in listRole)
                {
                    //ApplicationUser u = ctx.Users.Where(s => s.UserName.Equals(user.UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    //var rolesForThisUser = UserManager.GetRoles(u.Id).ToList();

                    SeleceEitorViewModel rs = new SeleceEitorViewModel();

                    ur.User = u;

                    rs.Role = r;
                    rs.Selected = false;

                    var rolesForThisUser = userManager.GetRoles(u.Id).ToList();

                    foreach (var urole in rolesForThisUser)
                    {
                        if (rolesForThisUser.Contains(r.Name))
                        {
                            rs.Selected = true;
                        }
                    }

                    ur.s.Add(rs); 
                }
                //lur.ls.Add(ur);
                lur.Add(ur);
            }

            //foreach (var user in listUser)
            //{
            //    ApplicationUser u = ctx.Users.Where(s => s.UserName.Equals(user.UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //    ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    //this.UserManager.GetRoles(u.Id);
            //    UserRoleEditorViewModel ur = new UserRoleEditorViewModel();
            //    SelectRoleEditorViewModel sur = new SelectRoleEditorViewModel();

            //    sur.Selected = false;
            //    var rolesForThisUser = UserManager.GetRoles(u.Id).ToList();
            //    foreach(var urole in lur.lr/*rolesForThisUser*/)
            //    {
            //        sur.RoleName = urole.Name;
            //        if(rolesForThisUser.Contains(urole.Name))
            //        {
            //            sur.Selected = true;
            //        }
            //    }
            //    ur.UserName = user.UserName;
            //    ur.ls.Add(sur);
            //    lur.ls.Add(ur);
            //    // prepopulat roles for the view dropdown
            //    //var listRolesForThisUser = ctx.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //    //ViewBag.RolesForThisUser = listRolesForThisUser;
            //}
            ////ViewBag.RolesForThisUser = listRolesForThisUser;

            Session["lur"] = lur;

            return View(lur);
        }


        [HttpGet]
        public ActionResult ManageUserRolesEdit(int id)
        {
            lur = (List<RoleSelectEditorViewModel>)Session["lur"];
            RoleSelectEditorViewModel thisUR = lur.Where(r => r.Id == id).FirstOrDefault();//ctx.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Session["thisUR"] = thisUR;
            return View(thisUR);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ManageUserRolesEdit(RoleSelectEditorViewModel model)
        //{
        //    //string results = collection["Blanks"];

        //    return Content(String.Format("result is: "));
        //}

        [HttpPost]
        [ValidateAntiForgeryToken] //MQ: make Blanks not an array? 
        public ActionResult ManageUserRolesEdit(bool[] Blanks)//FormCollection collection)//RoleSelectEditorViewModel model)
        {
            //string results = collection["Blanks"];

            lur = (List<RoleSelectEditorViewModel>)Session["lur"];

            try
            {
                if(ModelState.IsValid)
                {
                    RoleSelectEditorViewModel thisUR = (RoleSelectEditorViewModel)Session["thisUR"];
                    int count = 0;
                    bool result = false;
                    StringBuilder sb = new StringBuilder();
                    foreach (var x in thisUR.s)
                    {
                        if(x.Selected != Blanks[count])
                        {
                            sb.Append("Changes for: " + x.Role.Name + ",");
                            if (x.Selected == true && Blanks[count] == false)
                            {
                                result = DeleteRoleForUser(thisUR.User.UserName, x.Role.Name);

                                //RoleSelectEditorViewModel theUR = lur.Where(b => b.User.UserName == thisUR.User.UserName).FirstOrDefault();
                                //SeleceEitorViewModel theRole = theUR.s.Where(b => b.Role.Name == x.Role.Name).FirstOrDefault();
                                //theRole.Selected = true;
                                //int indexOftheUR = theUR.s.IndexOf(theRole);
                                //theUR.s[indexOftheUR].Selected = theRole.Selected;
                                //int indexOfLUR = lur.IndexOf(theUR);
                                //lur[indexOfLUR] = theUR;

                            }
                            else if (x.Selected == false && Blanks[count] == true)
                            {
                                result = RoleAddToUser(thisUR.User.UserName, x.Role.Name);

                                //RoleSelectEditorViewModel theUR = lur.Where(b => b.User.UserName == thisUR.User.UserName).FirstOrDefault();
                                //SeleceEitorViewModel theRole = theUR.s.Where(b => b.Role.Name == x.Role.Name).FirstOrDefault();
                                //theRole.Selected = false;
                                //int indexOftheUR = theUR.s.IndexOf(theRole);
                                //theUR.s[indexOftheUR].Selected = theRole.Selected;
                                //int indexOfLUR = lur.IndexOf(theUR);
                                //lur[indexOfLUR] = theUR;
                            }
                            else
                                sb.Append("Error Occured for ...."+ count.ToString());
                        }
                        else
                        //if (!result)
                        {
                            sb.Append("<br />No Changes for: " + x.Role.Name + ",");
                        }
                        count++;
                    }
                    //return Content(String.Format("{0}", sb));
                }
            }
            catch
            {
                return View();
            }

            //return Content(String.Format("result is: "));
            return RedirectToAction("ManageUserRoles");
        }

        [HttpGet]
        public PartialViewResult ManageUserRolesEdit_Ajax(int id)
        {
            lur = (List<RoleSelectEditorViewModel>)Session["lur"];
            RoleSelectEditorViewModel thisUR = lur.Where(r => r.Id == id).FirstOrDefault();//ctx.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Session["thisUR"] = thisUR;
            return PartialView("ManageUserRoles_Ajax",thisUR);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //MQ: make Blanks not an array? 
        public ActionResult ManageUserRolesEdit_Ajax(bool[] Blanks)//FormCollection collection)//RoleSelectEditorViewModel model)
        {
            //string results = collection["Blanks"];

            lur = (List<RoleSelectEditorViewModel>)Session["lur"];

            try
            {
                if (ModelState.IsValid)
                {
                    RoleSelectEditorViewModel thisUR = (RoleSelectEditorViewModel)Session["thisUR"];
                    int count = 0;
                    bool result = false;
                    StringBuilder sb = new StringBuilder();
                    foreach (var x in thisUR.s)
                    {
                        if (x.Selected != Blanks[count])
                        {
                            sb.Append("Changes for: " + x.Role.Name + ",");
                            if (x.Selected == true && Blanks[count] == false)
                            {
                                result = DeleteRoleForUser(thisUR.User.UserName, x.Role.Name);

                                RoleSelectEditorViewModel theUR = lur.Where(b => b.User.UserName == thisUR.User.UserName).FirstOrDefault();
                                SeleceEitorViewModel theRole = theUR.s.Where(b => b.Role.Name == x.Role.Name).FirstOrDefault();
                                theRole.Selected = true;
                                int indexOftheUR = theUR.s.IndexOf(theRole);
                                theUR.s[indexOftheUR].Selected = theRole.Selected;
                                int indexOfLUR = lur.IndexOf(theUR);
                                lur[indexOfLUR] = theUR;

                            }
                            else if (x.Selected == false && Blanks[count] == true)
                            {
                                result = RoleAddToUser(thisUR.User.UserName, x.Role.Name);

                                RoleSelectEditorViewModel theUR = lur.Where(b => b.User.UserName == thisUR.User.UserName).FirstOrDefault();
                                SeleceEitorViewModel theRole = theUR.s.Where(b => b.Role.Name == x.Role.Name).FirstOrDefault();
                                theRole.Selected = false;
                                int indexOftheUR = theUR.s.IndexOf(theRole);
                                theUR.s[indexOftheUR].Selected = theRole.Selected;
                                int indexOfLUR = lur.IndexOf(theUR);
                                lur[indexOfLUR] = theUR;
                            }
                            else
                                sb.Append("Error Occured for ...." + count.ToString());
                        }
                        else
                        //if (!result)
                        {
                            sb.Append("<br />No Changes for: " + x.Role.Name + ",");
                        }
                        count++;
                    }
                    //return Content(String.Format("{0}", sb));
                }
            }
            catch
            {
                return View();
            }

            //return Content(String.Format("result is: "));
            //return PartialView("ManageUserRoles", lur);
            return RedirectToAction("ManageUserRoles");
        }

        //[HttpPost]
        //public ActionResult ManageUserRoles(FormCollection form, string ViewModelName)
        //{
        //    Assembly assembly = typeof(UserRoleListEditorViewModel).Assembly;
        //    Type type = assembly.GetType(ViewModelName);
        //    object ViewModel = Activator.CreateInstance(type);

        //    if (!TryUpdateModel(ViewModel, form.ToValueProvider()))
        //    {
        //        //some another actions
        //    }

        //    return View(ViewModelName, ViewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ManageUserRolesSave(/*FormCollection form*/ UserRoleListEditorViewModel mm)//, ref bool chk)
        //{
        //    //UserRoleListEditorViewModel lur; // = new UserRoleListEditorViewModel();
        //    //model = (UserRoleListEditorViewModel)Session["lur"];

        //    StringBuilder sb = new StringBuilder();

        //    //string s = form.Keys.ToString();

        //    //for (int i = 0; i < bettingOfficeIDs.Count(); i++)
        //    //{
        //    //    sb.Append(bettingOfficeIDs[i].ToString() + "<br />");
        //    //}

        //    //HttpContext.Items<

        //    foreach (var x in mm.ls)
        //    {
        //        sb.Append(" " + x.User.UserName + "<br />");
        //        foreach (var b in x.s)
        //        {
        //            sb.Append(" " + b.Selected.ToString() + "<br />");
        //        }
        //    }

        //    return Content("Called with " + sb);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ManageUserRoles(/*FormCollection form*/ UserRoleListEditorViewModel model)//, ref bool chk)
        //{
        //    //UserRoleListEditorViewModel lur; // = new UserRoleListEditorViewModel();
        //    //model = (UserRoleListEditorViewModel)Session["lur"];

        //    StringBuilder sb = new StringBuilder();

        //    //string s = form.Keys.ToString();

        //    //for (int i = 0; i < bettingOfficeIDs.Count(); i++)
        //    //{
        //    //    sb.Append(bettingOfficeIDs[i].ToString() + "<br />");
        //    //}

        //    //HttpContext.Items<

        //    foreach (var x in model.ls)
        //    {
        //        sb.Append(" " + x.User.UserName + "<br />");
        //        foreach (var b in x.s)
        //        {
        //            sb.Append(" " + b.Selected.ToString() + "<br />");
        //        }
        //    }

        //    return Content("Called with " + sb);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        private bool RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = userManager.AddToRole(user.Id, RoleName);
            //var account = new AccountController();
            //account.UserManager.AddToRoleAsync(user.Id, RoleName);


            //ViewBag.ResultMessage = "Role created successfully !";

            //// prepopulat roles for the view dropdown
            //var list = ctx.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.Roles = list;

            return result.Succeeded;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new AccountController();

                ViewBag.RolesForThisUser = account.UserManager.GetRolesAsync(user.Id);

                // prepopulat roles for the view dropdown
                var list = ctx.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        private bool DeleteRoleForUser(string UserName, string RoleName)
        {
            //var account = new AccountController();
            ApplicationUser user = ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = userManager.RemoveFromRole(user.Id, RoleName);

            ////bool b = await account.UserManager.IsInRoleAsync(user.Id, RoleName);
            //var isInRole = account.UserManager.IsInRoleAsync(user.Id, RoleName);
            ////if (isInRole)
            ////{
            //    account.UserManager.RemoveFromRoleAsync(user.Id, RoleName);
            //    ViewBag.ResultMessage = "Role removed from this user successfully !";
            ////}
            ////else
            ////{
            ////    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            ////}
            //// prepopulat roles for the view dropdown
            //var list = ctx.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.Roles = list;

            return result.Succeeded;
        }
    }
}