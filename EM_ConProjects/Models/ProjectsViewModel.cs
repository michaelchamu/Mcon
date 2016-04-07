using EM_ConProjects.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM_ConProjects.Models
{
    public class ProjectsViewModel
    {

        public Projects thisProject { get; set; }

        public List<Localities> projectLocs { get; set; }

        public List<Contractors> projectsConts { get; set; }

        public List<Actions> projectActions { get; set; }

    }
}