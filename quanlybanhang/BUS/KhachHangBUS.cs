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
    public class KhachHangBUS
    {
        KhachHangDAO a = new KhachHangDAO();
        public DataTable GetAll()
        {
            return a.GetAll();
        }
        public DataTable GetByContact(string contact)
        {
            return a.GetByContact(contact);
        }
    }
}
