using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EM_ConProjects.Models.DataModel;
using EM_ConProjects.Models;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace EM_ConProjects.Controllers
{
    public class ProjectsController : Controller
    {
        private Projects_DBContainer db = new Projects_DBContainer();

        //This declares the variable that Dapper will use to acces the database.
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        // GET: /Projects/
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult Dashboard()
        {

            DashboardView dash = new DashboardView();

            dash.totalActions = db.Actions.Count();
            dash.totalContactors = db.Contractors.Count();
            dash.totalLocations = db.Localities.Count();
            dash.totalProjects = db.Projects.Count();

            //Retrieve total number of projects in the database that have the status completed
            dash.totalProjectsComplete =  con.Query<int>("SELECT COUNT(Project_Id) FROM Projects WHERE ProjectStatus = 'Complete'").SingleOrDefault();

            //get completed actions
            dash.totalActionComplete = con.Query<int>("SELECT Count(Actions_Id) FROM Actions WHERE Status = 'Complete'").SingleOrDefault();
            //get actual site visits
            //dash.actualSiteVisits = con.Query<int>("SELECT SUM(ActualVisits) FROM Projects").SingleOrDefault();
            //get total site visits
            //dash.siteVisits = con.Query<int>("SELECT SUM(SiteVisits) FROM Projects").SingleOrDefault();
            //get recently added projects
            //dash.projects = con.Query("").ToList();

            //This will be the user database count
            //dash.locationNames = con.Query<List>("SELECT LocalityName FROM Localities").ToList();
            dash.totalUsers = 10;
            dash.siteVisits = 8;
            dash.actualSiteVisits = 2;
            dash.totalProjects = 16;
            dash.totalProjectsComplete = 9;
            dash.companyEfficiencyRatio = Math.Round((double)(dash.totalProjectsComplete / dash.totalProjects * 100), 2);


            //loop through the projects
            //take project in position x of project list and add it to position x in the viewmodellist
            //take action at x in action list and add it to project position x action x
            List<ProjectsViewModel> projectList = new List<ProjectsViewModel>();
            List<Projects> projects = db.Projects.ToList();
            List<Actions> actions = db.Actions.ToList();
            List<Contractors> contractors = db.Contractors.ToList();
            List<Localities> locations = db.Localities.ToList();        
   

            
            //for (int x = 0; x < projects.Count; x++ )
            //{
            //    ProjectsViewModel thisModel = new ProjectsViewModel();
            //    thisModel.projectActions = new List<Actions>();
            //    thisModel.projectLocs = new List<Localities>();
            //    thisModel.projectsConts = new List<Contractors>();

            //    thisModel.thisProject = projects[x];
                
            //    //add actions to list
            //    foreach (var item in actions)
            //    {
            //        thisModel.projectActions.Add(item);
            //    }

            //    //add locations to list
            //    foreach (var item in locations)
            //    {
            //        thisModel.projectLocs.Add(item);
            //    }

            //    //add contractors to list
            //    foreach (var item in contractors)
            //    {
            //        thisModel.projectsConts.Add(item);
            //    }                
                
            //    projectList.Add(thisModel);
            //}



            return View(dash);
        }
        // GET: /Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // GET: /Projects/Create
        public ActionResult Create()
        {

            var stats = new[] 
            { 
                new SelectListItem(){Value = "Complete", Text= "Complete"},
                new SelectListItem(){Value = "In progress", Text="In progress"},
                new SelectListItem(){Value = "Invoice", Text= "Invoice"},
                new SelectListItem(){Value = "Close", Text= "Close"},
                new SelectListItem(){Value = "Pending", Text= "Pending"},
                new SelectListItem(){Value = "Delayed", Text="Delayed"},
                new SelectListItem(){Value = "Due for retention", Text= "Due for retention"}

            };

            ViewBag.Stats = stats;

            var actionStat = new[] 
            { 
                new SelectListItem(){Value = "Complete", Text= "Complete"},
                new SelectListItem(){Value = "Start", Text= "Start"},
                new SelectListItem(){Value = "Incomplete", Text= "Incomplete"},
            };

            ViewBag.ActStat = actionStat;

            ViewBag.Amount = db.Projects.Count();

            ProjectsViewModel thisModel = new ProjectsViewModel();

            return View(thisModel);

        }

        // POST: /Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectsViewModel projects)
        {
            int projectId;
            try
            {
                // TODO: This is the data saving logic

                //Save Project to Databse
                try
                {

                    con.Open();

                    int lastProjectId = con.Query<int>("SELECT IDENT_CURRENT( 'Projects' )").FirstOrDefault();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@projectCode", "PP-" + lastProjectId);
                    param.Add("@projectName", projects.thisProject.ProjectName);
                    param.Add("@projectStatus", projects.thisProject.ProjectStatus);
                    param.Add("@projectLeader", projects.thisProject.ProjectLeader);
                    param.Add("@projectSiteVisits", projects.thisProject.SiteVisits);
                    param.Add("@projectStartDate", projects.thisProject.StartDate);
                    param.Add("@projectEndDate", projects.thisProject.EndDate);
                   // param.Add("@projectActualVisits", projects.thisProject.ActualVisits);

                    param.Add("@projectId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    con.Execute("insertProject", param, commandType: CommandType.StoredProcedure);
                    con.Close();

                    projectId = param.Get<int>("@projectId");

                }
                catch (Exception ex)
                {
                    //Log error as per your need 
                    throw ex;
                }

                //Save Localities to Database
                try
                {
                    foreach (var item in projects.projectLocs)
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@localityName", item.LocalityName);
                        param.Add("@projectId", projectId);
                        con.Open();
                        con.Execute("insertLocality", param, commandType: CommandType.StoredProcedure);
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    //Log error as per your need 
                    throw ex;
                }

                //Save Contractors to Database
                try
                {

                    foreach (var item in projects.projectsConts)
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@companyName", item.CompanyName);
                        param.Add("@contractorName", item.ContractorName);
                        param.Add("@contractorSurname", item.ContractorSurname);
                        param.Add("@contractorTel", item.ContractorTel);
                        param.Add("@projectId", projectId);
                        con.Open();
                        con.Execute("insertContractor", param, commandType: CommandType.StoredProcedure);
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    //Log error as per your need 
                    throw ex;
                }

                //Save Actions to Database
                try
                {

                    foreach (var item in projects.projectActions)
                    {
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@actionName", item.ActionDesc);
                        param.Add("@actionStatus", item.Status);
                        param.Add("@projectId", projectId);
                        con.Open();
                        con.Execute("insertAction", param, commandType: CommandType.StoredProcedure);
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    //Log error as per your need 
                    throw ex;
                }


                return RedirectToAction("CreateComplaint");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: /Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsViewModel toEdit = new ProjectsViewModel();
            
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            var actionStat = new[] 
            { 
                new SelectListItem(){Value = "Complete", Text= "Complete"},
                new SelectListItem(){Value = "Start", Text= "Start"},
                new SelectListItem(){Value = "Incomplete", Text= "Incomplete"},
            };

            ViewBag.ActStat = actionStat;

            ViewBag.Amount = db.Projects.Count();
            toEdit.thisProject = projects;

            return View(toEdit);
        }

        // POST: /Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Id,ProjectCode,ProjectName,ProjectStatus,ProjectLeader")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: /Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projects projects = db.Projects.Find(id);
            db.Projects.Remove(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
