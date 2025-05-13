using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace EntityLayer.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        // Payment ile Customer arasında bir ilişki
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        // Payment ile Booking arasında bir ilişki
        [ForeignKey("Booking")]
        public int? BookingId { get; set; }
        public virtual Booking? Booking { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CreditCardNo { get; set; }
        public string ExpireDate { get; set; } = string.Empty;
    }
}
