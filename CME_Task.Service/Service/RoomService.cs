using Abp.Linq.Expressions;
using AutoMapper;
using CME_Task.Common.CustomException;
using CME_Task.Common.DTO;
using CME_Task.Common.Resources;
using CME_Task.DAL.Models;
using CME_Task.DAL.UnitOfWork;
using CME_Task.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CME_Task.Service.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationDTO<RoomDTO>> GetAll(SearchBaseDTO<RoomDTO> searchModel)
        {
                if (searchModel == null)
                {
                    throw new BusinessException(ErrorMessages.InvalidInputData);
                }

                var predicate = GetAllRoomsQueryPredict(searchModel.Filter);


                var result = await _unitOfWork.Room.GetPages(searchModel.PageNumber, searchModel.PageSize, searchModel.SortColumn, searchModel.Sort,
                    predicate, include: x => x.Include(y => y.RoomType));

                if (result == null)
                {
                    throw new BusinessException(ErrorMessages.DataNotFound);
                }

                var mappedResult = _mapper.Map<IEnumerable<RoomDTO>>(result.Item2);

                return new PaginationDTO<RoomDTO>()
                {
                    Count = mappedResult.Count(),
                    PagesList = mappedResult
                };
        }

        public async Task AddRoom(RoomDTO roomDto)
        {

            if (roomDto == null)
            {
                throw new BusinessException(ErrorMessages.InvalidInputData);

            }

            var mapped = _mapper.Map<Room>(roomDto);

            await _unitOfWork.Room.AddAsync(mapped);

        }

        private Expression<Func<Room, bool>> GetAllRoomsQueryPredict(RoomDTO searchDto)
        {
            var predicateValue = PredicateBuilder.True<Room>();
            if (searchDto != null)
            {
                if (searchDto.RoomTypeId != 0)
                    predicateValue = predicateValue.And(c => c.RoomTypeId == searchDto.RoomTypeId);

                if (searchDto.PricePerNight != 0)
                    predicateValue = predicateValue.And(c => c.PricePerNight == searchDto.PricePerNight);

                if (searchDto.RoomNumber != 0)
                    predicateValue = predicateValue.And(c => c.RoomNumber == searchDto.RoomNumber);

                if (searchDto.NumberOfBeds != 0)
                    predicateValue = predicateValue.And(c => c.NumberOfBeds == searchDto.NumberOfBeds);

                return predicateValue;
            }
            return predicateValue;
        }
    }
}
