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
    public class PeriodicMaintenanceService : IPeriodicMaintenanceService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodicMaintenanceService> _logger;

        public PeriodicMaintenanceService(IRepositoryManager repository, IMapper mapper, ILogger<PeriodicMaintenanceService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<PeriodicMaintenanceDTO>> GetAllPeriodicMaintenance()
        {
            try
            {
                var data = await _repository.PeriodicMaintenance.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<PeriodicMaintenanceDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<PeriodicMaintenanceDTO>();
            }

        }
        public async Task<PeriodicMaintenanceDTO> GetByIdPeriodicMaintenance(int id)
        {
            var device = _repository.PeriodicMaintenance.GetPeriodicMaintenance(id, false).SingleOrDefault();
            var deviceById = _mapper.Map<PeriodicMaintenanceDTO>(device);
            return deviceById;
        }
        public async Task<PeriodicMaintenanceDTO> CreatePeriodicMaintenance(PeriodicMaintenanceDTO devices)
        {
            try
            {
                var data = _mapper.Map<PeriodicMaintenance>(devices);
                await _repository.PeriodicMaintenance.GenericCreate(data);
                _repository.Save();
                return devices;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new PeriodicMaintenanceDTO();
            }
        }
        public void UpdatePeriodicMaintenance(PeriodicMaintenanceDTO devices)
        {
            try
            {
                var data = _mapper.Map<PeriodicMaintenance>(devices);
                if (data != null)
                {
                    var dataCheck = _repository.PeriodicMaintenance.GetPeriodicMaintenance(data.PeriodicMaintenanceId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.PeriodicMaintenance.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeletePeriodicMaintenance(int id)
        {
            try
            {
                var deleteData = _repository.PeriodicMaintenance.GetPeriodicMaintenance(id, false).SingleOrDefault();
                if (deleteData != null)
                {
                    _repository.PeriodicMaintenance.GenericDelete(deleteData);
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
