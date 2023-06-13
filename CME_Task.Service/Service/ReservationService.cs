using AutoMapper;
using CME_Task.Common.CustomException;
using CME_Task.Common.DTO;
using CME_Task.Common.Resources;
using CME_Task.DAL.Models;
using CME_Task.DAL.UnitOfWork;
using CME_Task.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Service.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Save(ReservationDTO reservationDTO)
        {
            if (reservationDTO == null) { throw new BusinessException(ErrorMessages.InvalidInputData); }

            var mapped = _mapper.Map<Reservation>(reservationDTO);
            await _unitOfWork.Reservation.AddAsync(mapped);
        }
    }
}
