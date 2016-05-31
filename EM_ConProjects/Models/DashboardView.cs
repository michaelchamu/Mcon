using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EM_ConProjects.Models.DataModel;

namespace EM_ConProjects.Models
{
    public class DashboardView
    {

        public int totalProjects { get; set; }
        public int totalProjectsComplete { get; set; }
        public double companyEfficiencyRatio { get; set; }
        public int totalUsers { get; set; }
        public int totalActions { get; set; }
        public int totalContactors { get; set; }
        public int totalLocations { get; set; }
        public int totalActionComplete { get; set; }
        public int siteVisits { get; set; }
        public string locationNames { get; set; }
        public List<Projects> projects {get; set;}
        public string receivedProjects { get; set; }
        public string completedProjects { get; set; }
    }

    public class ProjectsObject
    {
        public int numberOfProjects { get; set; }
        public string month { get; set; }
    }
}