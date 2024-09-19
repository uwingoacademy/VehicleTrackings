using DataAccessLayer.Abstract;
using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class TrackingDataForSTDRepository : GenericRepository<TrackingDataForSTD>, ITrackingDataForSTDRepository
    {
        private readonly DataContext _context;
        public TrackingDataForSTDRepository(DataContext context) :base(context) => _context = context;
        public IQueryable<TrackingDataForSTD> GetTrackingStd(int id, bool trackchanges) => GenericReadExpression(x => x.TrackingDataId == id, trackchanges);

    }
}
