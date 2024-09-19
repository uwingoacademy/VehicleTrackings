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
    public class TrackingDataForACCService : ITrackingDataForACCService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TrackingDataForACCService> _logger;

        public TrackingDataForACCService(IRepositoryManager repository, IMapper mapper, ILogger<TrackingDataForACCService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<TrackingDataForACCDTO>> GetAllTarckingDataAcc()
        {
            try
            {
                var data = await _repository.TrackingDataForAccRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<TrackingDataForACCDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<TrackingDataForACCDTO>();
            }

        }
        public TrackingDataForACCDTO GetByIdTrackingDataForAcc(int id)
        {
            try
            {
                var data = _repository.TrackingDataForAccRepository.GetTrackingAcc(id, false).SingleOrDefault();
                var dto = _mapper.Map<TrackingDataForACCDTO>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new TrackingDataForACCDTO();
            }

        }
        //site üzerinden veri gönderilmeyecek silinebilir test amaçlı
        public async Task<TrackingDataForACCDTO> CreateTrackingDataForAcc(TrackingDataForACCDTO trackingDataForACCDTO)
        {
            try
            {
                var data = _mapper.Map<TrackingDataForACC>(trackingDataForACCDTO);
                if (data != null)
                {
                    await _repository.TrackingDataForAccRepository.GenericCreate(data);
                    _repository.Save();
                }
                return trackingDataForACCDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new TrackingDataForACCDTO();
            }


        }
        public void UpdateTrackingDataForAcc(TrackingDataForACCDTO trackingDataForACCDTO)
        {
            try
            {
                var data = _mapper.Map<TrackingDataForACC>(trackingDataForACCDTO);
                if (data != null)
                {
                    var dataCheck = _repository.TrackingDataForAccRepository.GetTrackingAcc(trackingDataForACCDTO.AccelerometerDataId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.TrackingDataForAccRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeleteTrackingDataForAcc(int id)
        {
            try
            {
                var data = _repository.TrackingDataForAccRepository.GetTrackingAcc(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.TrackingDataForAccRepository.GenericDelete(data);
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
