using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using http_5112_assignment3_class.Models;


namespace http_5112_assignment3_class.Controllers
{
    public class ClassesController : Controller
    {
        /// <summary>
        /// Returns a classes in the system based on the teacher id to the view
        /// </summary>
        /// <param name="id">eg:1</param>
        /// <example>Classes/ShowClasses/{id}</example>
        /// <returns>
        /// A class (classid,classcode,teacherid,startdate,finishdate,classname)
        /// </returns>

        //get: Classes/ShowClasses/{id}
        [HttpGet]
        [Route("Classes/ShowClasses/{id}")]
        public ActionResult ShowClasses(int id)
        {
            //TeacherDataController Controller = new TeacherDataController();
            ClassesDataController ControllerForClasses = new ClassesDataController();
            //Teacher SelectedTeacher = Controller.FindTeacher(id);
            IEnumerable<Classes> SelectedClasses = ControllerForClasses.FindClass(id);
            return View(SelectedClasses);
        }

        /// <summary>
        /// Returns a list of classes in the system and allow us to search based on classid,classcode,teacherid,startdate,finishdate,classname by providong it to view
        /// </summary>
        /// <example>Classes/List</example>
        /// <returns>
        /// A list of classes (classid,classcode,teacherid,startdate,finishdate,classname)
        /// </returns>

        // GET: Classes/List
        [HttpGet]
        public ActionResult List()
        {
            ClassesDataController Controller = new ClassesDataController();
            IEnumerable<Classes> Classes = Controller.ListClasses();
            return View(Classes);
        }

    }
}
