using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLayer.Entities
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public double RoomPrice { get; set; }

        public virtual List <Room>? Room { get; set; }

    }
}
