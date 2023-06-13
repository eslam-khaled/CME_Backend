using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.DAL.Models
{
    public class Reservation : BaseModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of nights must be greater than 0.")]
        public int NumberOfNights { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
