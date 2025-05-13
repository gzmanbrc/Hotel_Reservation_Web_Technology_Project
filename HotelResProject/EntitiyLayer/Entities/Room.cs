using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLayer.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [ForeignKey ("RoomType")]
        public int RoomTypeId { get; set; }

        public string RoomImage { get; set; }
        public string RoomDescription { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public RoomType? RoomType { get; set; }

        [ValidateNever]
        public virtual List<Booking> Bookings { get; set; }

    }
}
