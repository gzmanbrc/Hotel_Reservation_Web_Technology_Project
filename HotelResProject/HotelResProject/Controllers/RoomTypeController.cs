using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var RoomTypeList = _context.Roomtypes
                .ToList();
            return View(RoomTypeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomType gelen)
        {
            if (ModelState.IsValid)
            {
                _context.Roomtypes.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gelen);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            RoomType? duzelt = _context.Roomtypes.FirstOrDefault(u => u.RoomTypeId == id);
            if (duzelt == null)
            {
                return NotFound();
            }
            return View(duzelt);
        }

        [HttpPost]
        public IActionResult Edit(RoomType gelen)
        {
            if (ModelState.IsValid && gelen.RoomTypeId > 0)
            {
                // RoomCount'ı elle güncellemiyoruz, Index'te zaten ayarlanıyor
                _context.Roomtypes.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gelen);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            RoomType? silinecek = _context.Roomtypes.FirstOrDefault(u => u.RoomTypeId == id);
            if (silinecek == null)
            {
                return NotFound();
            }
            return View(silinecek);
        }

        [HttpPost]
        public IActionResult Delete(RoomType gelen)
        {
            RoomType? silme = _context.Roomtypes.FirstOrDefault(u => u.RoomTypeId == gelen.RoomTypeId);
            if (silme != null)
            {
                _context.Roomtypes.Remove(silme);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

