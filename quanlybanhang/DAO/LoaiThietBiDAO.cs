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
    public class LoaiThietBiDAO : Connection, IDal<LoaiThietBiDTO>
    {
        public void Add(LoaiThietBiDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(LoaiThietBiDTO entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from LoaiThietBi", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public LoaiThietBiDTO GetById(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from LoaiThietBi where LTBId = '" + id + "'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    return new LoaiThietBiDTO()
                    {
                        Id = Convert.ToInt32(dr["LTBId"]),
                        TypeName = Convert.ToString(dr["LTBName"])
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
