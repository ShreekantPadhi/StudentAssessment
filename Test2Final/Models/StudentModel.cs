using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2Final.Models
{
    public class StudentModel
    {
        public int id { get; set; }

        public int admnNo { get; set; }

        public string subjectName { get; set; }

        public int maxMarks { get; set; }

        public int minMarks { get; set; }

        public int marks { get; set; }

        public string status { get; set; }
    }
}