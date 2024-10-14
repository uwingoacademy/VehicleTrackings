using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface ICoundService
    {
        Task<CoundDTO> GetCoundAsycn();
    }
}
