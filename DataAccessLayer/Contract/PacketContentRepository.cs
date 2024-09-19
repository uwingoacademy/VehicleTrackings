using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class PacketContentRepository :GenericRepository<PacketContent> , IPacketContentRepository
    {
        private readonly DataContext _context;
        public PacketContentRepository(DataContext context) : base(context) => _context = context;
        public IQueryable<PacketContent> GetPacketContent(int id, bool trackchanges) => GenericReadExpression(x => x.PacketContentId == id, trackchanges);

    }
}
