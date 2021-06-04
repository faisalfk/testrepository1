using MVCTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCTestApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel()
            {
                UserId = string.Empty,
                UserPassword = string.Empty
            };

            return View(lvm);
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (Membership.ValidateUser(loginViewModel.UserId, loginViewModel.UserPassword))
            {
                return Redirect("/home");
            }
            return View(loginViewModel);
        }


        //[HttpPost]
        //public ActionResult Login(FormCollection formCollection)
        //{
        //    //string _userName = formCollection["UserId"].ToString();
        //    //string _userPassword = formCollection["UserPassword"].ToString();
        //    string _userName = Request.Form["UserId"].ToString();
        //    string _userPassword = Request.Form["UserPassword"].ToString();
        //    if (Membership.ValidateUser(_userName, _userPassword))
        //    {
        //        return Redirect("/home");

        //    }
        //    return View(new LoginViewModel() { UserId = _userName, UserPassword = _userPassword });
        //}


        [HttpPost]
        public ActionResult Register(LoginViewModel loginViewModel)
        {
            // if(Membership.ValidateUser(loginViewModel.UserId, loginViewModel.UserPassword))
            if (Membership.ValidateUser(loginViewModel.UserId, loginViewModel.UserPassword))
            {
                return Redirect("/home");
            }
            return View(loginViewModel);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOut(string id)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account", null);
        }

    }
}