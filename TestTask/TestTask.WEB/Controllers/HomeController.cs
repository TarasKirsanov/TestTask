using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WEB.Interfaces;
using TestTask.WEB.Models;

namespace TestTask.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAllAsync());
        }

        public IActionResult OpenAddContact()
        {
            return PartialView("AddContact");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewContact(ContactModel contact)
        {
            await _contactService.CreateAsync(contact);
            return View("Index",await _contactService.GetAllAsync());
        }

        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _contactService.DeleteAsync(id);
            return View("Index",await _contactService.GetAllAsync());
        }

        public async Task<IActionResult> OpenUpdateContact(Guid id)
        {
            return PartialView("UpdateContact",await _contactService.GetAsync(id));
        }

         [HttpPost]
        public async Task<IActionResult> UpdateOldContact(ContactModel contact, Guid id)
        {
            await _contactService.UpdateAsync(contact);
            return View("Index",await _contactService.GetAllAsync());
        }
    }
}
