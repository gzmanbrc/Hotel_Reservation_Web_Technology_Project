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

        [Display(Name = "Room Name")]
        [Required(ErrorMessage = "You cannot leave the Room Name blank!!")]
        public string RoomName { get; set; }=string.Empty;

        [Display(Name = "Room Price")]
        [Required(ErrorMessage = "You cannot leave the Room Price blank!!")]
        [Range(0,200000)]
        public double? RoomPrice { get; set; }
        public virtual List <Room>? Room { get; set; }

        [Display(Name = "Room Count")]
        public int RoomCount { get; set; }

    }
}
