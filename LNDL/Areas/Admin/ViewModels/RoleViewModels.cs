using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDL.Areas.Admin.ViewModels
{

    //public class UserRoleListEditorViewModel
    //{
    //    ///public int Id { get; set; }
    //    public List<IdentityRole> lr {get;set;}
    //    public List<RoleSelectEditorViewModel> ls { get; set; }
    //    public UserRoleListEditorViewModel()
    //    {
    //        //this.lr = new List<IdentityRole>();
    //        this.ls = new List<RoleSelectEditorViewModel>();
    //    }
    //}

    public class RoleSelectEditorViewModel
    {

        public RoleSelectEditorViewModel() 
        {
            this.User = new IdentityUser();
            this.s = new List<SeleceEitorViewModel>();
        }

        // Update this to accept an argument of type ApplicationRole:
        //public SelectRoleEditorViewModel(IdentityRole role)
        //{
        //    this.RoleName = role.Name;

        //    //// Assign the new Descrption property:
        //    //this.Description = role.Description;
        //}
        public int Id { get; set; }

        public IdentityUser User { get; set; }

        public List<SeleceEitorViewModel> s { get; set; }

        //public IdentityRole Role { get; set; }

    }

    //public class UserRoleEditorViewModel
    //{
    //    public string UserName { get; set; }
    //    public List<SelectRoleEditorViewModel> ls { get; set; }
    //    public UserRoleEditorViewModel() 
    //    {
    //        this.ls = new List<SelectRoleEditorViewModel>();
    //    }
    //    public UserRoleEditorViewModel(IdentityUser user) :this()
    //    {
    //        this.UserName = user.UserName;
    //    }


    //}
    
    public class SeleceEitorViewModel
    {
        public SeleceEitorViewModel()
        {
            this.Role = new IdentityRole();
        }

        // update this to accept an argument of type applicationrole:
        //public selectroleeditorviewmodel(identityrole role)
        //{
        //    this.rolename = role.name;

        //    //// assign the new descrption property:
        //    //this.description = role.description;
        //}


        public bool Selected { get; set; }

        public IdentityRole Role { get; set; }

        //// Add the new Description property:
        //public string Description { get; set; }
    }

    public class RoleViewModel
    {
        public string RoleName { get; set; }
        //public string Description { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(/*ApplicationRole*/IdentityRole role)
        {
            this.RoleName = role.Name;
            //this.Description = role.Description;
        }
    }

    public class EditRoleViewModel
    {
        public string OriginalRoleName { get; set; }
        public string RoleName { get; set; }
        //public string Description { get; set; }

        public EditRoleViewModel() { }
        public EditRoleViewModel(/*ApplicationRole*/IdentityRole role)
        {
            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
            //this.Description = role.Description;
        }
    }


}