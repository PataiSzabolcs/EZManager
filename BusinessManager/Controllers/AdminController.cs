using BusinessManager.Models;
using BusinessManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(adminService.GetAllUsers());
        }

        [HttpGet("clients")]
        public IActionResult Clients()
        {
            adminService.GetAllCases();
            adminService.GetAllUsers();
            adminService.GetAllCaseAdmins();
            adminService.GetAllBillables();
            return View(adminService.GetAllClients());
        }

        [HttpGet("cases")]
        public IActionResult Cases()
        {
            adminService.GetAllClients();
            adminService.GetAllUsers();
            adminService.GetAllCaseAdmins();
            adminService.GetAllBillables();
            return View(adminService.GetAllCases());
        }

        [HttpGet("adduser")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("adduser")]
        public IActionResult UserAdded(string username, string password)
        {
            adminService.AddUser(username, password);
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
            return View(adminService.GetAllUsers());
        }

        [HttpPost("addclient")]
        public IActionResult ClientAdded(string name, int clientAdminId)
        {
            adminService.AddClient(name, clientAdminId);
            return RedirectToAction("Index");
        }

        [HttpGet("addcase")]
        public IActionResult AddCase()
        {
            return View(adminService.GetAllClientsAndUsers());
        }

        [HttpPost("addcase")]
        public IActionResult CaseAdded(int clientId, string title, int caseAdminId)
        {
            adminService.AddCase(clientId, title, caseAdminId);
            return RedirectToAction("Index");
        }

        [HttpGet("addfeeearner")]
        public IActionResult AddFeeEarner()
        {
            return View(adminService.GetAllCaseAndUsers());
        }

        [HttpPost("addfeeearner")]
        public IActionResult FeeEarnerAdded(int caseId, int feeEarnerId, double rate)
        {
            adminService.AddFeeEarner(caseId, feeEarnerId, rate);
            return RedirectToAction("Index");
        }

        [HttpGet("addevent")]
        public IActionResult AddEvent()
        {
            return View(adminService.GetAllCases());
        }

        [HttpPost("addevent")]
        public IActionResult EventAdded(int caseId, string title, DateTime date)
        {
            adminService.AddEvent(caseId, title, date);
            return RedirectToAction("Index");
        }

        [HttpGet("adddocument")]
        public IActionResult AddDocument()
        {
            return View(adminService.GetAllCases());
        }

        [HttpPost("adddocument")]
        public IActionResult DocumentAdded(string title, string path, int caseId)
        {
            adminService.AddDocument(title, path, caseId);
            return RedirectToAction("Index");
        }
    }
}
