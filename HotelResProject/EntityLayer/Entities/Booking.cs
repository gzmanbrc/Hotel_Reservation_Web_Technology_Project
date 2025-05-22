using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [Column("Adults")]
        public int Adults { get; set; }

        [Column("Children")]
        public int Children { get; set; }

        [Column("SpecialRequests")]
        [StringLength(500)]
        public string SpecialRequests { get; set; }

        // Navigation properties
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
} 