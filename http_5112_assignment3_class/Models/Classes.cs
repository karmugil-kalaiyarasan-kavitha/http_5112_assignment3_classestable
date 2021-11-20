using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace http_5112_assignment3_class.Models
{
    public class Classes
    {
        //classid,classcode,teacherid,startdate,finishdate,classname
        public int classId { get; set; }
        public String classCode { get; set; }
        public int teacherId { get; set; }
        public String startDate { get; set; }
        public String finishDate { get; set; }
        public String className { get; set; }
    }
}