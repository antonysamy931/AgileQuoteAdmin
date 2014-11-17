using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
    public class RoleProperty
    {
        
        public int RoleId { get; set; }
        
        [Display(Name="Role Name")]
        [Required(ErrorMessage="Please enter role name")]
        public string RoleName { get; set; }

        [Display(Name="Priority")]
        [Required(ErrorMessage="Please enter priority")]
        public int Priority { get; set; }
        
        [Display(Name="Visible")]
        public bool IsVisible { get; set; }

        [Display(Name="Delete")]
        public bool IsDelete { get; set; }
    }
    public class RoleListProperty
    {
        public List<RoleProperty> RoleList{get;set;}
    }
}
