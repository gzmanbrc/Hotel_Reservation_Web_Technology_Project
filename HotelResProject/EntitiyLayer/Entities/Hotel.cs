using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLayer.Entities
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set; } = string.Empty;
        public string HotelAddress { get; set; } = string.Empty;

        public string Suburl { get; set; } = string.Empty;
        public int PostCode { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public virtual List <Room>? Room { get; set; }
        public List<Employees>? Employees { get; set; }



    }
}
