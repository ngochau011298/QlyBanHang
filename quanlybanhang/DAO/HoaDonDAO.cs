using DAO.Interfaces;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO : Connection, IDal<HoaDonDTO>
    {
        public void Add(HoaDonDTO entity)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select * from HoaDon", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow r = dt.NewRow();
            r[0] = entity.Id;
            r[1] = entity.KHId;
            r[2] = entity.DateCreate;
            r[3] = entity.TotalPrice;
            dt.Rows.Add(r);
            SqlCommandBuilder cm = new SqlCommandBuilder(da);
            da.Update(dt);
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
