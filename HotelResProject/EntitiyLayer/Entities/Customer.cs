﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLayer.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;    
        public string Address { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public int PostCode { get; set; }

        public string State { get; set; } = string.Empty; 
        public string PhoneNo { get; set; } = string.Empty;
        public string EmailPassword { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [ValidateNever]
        public virtual List<Booking>? Booking { get; set; }
        [ValidateNever]
        public virtual List<Payment>? Payments { get; set; }


    }
}
