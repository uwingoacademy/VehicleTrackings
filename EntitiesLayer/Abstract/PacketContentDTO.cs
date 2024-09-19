using EntitiesLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public class PacketContentDTO
    {
        public int PacketContentId { get; set; }
        public int PacketId { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
    }
}
