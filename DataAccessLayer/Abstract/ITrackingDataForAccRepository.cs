using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITrackingDataForAccRepository:IGenericRepostory<TrackingDataForACC>
    {
        IQueryable<TrackingDataForACC> GetTrackingAcc(int id, bool trackchanges);
    }
}
