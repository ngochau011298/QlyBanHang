using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class KhachHangDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public KhachHangDTO(int id, string name, string contact, string address)
        {
            Id = id;
            Name = name;
            Contact = contact;
            Address = address;
        }

        public KhachHangDTO() { }
    }
}
