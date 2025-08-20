using ClientsApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace PpsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PikListController : Controller
    {
        private PpsDBContext _context;  // DB

        public PikListController(PpsDBContext context)
        {
            _context = context;
        }
        // ClientDetails is a one to one relationship with Clients
        // Therefor a get all for client does not make sence in this case
        //***************************************************************
        [HttpGet]
        public IActionResult GetPikListValues()
        {
            var piklist = _context.piklist.ToList();

            return Ok(piklist);
        }
    }
}
