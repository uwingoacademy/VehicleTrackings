using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITrackingDataForSTDRepository : IGenericRepostory<TrackingDataForSTD>
    {
        IQueryable<TrackingDataForSTD> GetTrackingStd(int id, bool trackchanges);
    }
}
