using AutoMapper;
using gsiafa.Data;
using Microsoft.AspNetCore.Mvc;

namespace gsiafa.Controllers
{
    public class AccountController : Controller
    {
        private readonly gsiafaContext _db;
        private readonly IMapper _mapper;

        public AccountController(gsiafaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
