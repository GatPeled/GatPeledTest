using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TestGat.Module;

namespace TestGat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            ViewBag.Q = q;
            ViewBag.Root = GetItems(q);
            return View();
        }

        private RootOwner GetItems(string q)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "this is a test");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                       SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                //resolved web exception - https 
                var json = wc.DownloadString("https://api.github.com/search/repositories?q=" + q);
                var root = JsonConvert.DeserializeObject<RootOwner>(json);
                return root; 
            }
        }

        public void Bookmark(int id, string q)
        {
            var root = GetItems(q);
            var item = root.items.FirstOrDefault(x => x.id == id);
            Session["Bookmark." + id] = item;
        }        
    }
}