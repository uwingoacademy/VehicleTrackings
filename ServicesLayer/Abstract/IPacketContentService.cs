using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IPacketContentService
    {
        PacketContentDTO GetByIdPacketContent(int id);
        Task<IEnumerable<PacketContentDTO>> GetAllPacketContect();
        Task<PacketContentDTO> CreatePacketContent(PacketContentDTO packetContent);
        void UpdatePacketContent(PacketContentDTO packetContent);
        void DeletePacketContent(int id);
    }
}
