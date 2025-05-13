using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelResProject.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var RoomTypeList =_context.Roomtypes.ToList();
            return View(RoomTypeList);
        }
    }
}
