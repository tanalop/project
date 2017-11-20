using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonKhayHoi.Models;
using System.Data.Entity.Validation;

namespace KonKhayHoi.Controllers
{
    public class AdminController : Controller
    {
        private KonKhayHoiEntities db = new KonKhayHoiEntities();
        // GET: Admin
        public ActionResult Index()

        {
            return View();
        }

        public ActionResult ChangPassword()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangPassword(admin ad)
        {
            
            string password = Request.Form["password"];
            string newPass = Request.Form["newPess"];
            string cfnewPass = Request.Form["cfnewPass"];
            var CAID = Request.Cookies["AID"].Value;

            var checkeA = db.admins.Where(a => a.AID.Equals(CAID) ).FirstOrDefault();

            if (ModelState.IsValid)
            {

               
                if(checkeA.A_pass.Equals(password))
                {
                    if(newPass.Equals(cfnewPass))
                    {
                        checkeA.A_pass = newPass;
                        db.SaveChanges();

                    }
                    else
                    {
                        ViewBag.Error1 = "รหัสผ่านไม่ตรงกัน";
                    }
                }
                else
                {
                    ViewBag.Error = "รหัสผ่านผิด";
                }

                
                string query2 = "SELECT * FROM Farm ";
                var test = db.Database.SqlQuery<Farm>(query2).ToList();
                return View(Tuple.Create(test));
            }

            return View();
        }





        public ActionResult profile()
        {

            if (ModelState.IsValid)
            {
                var checkW = db.admins.FirstOrDefault();
                if (checkW != null)
                {
                    Session["ADuser"] = checkW.AID;

                    Session["ADname"] = checkW.A_name;

                    Session["ADlast"] = checkW.A_lastname;

                    Session["ADtel"] = checkW.A_tel;

                    Session["ADno"] = checkW.A_no;

                    Session["ADsubD"] = checkW.A_subD;

                    Session["ADsub"] = checkW.A_sub;

                    Session["ADproV"] = checkW.A_ProV;

                    Session["ADInvestment"] = checkW.A_Investment;

                }

            }

            return View();
        }




        public ActionResult Editprofile()

        {
            admin Admin = new admin();

            string AID_update = Request.Form["username_update"];
            string A_Investment_update = Request.Form["Investment_update"];
            string A_name_update = Request.Form["name_update"];
            string A_lastname_update = Request.Form["lastname_update"];
            string A_tel_update = Request.Form["tel_update"];
            string A_no_update = Request.Form["no_update"];
            string A_subD_update = Request.Form["subD_update"];
            string A_sub_update = Request.Form["sub_update"];
            string A_ProV_update = Request.Form["proV_update"];


            if (ModelState.IsValid)
            {
                if (AID_update != null)
                {

                    var checkUP = db.admins.Where(a => a.AID.Equals(AID_update)).FirstOrDefault();

                    int A = Convert.ToInt32(A_Investment_update);

                    checkUP.A_Investment = A;
                    checkUP.A_name = A_name_update;
                    checkUP.A_lastname = A_lastname_update;
                    checkUP.A_tel = A_tel_update;
                    checkUP.A_no = A_no_update;
                    checkUP.A_subD = A_subD_update;
                    checkUP.A_sub = A_sub_update;
                    checkUP.A_ProV = A_ProV_update;

                   

                    db.SaveChanges();

                    Session["ADuser"] = checkUP.AID;

                    Session["ADname"] = checkUP.A_name;

                    Session["ADlast"] = checkUP.A_lastname;

                    Session["ADtel"] = checkUP.A_tel;
    
                    Session["ADno"] = checkUP.A_no;

                    Session["ADsubD"] = checkUP.A_subD;

                    Session["ADsub"] = checkUP.A_sub;

                    Session["ADproV"] = checkUP.A_ProV;

                    Session["ADInvestment"] = checkUP.A_Investment;

                    return RedirectToAction("Editprofile", "Admin");

                    

                }
                      
            }
            return View();
        }



    }

}