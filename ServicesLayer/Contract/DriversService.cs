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
    public class DriversService : IDriversService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DriversService> _logger;
        public DriversService(IRepositoryManager repository, IMapper mapper, ILogger<DriversService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DriversDTO>> GetAllDrivers() 
        {
            try {
                var data = await _repository.DriversRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<DriversDTO>>(data);
                return dto;
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<DriversDTO>();
            }
             
        }
        public DriversDTO GetByIdDriver(int id) {
           var driver=  _repository.DriversRepository.GetDrivers(id,false).SingleOrDefault();
           var dto= _mapper.Map<DriversDTO>(driver);
            return dto;
        }
        public async Task<DriversDTO> CreateDrivers(DriversDTO drivers) 
        {
            try {
                var data = _mapper.Map<Drivers>(drivers);
                if (data != null)
                {
                    await _repository.DriversRepository.GenericCreate(data);
                    _repository.Save();
                }
                return drivers;
            } catch (Exception ex) {
               _logger.LogError(ex.ToString());
                return new DriversDTO();
            }
         
        }
        public void UpdateDrivers(DriversDTO drivers) 
        {
            try {
                var data = _mapper.Map<Drivers>(drivers);
                if (data != null)
                {
                    var dataCheck = _repository.DriversRepository.GetDrivers(data.DriverId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.DriversRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
             }
           

        }
        public void DeleteDrivers(int id) 
        {
            try {
                var data = _repository.DriversRepository.GetDrivers(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.DriversRepository.GenericDelete(data);
                    _repository.Save();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
             }
         
        }
    }
}
