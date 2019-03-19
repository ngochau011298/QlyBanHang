using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class ThietBiDTO
    {
        public int TBId { get; set; }
        public string TBName { get; set; }
        public int LTBId { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        public ThietBiDTO() { }

        public ThietBiDTO(int _TBId, string _TBName, int _LTBId, int _Price, int _Qty)
        {
            TBId = _TBId;
            TBName = _TBName;
            LTBId = _LTBId;
            Price = _Price;
            Qty = _Qty;
        }
    }
}
