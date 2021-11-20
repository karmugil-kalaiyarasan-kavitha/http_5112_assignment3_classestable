using System;
//using System.DateTime;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using http_5112_assignment3_class.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace http_5112_assignment3_class.Controllers
{
    public class ClassesDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the classes table of our School database.
        /// <summary>
        /// Returns a calss in the system based on the teacher id
        /// </summary>
        /// <param name="id">eg:1</param>
        /// <example>api/classesdata/findclass/{id}</example>
        /// <returns>
        /// A class (classid,classcode,teacherid,startdate,finishdate,classname)
        /// </returns>
        [HttpGet]
        [Route("api/classesdata/findclass/{id}")]
        public List<Classes> FindClass(int id)
        {
            //storing the sql query in string datatype
            string classQuery = "select * from classes,teachers where classes.teacherid=teachers.teacherid and classes.teacherid=" + id;
            //"select classes.classcode,classes.classname from classes,teachers where classes.teacherid=teachers.teacherid and classes.teacherid=" + id;
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = classQuery;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Classes Names
            List<Classes> ClassesNames = new List<Classes> { };


            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //create a instance of classes model
                Classes SelectedClasses = new Classes();
                //Access Column information by the DB column name as an index
                SelectedClasses.classId = Convert.ToInt32(ResultSet["classid"]);
                SelectedClasses.classCode = ResultSet["classcode"].ToString();
                SelectedClasses.teacherId = Convert.ToInt32(ResultSet["teacherid"]);
                SelectedClasses.className = ResultSet["classname"].ToString();
                SelectedClasses.startDate = ResultSet["startdate"].ToString();
                SelectedClasses.finishDate = ResultSet["finishdate"].ToString();
 
                //Add the Classes data to the List

                ClassesNames.Add(SelectedClasses);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();
            //Return the final list of classes data
            return ClassesNames;
        }

        /// <summary>
        /// Returns a list of classes in the system 
        /// </summary>
        /// <example>api/classesdata/listclasses}</example>
        /// <returns>
        /// A class (classid,classcode,teacherid,startdate,finishdate,classname)
        /// </returns>

        [HttpGet]
        [Route("api/classesdata/listclasses")]
        public List<Classes> ListClasses()
        {
            string classQuery = "Select * from classes";

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY

            cmd.CommandText = classQuery;
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            List<Classes> ClassNames = new List<Classes> { };

            while (ResultSet.Read())
            {
                Classes SelectedClasses = new Classes();
                SelectedClasses.classId = Convert.ToInt32(ResultSet["classid"]);
                SelectedClasses.classCode = ResultSet["classcode"].ToString();
                SelectedClasses.teacherId = Convert.ToInt32(ResultSet["teacherid"]);
                SelectedClasses.className = ResultSet["classname"].ToString();
                SelectedClasses.startDate = ResultSet["startdate"].ToString();
                SelectedClasses.finishDate = ResultSet["finishdate"].ToString();

                ClassNames.Add(SelectedClasses);
            }

            Conn.Close();

            return ClassNames;
        }
    }
}
