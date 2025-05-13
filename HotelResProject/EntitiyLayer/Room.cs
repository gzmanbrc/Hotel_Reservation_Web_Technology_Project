using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [ForeignKey ("RoomType")]
        public string RoomTypeId { get; set; }

        public int RoomImage { get; set; }
        public string RoomDescription { get; set; }
        [ForeignKey("Hotel")]
        public string HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public RoomType? RoomType { get; set; }

        [ValidateNever]
        public virtual List<Booking> Bookings { get; set; }

    }
}
