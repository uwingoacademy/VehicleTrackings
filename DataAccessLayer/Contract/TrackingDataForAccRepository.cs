using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class TrackingDataForAccRepository : GenericRepository<TrackingDataForACC>, ITrackingDataForAccRepository
    {
        private readonly DataContext _context;
        public TrackingDataForAccRepository(DataContext context) : base(context) => _context = context;
        public IQueryable<TrackingDataForACC> GetTrackingAcc(int id, bool trackchanges) => GenericReadExpression(x => x.AccelerometerDataId == id, trackchanges);

    }
}
