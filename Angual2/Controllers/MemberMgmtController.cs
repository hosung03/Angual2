using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angual2.Models;
using Microsoft.AspNetCore.Mvc;


namespace Angual2.Controllers
{
    [Route("api/[controller]")]
    public class MemberMgmtController : Controller
    {
        public IActionResult Index()
        {
            var repo = new MemberRepository();
            return View(repo.GetList());
        }

        [HttpGet("[action]")]
        public JsonResult GetList()
        {
            var repo = new MemberRepository();
            return Json(repo.GetList());
        }

        [HttpPost("[action]")]
        public IActionResult Add(String MemberName)
        {
            var repo = new MemberRepository();
            repo.Add(MemberName);
            return RedirectToAction("Index");
        }

        [HttpPost("[action]")]
        public JsonResult AddMember([FromBody] MemberInfo memberinfo)
        {
            var repo = new MemberRepository();
            repo.Add(memberinfo.MemberName);
            return Json(repo.GetList());
        }
    }

    public class MemberInfo
    {
        public string MemberName { get; set; }
    }

}
