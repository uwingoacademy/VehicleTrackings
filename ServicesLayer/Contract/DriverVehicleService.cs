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
using System.Transactions;

namespace ServicesLayer.Contract
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverVehicleService> _logger;

        public DriverVehicleService(IRepositoryManager repository, IMapper mapper, ILogger<DriverVehicleService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DriverVehicleDTO>> GetAllDriverVehicle() 
        {
            try {
                var data = await _repository.DriverVehicleRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<DriverVehicleDTO>>(data);
                return dto;
            }  catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<DriverVehicleDTO>();    
            }
           
        }
        public DriverVehicleDTO GetByIdDriverVehicle(int id) {
            try
            {
                var driver = _repository.DriverVehicleRepository.GetDriverVehicle(id, false);
                var dto = _mapper.Map<DriverVehicleDTO>(driver);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new DriverVehicleDTO();
            }
        }
        public async Task<DriverVehicleDTO> CreateDriverVehicle(DriverVehicleDTO driverVehicle) 
        {
            try {
                var data = _mapper.Map<DriverVehicle>(driverVehicle);
                if (data != null)
                {
                    var vehicles = _repository.VehiclesRepository.GetVehicles(data.VehicleId, false).SingleOrDefault();
                    vehicles.IsThereDriver = true;
                    _repository.VehiclesRepository.GenericUpdate(vehicles);
                    await _repository.DriverVehicleRepository.GenericCreate(data);
                    _repository.Save();
                }
                return driverVehicle;
            }  catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return new DriverVehicleDTO();
            }
          
        }
        public async void UpdateDriverVehicle(DriverVehicleDTO driverVehicle) 
        {
            try {
                //burdan gelen id li driver vehicle çek ardından vehicle birbirine eşit değilse araç değişmiştir dbden gelen idli aracın sürücü kısmını yok olara güncelle ardından bu gelen veriyi drivervehicle kısmını 0a çek ve create yap

                var data = _mapper.Map<DriverVehicle>(driverVehicle);
                if (data != null)
                {
                    var dataCheckt = _repository.DriverVehicleRepository.GetDriverVehicle(driverVehicle.DriverVehicleId, false).SingleOrDefault();
                    if (dataCheckt.VehicleId != driverVehicle.VehicleId) {
                        var vehicles = _repository.VehiclesRepository.GetVehicles(dataCheckt.VehicleId,false).SingleOrDefault();
                        vehicles.IsThereDriver = false;
                        _repository.VehiclesRepository.GenericUpdate(vehicles);
                        var newVehicles = _repository.VehiclesRepository.GetVehicles(data.VehicleId, false).SingleOrDefault();
                        newVehicles.IsThereDriver = true;
                        _repository.VehiclesRepository.GenericUpdate(newVehicles);
                    }
                    if (dataCheckt != null)
                    {
                        dataCheckt.TerminationDate = DateTime.Now;
                        _repository.DriverVehicleRepository.GenericUpdate(dataCheckt);
                        data.DriverVehicleId = 0;
                        data.IdentificationDate = DateTime.Now;
                        await _repository.DriverVehicleRepository.GenericCreate(data);
                      //  _repository.DriverVehicleRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
            }
             
       }
        public void DeleteDiverVehicle(int id) 
        {
            try {
                var data = _repository.DriverVehicleRepository.GetDriverVehicle(id, false).SingleOrDefault();
                if (data != null)
                {
                    var vehicles = _repository.VehiclesRepository.GetVehicles(data.VehicleId, false).SingleOrDefault();
                    vehicles.IsThereDriver = false;
                    _repository.VehiclesRepository.GenericUpdate(vehicles);
                    data.TerminationDate= DateTime.Now;
                    _repository.DriverVehicleRepository.GenericUpdate(data);
                   // _repository.DriverVehicleRepository.GenericDelete(data);
                    _repository.Save();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
