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
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime BookingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int? UserId { get; set; }

        public int? CustomerId { get; set; }

        // Navigation properties
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ValidateNever]
        public virtual List<Payment> Payments { get; set; }
    }
}
