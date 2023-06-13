using CME_Task.Common.CustomException;
using CME_Task.Common.DTO;
using CME_Task.Common.Resources;
using CME_Task.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CME_TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] SearchBaseDTO<RoomDTO> searchRoom)
        {
            var rooms = await _roomService.GetAll(searchRoom);

            return Ok(rooms);
        }


        [HttpPost]
        public async Task<IActionResult> Save(RoomDTO roomDTO)
        {
            await _roomService.AddRoom(roomDTO);
            return Ok();

        }
    }

}
