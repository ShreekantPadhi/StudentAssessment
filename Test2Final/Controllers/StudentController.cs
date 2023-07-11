using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2Final.Models;


namespace Test2Final.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<StudentModel>("StudentViewAll", null));
        }

        [HttpGet]
        public ActionResult AddorEdit(int id =0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                return View(DapperORM.ReturnList<StudentModel>("StudentViewByID",param).FirstOrDefault<StudentModel>());
                    }
        }
        [HttpPost]
        public ActionResult AddorEdit(StudentModel studentmodel)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@id", studentmodel.id);
            param.Add("@admnNo", studentmodel.admnNo);
            param.Add("@subjectName", studentmodel.subjectName);
            param.Add("@minMarks", studentmodel.minMarks);
            param.Add("@maxMarks", studentmodel.maxMarks);
            param.Add("@marks", studentmodel.marks);
            param.Add("@status", studentmodel.status);

            DapperORM.ExcecuteWithoutReturn("StudentAddorEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id" , id);
            DapperORM.ExcecuteWithoutReturn("StudentDeleteById", param);
            return RedirectToAction("Index");

        }
    }
}