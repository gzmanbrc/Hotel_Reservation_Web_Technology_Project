using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelResProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var roomTypes = _context.Roomtypes.ToList();
            return View(roomTypes);
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            var roomType = _context.Roomtypes
                .Include(rt => rt.Room)
                .FirstOrDefault(rt => rt.RoomTypeId == id);

            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpPost]
        public IActionResult Book(int roomTypeId, DateTime checkIn, DateTime checkOut)
        {
            if (checkIn >= checkOut)
            {
                ModelState.AddModelError("", "Check-out date must be after check-in date");
                return View();
            }

            var roomType = _context.Roomtypes.FirstOrDefault(rt => rt.RoomTypeId == roomTypeId);
            if (roomType == null)
            {
                return NotFound();
            }

            // RoomCount azalt
            if (roomType.RoomCount > 0)
            {
                roomType.RoomCount -= 1;
                _context.SaveChanges();
            }

            // Dummy bir Booking nesnesi ile confirmation view'ına yönlendiriyoruz:
            var booking = new Booking
            {
                RoomType = roomType,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                BookingDate = DateTime.Now,
                Status = "Confirmed"
            };
            return View("Confirmation", booking);
        }

        public IActionResult Confirmation(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.RoomType)
                .Include(b => b.Room)
                .Include(b => b.User)
                .FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // TEMP: Set all room counts to 100 (run once, then remove)
        public IActionResult SetAllRoomCountsTo100()
        {
            var allRoomTypes = _context.Roomtypes.ToList();
            foreach (var rt in allRoomTypes)
            {
                rt.RoomCount = 100;
            }
            _context.SaveChanges();
            return Content("All room counts set to 100!");
        }
    }
} 