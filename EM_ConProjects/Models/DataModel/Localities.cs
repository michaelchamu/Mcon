
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
    
public partial class Localities
{

    public int Locality_Id { get; set; }

    public string LocalityName { get; set; }

    public int ProjectsProject_Id { get; set; }



    public virtual Projects Project { get; set; }

}

}
