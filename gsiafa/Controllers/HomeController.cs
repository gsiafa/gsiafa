using gsiafa.StaticVariables;
using AutoMapper;
using gsiafa.Data;
using gsiafa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gsiafa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly gsiafaContext _db;
        private readonly IMapper _mapper;
       
        public HomeController(ILogger<HomeController> logger, gsiafaContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData[SD.Success] = "Your message was sent successfully!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel menu)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            //map
            var data = _mapper.Map<Contact>(menu);

            await _db.Contacts.AddAsync(data);
            await _db.SaveChangesAsync();
            TempData[SD.Success] = "Your message was sent successfully!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}