using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Common.DTO
{
    public class ReservationDTO
    {

        public DateTime ReservationDate { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
