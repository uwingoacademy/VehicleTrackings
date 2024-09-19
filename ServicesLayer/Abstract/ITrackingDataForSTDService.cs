using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface ITrackingDataForSTDService
    {
        TrackingDataForSTDDTO GetByIdTrackingDataForStd(int id);
        Task<IEnumerable<TrackingDataForSTDDTO>> GetAllTrackingDataForStd();
        Task<TrackingDataForSTDDTO> CreateTrackingDataForStd(TrackingDataForSTDDTO trackingDataForSTDDTO);
        void UpdateTrackingDataForStd(TrackingDataForSTDDTO trackingDataForSTDDTO);
        void DeleteTrackingDataForStd(int id);
    }
}
