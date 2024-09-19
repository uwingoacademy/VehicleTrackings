using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Contract
{
    public class Packets
    {
        [Key]
        public int PacketId { get; set; }
        public string PacketType { get; set; }
        public string Description { get; set; }

    }
}
