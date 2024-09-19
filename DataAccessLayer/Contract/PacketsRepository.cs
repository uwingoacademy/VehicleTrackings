using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class PacketsRepository : GenericRepository<Packets>, IPacketsRepository
    {
        private readonly DataContext _context;
        public PacketsRepository(DataContext context) : base(context) => _context = context;
        public IQueryable<Packets> GetPackets(int id, bool trackchanges) => GenericReadExpression(x => x.PacketId == id, trackchanges);

    }
}
