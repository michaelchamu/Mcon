using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM_ConProjects.Models
{
    public class DashboardView
    {

        public int totalProjects { get; set; }
        public int totalProjectsComplete { get; set; }
        public double companyEfficiencyRatio { get; set; }
        public int totalUsers { get; set; }
        
    }
}