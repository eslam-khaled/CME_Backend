using CME_Task.Common.CustomException;
using CME_Task.Common.DTO;
using CME_Task.DAL.Models;
using CME_Task.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CME_TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ReservationDTO reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _reservationService.Save(reservation);
                    return Ok();
                }

                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }
            catch (ReservationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }

}
