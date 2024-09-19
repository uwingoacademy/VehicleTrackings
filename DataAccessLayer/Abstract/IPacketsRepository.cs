using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPacketsRepository : IGenericRepostory<Packets>
    {
        IQueryable<Packets> GetPackets(int id, bool trackchanges);
    }
}
