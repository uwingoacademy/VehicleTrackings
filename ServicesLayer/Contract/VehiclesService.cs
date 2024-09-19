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
    public class VehiclesService : IVehiclesService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<VehiclesService> _logger;
        private readonly IMapper _mapper;

        public VehiclesService(IRepositoryManager repository, ILogger<VehiclesService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VehiclesDTO>> GetAllVehicles()
        {
            try
            {
                var data = await _repository.VehiclesRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<VehiclesDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<VehiclesDTO>();
            }

        }
        public VehiclesDTO GetByIdVehicle(int id)
        {
            try
            {
                var data = _repository.VehiclesRepository.GetVehicles(id, false).SingleOrDefault();
                var dto = _mapper.Map<VehiclesDTO>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new VehiclesDTO();
            }

        }
        public async Task<VehiclesDTO> CreateVehicles(VehiclesDTO vehicles)
        {
            try
            {
                var data = _mapper.Map<Vehicles>(vehicles);
                if (data != null)
                {
                    await _repository.VehiclesRepository.GenericCreate(data);
                    _repository.Save();
                }
                return vehicles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new VehiclesDTO();
            }

        }
        public void UpdateVehicles(VehiclesDTO vehicles)
        {
            try
            {
                var data = _mapper.Map<Vehicles>(vehicles);
                if (data != null)
                {
                    var dataCheck = _repository.VehiclesRepository.GetVehicles(vehicles.VehicleId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.VehiclesRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeleteVehicles(int id)
        {
            try
            {

                var data = _repository.VehiclesRepository.GetVehicles(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.VehiclesRepository.GenericDelete(data);
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
