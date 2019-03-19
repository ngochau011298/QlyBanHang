using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class CTHDDTO
    {
        public int HDId { get; set; }
        public int TBId { get; set; }
        public int Qty { get; set; }
        public double Subtotal { get; set; }

        public CTHDDTO(int hdid, int tbid, int qty, double sub)
        {
            HDId = hdid;
            TBId = tbid;
            Qty = qty;
            Subtotal = sub;
        }
        public CTHDDTO() { }
    }
}
