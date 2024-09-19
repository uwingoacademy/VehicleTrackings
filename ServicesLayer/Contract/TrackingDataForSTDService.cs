using AutoMapper;
using DataAccessLayer.Manager;
using EntitiesLayer.Abstract;
using EntitiesLayer.Contract;
using Microsoft.Extensions.Logging;
using ServicesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Contract
{
    public class TrackingDataForSTDService : ITrackingDataForSTDService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<TrackingDataForSTDService> _logger;
        private readonly IMapper _mapper;

        public TrackingDataForSTDService(IRepositoryManager repository, ILogger<TrackingDataForSTDService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TrackingDataForSTDDTO>> GetAllTrackingDataForStd()
        {
            try
            {
                var data = await _repository.TrackingDataForSTDRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<TrackingDataForSTDDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<TrackingDataForSTDDTO>();
            }

        }
        public TrackingDataForSTDDTO GetByIdTrackingDataForStd(int id)
        {
            try
            {
                var data = _repository.TrackingDataForSTDRepository.GetTrackingStd(id, false).SingleOrDefault();
                var dto = _mapper.Map<TrackingDataForSTDDTO>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new TrackingDataForSTDDTO();
            }

        }
        public async Task<TrackingDataForSTDDTO> CreateTrackingDataForStd(TrackingDataForSTDDTO trackingDataForSTDDTO)
        {
            try
            {
                var data = _mapper.Map<TrackingDataForSTD>(trackingDataForSTDDTO);
                if (data != null)
                {
                    await _repository.TrackingDataForSTDRepository.GenericCreate(data);
                    _repository.Save();
                }
                return trackingDataForSTDDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new TrackingDataForSTDDTO();
            }

        }
        public void UpdateTrackingDataForStd(TrackingDataForSTDDTO trackingDataForSTDDTO)
        {
            try
            {
                var data = _mapper.Map<TrackingDataForSTD>(trackingDataForSTDDTO);
                if (data != null)
                {
                    var dataCheck = _repository.TrackingDataForSTDRepository.GetTrackingStd(trackingDataForSTDDTO.TrackingDataId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.TrackingDataForSTDRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeleteTrackingDataForStd(int id)
        {
            try
            {
                var data = _repository.TrackingDataForSTDRepository.GetTrackingStd(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.TrackingDataForSTDRepository.GenericDelete(data);
                    _repository.Save();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
    }
}
