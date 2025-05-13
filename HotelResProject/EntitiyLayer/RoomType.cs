using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public string RoomPrice { get; set; }

        public virtual List <Room>? Room { get; set; }

    }
}
