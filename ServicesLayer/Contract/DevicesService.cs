using AutoMapper;
using DataAccessLayer.Manager;
using EntitiesLayer.Abstract;
using EntitiesLayer.Contract;
using Microsoft.Extensions.Logging;
using ServicesLayer.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Contract
{
    public class DevicesService : IDevicesService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DevicesService> _logger;

        public DevicesService(IRepositoryManager repository, IMapper mapper, ILogger<DevicesService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DevicesDTO>> GetAllDevices() 
        {
            try {
                var data = await _repository.Devices.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<DevicesDTO>>(data);
                return dto;
            } catch (Exception ex){
                _logger.LogError(ex.ToString());
               return Enumerable.Empty<DevicesDTO>();
            }

        }
        public async Task<DevicesDTO> GetByIdDevice(int id) {
          var device=  _repository.Devices.GetDevices(id,false).SingleOrDefault();
           var deviceById = _mapper.Map<DevicesDTO>(device);
            return deviceById;
        }
        public async Task<DevicesDTO> CreateDevices(DevicesDTO devices) 
        {
            try {
                var data = _mapper.Map<Devices>(devices);
                await _repository.Devices.GenericCreate(data);
                _repository.Save();
                return devices;
            } catch (Exception ex) {
               _logger.LogError(ex.ToString());
                return new DevicesDTO();
            }
        }
        public void UpdateDevices(DevicesDTO devices) 
        {
            try {
                var data = _mapper.Map<Devices>(devices);
                if (data != null)
                {
                  var dataCheck=  _repository.Devices.GetDevices(data.DeviceId,false).SingleOrDefault();
                    if (dataCheck != null) 
                    {
                        _repository.Devices.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
            }
         
        }
        public void DeleteDevices(int id)
        {
            try {
                var deleteData = _repository.Devices.GetDevices(id, false).SingleOrDefault();
                if (deleteData != null)
                {
                    _repository.Devices.GenericDelete(deleteData);
                    _repository.Save();

                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
