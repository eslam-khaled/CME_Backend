using AutoMapper;
using CME_Task.Common.DTO;
using CME_Task.DAL.Models;

namespace CME_Task.DAL.MappingProfiles.RoomMappingProfile
{
    public class RoomMappingProfile:Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<RoomTypeDTO, RoomType>().ReverseMap();
        }
    }
}
