using EntitiyLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;



namespace EntitiyLayer
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Booking")]
        public virtual Customer? Customer { get; set; }
       
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public int CreditCardNo { get; set; }
        public string ExpireDate { get; set; } = string.Empty;


        [ValidateNever]
        public virtual List<Booking>? Bookings { get; set; }

        [ValidateNever]
        public virtual List<Payment>? Payments { get; set; }


    }
}