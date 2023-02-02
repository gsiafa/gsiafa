using gsiafa.StaticVariables;
using AutoMapper;
using gsiafa.Data;
using gsiafa.Models;
using gsiafa.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace gsiafa.Controllers
{
    public class ContactController : Controller
    {
        private readonly gsiafaContext _db;
        private readonly IMapper _mapper;
        public ContactController(gsiafaContext db, IMapper mapper)
        {
            _db= db;
            _mapper= mapper;
        }

        [HttpPost]     
        public async Task<IActionResult> ContactMe(ContactViewModel menu)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            //map
            var data = _mapper.Map<Contact>(menu);

            await _db.Contacts.AddAsync(data);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Your message was sent successfully!";
            return RedirectToAction("Index","Home");
        }
    }
}
