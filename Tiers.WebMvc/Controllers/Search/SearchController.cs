using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Tiers.Service;
using Tiers.WebMvc.Models;

namespace Tiers.WebMvc.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel();

            // Get data from the Service layer
            model.Users = new UserService().GetAll().ToList();
            model.User = new UserService().Get(new Random().Next(5) + 1);

            // Get data from the WebApi layer
            model.Result = new UserWebApiClient().Get();

            return View(model);
        }
    }
}
