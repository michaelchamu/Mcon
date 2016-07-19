//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EM_ConProjects.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projects
    {
        public Projects()
        {
            this.Localities = new HashSet<Localities>();
            this.Contractors = new HashSet<Contractors>();
            this.Actions = new HashSet<Actions>();
        }
    
        public int Project_Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectLeader { get; set; }
        public int SiteVisits { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual ICollection<Localities> Localities { get; set; }
        public virtual ICollection<Contractors> Contractors { get; set; }
        public virtual ICollection<Actions> Actions { get; set; }
    }
}
