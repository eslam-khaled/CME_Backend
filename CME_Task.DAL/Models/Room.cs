﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.DAL.Models
{
    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }
        public int NumberOfBeds { get; set; }
        public RoomType RoomType { get; set; }
    }

}
