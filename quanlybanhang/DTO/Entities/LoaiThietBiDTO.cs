using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class LoaiThietBiDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public LoaiThietBiDTO() {  }

        public LoaiThietBiDTO(int Id, string TypeName)
        {
            this.Id = Id;
            this.TypeName = TypeName;
        }
    }
}
