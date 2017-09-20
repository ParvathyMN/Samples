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


        [TestAutherization("Admin", "Manager")]
        // [OutputCache(Duration = 10)]
        [TestAuthentication]
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult Main_Partial()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //    // return RedirectToAction("display");
        //}
        [HttpGet]
        [ActionName("Create")]
        public ActionResult getCreate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult postCreate()
        {
            TestDb db = new TestDb();
            Test1 t = new Test1();
            UpdateModel<Test1>(t);
           // var ab = form["Id"];
            db.Tests.Add(t);
           
            db.SaveChanges();
            return RedirectToAction("Display");
           
         
        }

        [HttpGet]
        public ActionResult CreateDrop()
        {
            var list1 = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="abc",
                    Value="abc"
                },

                new SelectListItem
                {
                    Text="def",
                    Value="def"
                },

                new SelectListItem
                {
                    Text="ghi",
                    Value="ghi"
                }
            };
            ViewBag.name = list1;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDrop(Test1 std)
        {
            if (ModelState.IsValid)
            {
                TestDb db = new TestDb();
                db.Tests.Add(std);
                db.SaveChanges();
                return Json(new { message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(std);
            }
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchDisplay(string name)
        {
            TestDb db = new TestDb();
            var stu = (from s in db.Tests where s.Name == name select s).FirstOrDefault();
            return View(stu);
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
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Test1 std)
        {
            TestDb db = new TestDb();
           // var id = Convert.ToInt32( form["Id"]);
            var stu = (from s in db.Tests
                      where s.Id==std.Id
                      select s).FirstOrDefault();
            // stu.Id = id;
            //stu.Age = Convert.ToInt32( form["Age"]);
            stu.Name = std.Name;
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




