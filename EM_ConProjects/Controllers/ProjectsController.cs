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

namespace EM_ConProjects.Controllers
{
    public class ProjectsController : Controller
    {
        private Projects_DBContainer db = new Projects_DBContainer();

        // GET: /Projects/
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult Dashboard()
        {
           

            //loop through the projects
            //take project in position x of project list and add it to position x in the viewmodellist
            //take action at x in action list and add it to project position x action x
            List<ProjectsViewModel> projectList = new List<ProjectsViewModel>();
            List<Projects> projects = db.Projects.ToList();
            List<Actions> actions = db.Actions.ToList();
            List<Contractors> contractors = db.Contractors.ToList();
            List<Localities> locations = db.Localities.ToList();

            int projectsCount, actionsCount, contractorCount, locationCount, i, x, y, z;

            projectsCount = projects.Count();
            actionsCount = actions.Count();
            contractorCount = contractors.Count();
            locationCount = locations.Count();
            
            for (x = 0; x < projectsCount; x++ )
            {
                projectList[x].thisProject = projects[x];
                //add actions to list
                for (i = 0; i < actionsCount; i++)
                {
                    projectList[x].projectActions[i] = actions[i];
                }
                //add locations to list
                for (y = 0; y < locationCount;y++ )
                {
                    projectList[x].projectLocs[y] = locations[y];
                }
                //add contractors to list
                for (z = 0; z < contractorCount;z++ )
                {
                    projectList[x].projectsConts[z] = contractors[z];
                }
            }
            return View(projectList.ToList());
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
                new SelectListItem(){Value = "Invoice", Text= "Invoice"},
                new SelectListItem(){Value = "Close", Text= "Close"},
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
            if (projects != null)
            {
                int i = projects.projectActions.Count();
                int x = projects.projectLocs.Count();
                int z = projects.projectsConts.Count();

                //save project instance first and obtain project id

                db.Projects.Add(projects.thisProject);
                db.SaveChanges();
                //get saved project id
                int projectId = projects.thisProject.Project_Id;
                //populate each relation with retrieved id

                //iterate through the list and save each record
                for (int l = 0; l < x; l++)
                {
                    Localities locality = projects.projectLocs[l];
                    locality.ProjectsProject_Id = projectId;
                    db.Localities.Add(locality);
                    db.SaveChanges();
                }
                for (int l = 0; l < i; l++)
                {
                    Actions action = projects.projectActions[l];
                    action.ProjectsProject_Id = projectId;
                    db.Actions.Add(action);
                    db.SaveChanges();
                }
                for (int l = 0; l < z; l++)
                {
                    Contractors contractors = projects.projectsConts[l];
                    contractors.ProjectsProject_Id = projectId;
                    db.Contractors.Add(contractors);
                    db.SaveChanges();
                }

                return Json("Actions: " + i + " Locations: " + x + " Contracts: " + z);
            }
            else
            {
                return Json("Error");
            }
            /*
            if (localities != null && actions != null && contractors != null && projects != null)
            {
                return Json("Locations: "+localities.ToString() + "\n" + "Actions: "+actions.ToString() + "\n"
                            + "Contractors: "+contractors.ToString() + "\n" +"Projects: "+ projects.ToString());
            }
            else
            {
                return Json("Error");
            }
            /*if (ModelState.IsValid)
            {
                db.Projects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var stats = new[] 
            { 
                new SelectListItem(){Value = "Complete", Text= "Complete"},
                new SelectListItem(){Value = "Invoice", Text= "Invoice"},
                new SelectListItem(){Value = "Close", Text= "Close"},
            };

            ViewBag.Stats = stats;

            return View(projects);*/
        }

        // GET: /Projects/Edit/5
        public ActionResult Edit(int? id)
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
