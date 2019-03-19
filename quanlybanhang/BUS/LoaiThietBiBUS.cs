using DAO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiThietBiBUS
    {
        LoaiThietBiDAO a = new LoaiThietBiDAO();
        public DataTable GetAll()
        {
            return a.GetAll();
        }

        public LoaiThietBiDTO GetById(int id)
        {
            return a.GetById(id);
        }
    }
}
