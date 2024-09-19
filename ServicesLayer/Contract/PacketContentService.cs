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
    public class PacketContentService : IPacketContentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PacketContentService> _logger;

        public PacketContentService(IRepositoryManager repository, IMapper mapper, ILogger<PacketContentService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<PacketContentDTO>> GetAllPacketContect()
        {
            try
            {
                var data = await _repository.PacketContentRepository.GenericRead(false);
                var dto = _mapper.Map<IEnumerable<PacketContentDTO>>(data);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Enumerable.Empty<PacketContentDTO>();
            }

        }
        public PacketContentDTO GetByIdPacketContent(int id)
        {
            try
            {
                var packet = _repository.PacketContentRepository.GetPacketContent(id, false).SingleOrDefault();
                var dto = _mapper.Map<PacketContentDTO>(packet);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new PacketContentDTO();
            }

        }
        public async Task<PacketContentDTO> CreatePacketContent(PacketContentDTO packetContent)
        {
            try
            {
                var data = _mapper.Map<PacketContent>(packetContent);
                if (data != null)
                {
                    await _repository.PacketContentRepository.GenericCreate(data);
                    _repository.Save();
                }
                return packetContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new PacketContentDTO();
            }

        }
        public void UpdatePacketContent(PacketContentDTO packetContent)
        {
            try
            {
                var data = _mapper.Map<PacketContent>(packetContent);
                if (data != null)
                {
                    var dataCheck = _repository.PacketContentRepository.GetPacketContent(packetContent.PacketContentId, false).SingleOrDefault();
                    if (dataCheck != null)
                    {
                        _repository.PacketContentRepository.GenericUpdate(data);
                        _repository.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        public void DeletePacketContent(int id)
        {
            try
            {
                var data = _repository.PacketContentRepository.GetPacketContent(id, false).SingleOrDefault();
                if (data != null)
                {
                    _repository.PacketContentRepository.GenericDelete(data);
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
