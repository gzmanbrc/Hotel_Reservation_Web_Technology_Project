using EntitiyLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public Dbset<RoomType>  Roomtypes { get; set; }
        public Dbset<Room> Rooms { get; set; }
        public Dbset<Hotel> Hotels { get; set; }
        public Dbset<Employees> Employees { get; set; }
        public Dbset<Booking> Bookings { get; set; }
        public Dbset<Customer> Customers { get; set; }
        public Dbset<Payment> Payment { get; set; }


    }
}
