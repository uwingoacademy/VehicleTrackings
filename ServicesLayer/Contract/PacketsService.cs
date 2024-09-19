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
    public class PacketsService  : IPacketsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<PacketsService> _logger;
        private readonly IMapper _mapper;

        public PacketsService(IRepositoryManager repository, ILogger<PacketsService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PacketsDTO>> GetAllPackets()
        {
            try {
                var data = await _repository.PacketsRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<PacketsDTO>>(data);
                return dto;
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<PacketsDTO>();
            }    
           
        }
        public  PacketsDTO GetByIdPacket(int id) {
            try {
                var packet = _repository.PacketsRepository.GetPackets(id, false).SingleOrDefault();
                var dto = _mapper.Map<PacketsDTO>(packet);
                return dto;
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return new PacketsDTO();
            }
            
        }
        public async Task<PacketsDTO> CreatePackets(PacketsDTO packets)
        {
            try {
                var data = _mapper.Map<Packets>(packets);
                if (data != null)
                {
                    await _repository.PacketsRepository.GenericCreate(data);
                    _repository.Save();
                }
                return packets;
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return new PacketsDTO();
            }
           
        }
        public void UpdatePackets(PacketsDTO packets)
        {
            try {
                var data = _mapper.Map<Packets>(packets);
                if (data != null)
                {
                    var dataCheck = _repository.PacketsRepository.GetPackets(packets.PacketId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.PacketsRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            } catch (Exception ex) { 
               _logger.LogError(ex.ToString());              
            }
          
        }
        public void DeletePackets(int id)
        {
            try {
                var data = _repository.PacketsRepository.GetPackets(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.PacketsRepository.GenericDelete(data);
                    _repository.Save();
                }
            } catch (Exception ex) {
               _logger.LogError(ex.ToString());
             }
            
        }
    }
}
