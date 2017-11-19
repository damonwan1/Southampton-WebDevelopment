using HouseSystem.DAL;
using HouseSystem.Models;
using System.Web.Mvc;

namespace HouseSystem.Controllers
{
    public class LoginController : Controller
    {
       //  private HouseContext db = new HouseContext();
        private StudentDAO studentDao = new StudentDAO();
        private LandlordDAO landlordDao = new LandlordDAO();
        private UniversityStaffDAO universityStaffDao = new UniversityStaffDAO();

        public ActionResult Logout() {
            if (HttpContext.Session["ID"] != null && !HttpContext.Session["ID"].ToString().Equals(""))
            {
                HttpContext.Session.Clear();
                TempData["Message"] = "logout successfully!";
            }
            else
            {
                TempData["Message"] = "please login in again!";
            }
            return RedirectToAction("index", "Home");
        }

        // GET: Login
        public ActionResult Login(string username,string password,string role)
        {
            if (username != null && password != null && role != null)
            {
                if (role.Equals("student"))
                {
                    Student student = studentDao.GetStudentByUsername(username);
                    if (student == null)
                    {
                        TempData["Message"] = "Username does not exist,please check again!";
                        return RedirectToAction("index", "Home");
                    }
                    else if (student != null && !student.Password.Equals(password))
                    {
                        TempData["Message"] = "Password is not correct,please try again!";
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.Add("ID", student.ID);
                        return RedirectToAction("index", "Student");
                    }

                }
                else if (role.Equals("staff"))
                {
                    UniversityStaff staff = universityStaffDao.GetStaffByUsername(username);
                    if (staff == null)
                    {
                        TempData["Message"] = "Username does not exist,please check again!";
                        return RedirectToAction("index", "Home");
                    }
                    else if (staff != null && !staff.Password.Equals(password))
                    {
                        TempData["Message"] = "Password is not correct,please try again!";
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.Add("ID", staff.ID);
                        return RedirectToAction("Index", "UniversityStaff");
                    }
                }
                else if (role.Equals("landlord"))
                {
                    Landlord landlord = landlordDao.GetLandlordByUsername(username);
                    if (landlord == null)
                    {
                        TempData["Message"] = "Username does not exist,please check again!";
                        return RedirectToAction("index", "Home");
                    }
                    else if (landlord != null && !landlord.Password.Equals(password))
                    {
                        TempData["Message"] = "Password is not correct,please try again!";
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.Add("ID", landlord.ID);
                        return RedirectToAction("index", "Landlord");
                    }
                }
                else {
                    TempData["Message"] = "Please select your role!";
                    return RedirectToAction("index","Home");
                }
            }
            else {
                TempData["Message"] = "Username & Password & Role can not be empty!";
                return RedirectToAction("index","Home"); 
            }
        }
    }
}