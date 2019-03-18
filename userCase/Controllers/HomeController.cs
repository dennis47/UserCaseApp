using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userCase.Entity;
using userCase.Entity.Abstract;
using userCase.Models; 

namespace userCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<City> _cityRepo;
        private readonly IRepository<District> _districtRepo;
        public HomeController(IRepository<User> userRepo, IRepository<City> cityRepo, IRepository<District> districtRepo)
        {
            this._userRepo     = userRepo;
            this._cityRepo     = cityRepo;
            this._districtRepo = districtRepo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            CookieOptions cookie = new CookieOptions(); 
            if (Convert.ToBoolean(Request.Cookies["rememberMe"]))
            {
                ViewBag.email = Request.Cookies["email"];
                ViewBag.password = Request.Cookies["password"];
                ViewBag.rememberMe = "checked";
            }
            else
            {
                ViewBag.rememberMe = "";
                cookie.Expires = DateTime.Now.AddDays(-1);
            }
            return View();            
           // return Ok(_userRepo.List());            
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {   
            if (ModelState.IsValid)
            {                  
                User result = _userRepo.Find(a => a.email == model.email && a.password == model.password);
                if (result==null)
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                    return View();
                }
                else
                {  
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    if (model.rememberMe)
                    {
                       Response.Cookies.Append("email",model.email); 
                       Response.Cookies.Append("password",model.password); 
                       Response.Cookies.Append("rememberMe", model.rememberMe.ToString()); 
                    }
                    else
                    {
                        Response.Cookies.Append("email", model.email);
                        Response.Cookies.Append("password", model.password);
                    }
                    var x = Request.Cookies["email"];
                    var y = Request.Cookies["password"];
                    var z = Request.Cookies["rememberMe"];

                    //ViewData["result"] = HttpContext.Session.Get(result.ToString());
                     HttpContext.Session.SetString("userName", result.name.ToString()); 
                     ViewData["userName"] = HttpContext.Session.GetString("userName");   
                     ViewBag.Result = "Ligin işlemi Başarılı"; 
                     return RedirectToAction("Details", "Home", new { id = result.userID });
                }
            }
            else
            {
                return View(model);
            }
        }
        /*
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> LogOut()
          {
              await _signInManager.SignOutAsync();
              _logger.LogInformation(4, "User logged out.");
              return RedirectToAction(nameof(HomeController.Index), "Home");
               foreach (var cookieKey in Request.Cookies.Keys)
                  {
                      Response.Cookies.Delete(cookieKey);
                  }
          }

          public IActionResult Logout()
          {
              HttpContext.Session.Remove("userId");
              return RedirectToAction("Index");
          }
          */

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        { 
            List<City> list = _cityRepo.List();
            ViewBag.ListOfCity = list; 
            return View();
             
        }

        public IActionResult getDistrict(int id)
        { 
            List<District> list = _districtRepo.List(x=>x.cityID==id); 
            return Json(list);
        }
        //INSERT
        [HttpPost]
        public IActionResult Register(User model)
        { 
            if (!ModelState.IsValid || model == null) return BadRequest();         
                
            List<User> allUserList = _userRepo.List();
            foreach (var u in allUserList)
            {
                if (u.email == model.email)
                {
                    ModelState.AddModelError("", "Kullanici mail adresi kayıtlı!");
                    return View(model);
                } 
            }

            if (_userRepo.Insert(model) > 0)
            {
                ViewBag.Result = "Kayıt işlemi Başarıyla Yapılmıştır.";
                HttpContext.Session.SetString("Username",model.name+ " " +model.surname);
                ViewData["userNameSurname"] = HttpContext.Session.GetString("Username"); 
                return RedirectToAction("Login", "Home", new { id = model.userID });
            }
            return BadRequest();
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = _userRepo.Find(x => id == id.Value);
            if (user == null)
            {
                return BadRequest();
            }
            //var result = from a in _cityRepo.ListQueryable()
            //             where a.cityID > 0
            //             select new { a.cityID, a.cityName };

            //List<City> list = result.AsEnumerable()
            //                          .Select(o => new City
            //                          {
            //                              cityName = o.cityName,
            //                              cityID = o.cityID
            //                          }).ToList();


            //var resultd = from a in _districtRepo.ListQueryable()
            //              select new { a.districtID, a.districtName };

            //List<District> listd = resultd.AsEnumerable()
            //                          .Select(o => new District
            //                          {
            //                              districtName = o.districtName,
            //                              districtID = o.districtID
            //                          }).ToList();

            List<City> listc= _cityRepo.List();
            List<District> listd = _districtRepo.List();
            ViewBag.ListOfCity = listc;
            ViewBag.ListOfDistrict = listd;  
            return View(user);
        }

        //Edit
        [HttpPost]
        public IActionResult Edit(int? id, User model)
        {
            if (!id.HasValue) {
                ModelState.AddModelError("", "Kullanici Bulunamadı!");
                return View(model);
            }
            if (!ModelState.IsValid || model == null) {
                ModelState.AddModelError("", "Hatalı işlem!");
                return View(model);
            }

            var oldUser = _userRepo.Find(x => x.userID == id.Value);
            if (oldUser == null) return NotFound();

            List<User> allUserList = _userRepo.List();
            foreach (var u in allUserList)
            {
                if (u.email == model.email)
                {
                    ModelState.AddModelError("", "Kullanici mail adresi kayıtlı!");
                    return View();
                }
            }


            model.userID = oldUser.userID;

            if (_userRepo.Update(model) > 0)
                return View(model);
            return BadRequest();
        }
        // DELETE  
        //[HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var user = _userRepo.Find(x => x.userID == id);
            if (user == null) return NotFound();

            if (_userRepo.Delete(user) > 0)
                return View();
            return BadRequest();
        }

        //Detay sayfası
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = _userRepo.Find(x =>x.userID == id.Value);
            if (user == null)
            {
                return BadRequest();
            }
            ViewData["userName"] = HttpContext.Session.GetString("userName");
            ViewBag.Result = "Ligin işlemi Başarılı";
            return View(user);
        }

        [HttpGet]
        public IActionResult ResreshPassword()
        {
            return View();          
        }
        [HttpPost]
        public IActionResult ResreshPassword(RefreshPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User result = _userRepo.Find(a => a.email == model.email);                
                if (result == null)
                {
                    ModelState.AddModelError("", "Kullanici Bulunamadı!");
                    return View();
                }else if(result.email == model.email)
                {
                    if(model.newpassword!=model.password)
                    {
                        ModelState.AddModelError("", "Şifreler Uyumsuz!");
                        return View();
                    }
                    result.email = model.email;
                    result.password = model.password;
                         
                    var uResult = _userRepo.Update(result);
                    if(uResult>0) 
                    return RedirectToAction("Login", "Home");
                    return View(model);
                }
                else
                { 
                    return RedirectToAction("Details", "Home", new { id = result.userID });
                }
            }
            else
            {
                return View(model);
            }
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
