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
    public class HoaDonBUS
    {
        HoaDonDAO hd = new HoaDonDAO();
        public void Add(HoaDonDTO entity)
        {

            hd.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(HoaDonDTO entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public HoaDonDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
