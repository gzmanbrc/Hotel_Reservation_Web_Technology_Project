using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        // Booking ile Customer arasında bir ilişki
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        // Booking ile Room arasında bir ilişki
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Booking'in birden fazla Payment'i olabilir
        [ValidateNever]
        public virtual List<Payment>? Payments { get; set; }
    }
}
