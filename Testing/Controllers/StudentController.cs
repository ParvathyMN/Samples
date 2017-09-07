using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    //[TestActionFilter]
    public class StudentController : Controller
    {
        // GET: Student

        //[TestAuthentication]
        //[TestAutherization("Admin", "Manager")]
       // [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult Main_Partial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
            // return RedirectToAction("display");
        }


        [HttpPost]
        public ActionResult Create(Test1 std)
        {
            TestDb db = new TestDb();
            db.Tests.Add(std);
            db.SaveChanges();
            return RedirectToAction("Display");
           
         
        }
        public JsonResult IsValidName(string Name)
        {
            TestDb db = new TestDb();
            bool isvalid = true;
            string UserName = (from b in db.Tests where b.Name==Name select b.Name).FirstOrDefault();
            if(UserName!=null)
            isvalid = false;
            return Json(isvalid, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Display()
        {
            TestDb db = new TestDb();
            List<Test1> li = db.Tests.ToList();  
            return View(li);
        }


        public ActionResult Edit(Test1 std)
        {
            TestDb db = new TestDb();
            var stu = (from s in db.Tests
                      where s.Id==std.Id
                      select s).FirstOrDefault();
            stu.Name =std.Name;
            stu.Age = std.Age;
            db.SaveChanges();
            return View();
        }

     
        public ActionResult Delete(int id)
        {
            TestDb db = new TestDb();
            Test1 stu = (from s in db.Tests
                         where s.Id == id
                         select s).FirstOrDefault();
            try
            {
                db.Tests.Remove(stu);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
           
                return View(stu);
            
        }
       


    }
}




