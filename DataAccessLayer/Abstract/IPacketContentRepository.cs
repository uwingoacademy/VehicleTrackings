using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPacketContentRepository : IGenericRepostory<PacketContent>
    {
        IQueryable<PacketContent> GetPacketContent(int id, bool trackchanges);
    }
}
