using BusinessManager.Models;
using BusinessManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [Route("setuser/{id}")]
        public IActionResult SetUser([FromRoute] int id)
        {
            userService.SetUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(userService.GetUser());
        }

        [HttpGet("clients")]
        public IActionResult Clients()
        {
            userService.GetAllCases();
            userService.GetAllUsers();
            userService.GetAllCaseAdmins();
            userService.GetAllBillables();
            return View(userService.GetClients());
        }

        [HttpGet("cases")]
        public IActionResult Cases()
        {
            userService.GetAllClients();
            userService.GetAllUsers();
            userService.GetAllCaseAdmins();
            userService.GetAllBillables();
            userService.GetAllEntries();
            return View(userService.GetCases());
        }

        [HttpPost("timerstart")]
        public IActionResult StartTimer([FromForm] int caseId, [FromForm] int userId, [FromForm] string narrative)
        {
            userService.StartTimer(caseId, userId, narrative);
            return RedirectToAction("Cases");
        }

        [HttpPost("timerstop")]
        public IActionResult StopTimer([FromForm] int caseId, [FromForm] int userId, string narrative)
        {
            userService.StopTimer(caseId, userId, narrative);
            return RedirectToAction("Cases");
        }

        [HttpGet("adduser")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("adduser")]
        public IActionResult UserAdded(string username, string password)
        {
            userService.AddUser(username, password);
            return RedirectToAction("Index");
        }

        [HttpGet("edituser")]
        public IActionResult EditUser()
        {
            return View();
        }
               
        [HttpGet("addclient")]
        public IActionResult AddClient()
        {
            return View(userService.GetAllUsers());
        }

        [HttpPost("addclient")]
        public IActionResult ClientAdded(string name, int clientAdminId)
        {
            userService.AddClient(name, clientAdminId);
            return RedirectToAction("Index");
        }

        [HttpGet("addcase")]
        public IActionResult AddCase()
        {
            return View(userService.GetAllClientsAndUsers());
        }

        [HttpPost("addcase")]
        public IActionResult CaseAdded(int clientId, string title, int caseAdminId)
        {
            userService.AddCase(clientId, title, caseAdminId);
            return RedirectToAction("Index");
        }

        [HttpGet("addfeeearner")]
        public IActionResult AddFeeEarner()
        {
            return View(userService.GetAllCaseAndUsers());
        }

        [HttpPost("addfeeearner")]
        public IActionResult FeeEarnerAdded(int caseId, int feeEarnerId, double rate)
        {
            userService.AddFeeEarner(caseId, feeEarnerId, rate);
            return RedirectToAction("Index");
        }

        [HttpGet("addevent")]
        public IActionResult AddEvent()
        {
            return View(userService.GetAllCases());
        }

        [HttpPost("addevent")]
        public IActionResult EventAdded(int caseId, string title, DateTime date)
        {
            userService.AddEvent(caseId, title, date);
            return RedirectToAction("Index");
        }

        [HttpGet("adddocument")]
        public IActionResult AddDocument()
        {
            return View(userService.GetAllCases());
        }

        [HttpPost("adddocument")]
        public IActionResult DocumentAdded(string title, string path, int caseId)
        {
            userService.AddDocument(title, path, caseId);
            return RedirectToAction("Index");
        }
    }
}
