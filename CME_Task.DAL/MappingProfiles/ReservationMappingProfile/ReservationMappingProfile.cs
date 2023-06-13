using AutoMapper;
using CME_Task.Common.DTO;
using CME_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.DAL.MappingProfiles.ReservationMappingProfile
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
        }
    }
}
