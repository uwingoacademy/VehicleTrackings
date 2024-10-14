using AutoMapper;
using DataAccessLayer.Manager;
using EntitiesLayer.Abstract;
using Microsoft.Extensions.Logging;
using ServicesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Contract
{
    public class CoundService : ICoundService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<CoundService> _logger;
        public CoundService(IRepositoryManager repository,ILogger<CoundService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<CoundDTO> GetCoundAsycn()
        {
            CoundDTO coundDTO = new CoundDTO();
            coundDTO.deviceCound =await _repository.Devices.GetCountAsync();
            coundDTO.paketsCound = await _repository.PacketsRepository.GetCountAsync();
            coundDTO.vehiclesCound = await _repository.VehiclesRepository.GetCountAsync();
            coundDTO.deviceVehiclesCound = await _repository.DevicesVehiclesRepository.GetCountAsync();
            return coundDTO;
        }
    }
}
