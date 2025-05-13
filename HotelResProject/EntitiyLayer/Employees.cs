using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    public class Employees
    {

        public int StaffId { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Adress { get; set; } = string.Empty;

        public string Suburb { get; set; } = string.Empty;

        public string PostCode { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string PhoneNo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        [ForeignKey("Hotel")]

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }


    }
}
