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
    public class DeviceVehiclesService : IDeviceVehiclesService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeviceVehiclesService> _logger;
        public DeviceVehiclesService(IRepositoryManager repository, IMapper mapper, ILogger<DeviceVehiclesService> logger)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DeviceVehiclesDTO>> GetAllDeviceVehicles()
        {
            try
            {
                var data = await _repository.DevicesVehiclesRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<DeviceVehiclesDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<DeviceVehiclesDTO>();
            }

        }
        public async Task<DeviceVehiclesDTO> GetByIdDeviceVehicle(int id)
        {
            var device = _repository.DevicesVehiclesRepository.GetDeviceVehicles(id, false);
            var dto = _mapper.Map<DeviceVehiclesDTO>(device);
            return dto;
        }
        public async Task<DeviceVehiclesDTO> CreateDeviceVehicles(DeviceVehiclesDTO deviceVehicles)
        {
            try
            {
               
                var data = _mapper.Map<DeviceVehicles>(deviceVehicles);
                if (data != null)
                {
                    var newDevice = _repository.Devices.GetDevices(deviceVehicles.DeviceId, false).SingleOrDefault();
                    newDevice.IsConnectedVehicles = true;
                    _repository.Devices.GenericUpdate(newDevice);
                    await _repository.DevicesVehiclesRepository.GenericCreate(data);
                    _repository.Save();
                }
                return deviceVehicles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new DeviceVehiclesDTO();
            }

        }
        public async void UpdateDeviceVehicles(DeviceVehiclesDTO deviceVehicles)
        {
            try
            {
                var data = _mapper.Map<DeviceVehicles>(deviceVehicles);
                if (data != null)
                {
                    var dataCheck = _repository.DevicesVehiclesRepository.GetDeviceVehicles(data.ConnectionId, false).SingleOrDefault();
                    if (dataCheck is not null && dataCheck.DeviceId != deviceVehicles.DeviceId) {
                        var updateDevice = _repository.Devices.GetDevices(dataCheck.DeviceId, false).SingleOrDefault();
                        updateDevice.IsConnectedVehicles = false;
                        _repository.Devices.GenericUpdate(updateDevice);
                       var newDevice = _repository.Devices.GetDevices(data.DeviceId,false).SingleOrDefault();
                        newDevice.IsConnectedVehicles=true;
                        _repository.Devices.GenericUpdate(newDevice);
                    }
                    if (dataCheck != null)
                    {
                        dataCheck.RemoveDate = DateTime.Now;
                        _repository.DevicesVehiclesRepository.GenericUpdate(dataCheck);
                        data.ConnectionId = 0;
                        data.InstallDate = DateTime.Now;
                       await _repository.DevicesVehiclesRepository.GenericCreate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeleteDeviceVehicles(int id)
        {
            try
            {
                var data = _repository.DevicesVehiclesRepository.GetDeviceVehicles(id, false).SingleOrDefault();
                if (data != null)
                {
                   var deleteDevice= _repository.Devices.GetDevices(data.DeviceId,false).SingleOrDefault();
                    deleteDevice.IsConnectedVehicles=false;
                    _repository.Devices.GenericUpdate(deleteDevice);
                    data.RemoveDate= DateTime.Now;
                    _repository.DevicesVehiclesRepository.GenericUpdate(data);
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
