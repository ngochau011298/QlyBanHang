using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
    public class GiaoHangDTO
    {
        public int Id { get; set; }
        public int HoaDonID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateDelivery { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryContact { get; set; }
        public string DeliveryAddress { get; set; }

        public GiaoHangDTO() {  }

        public GiaoHangDTO(int Id, int HoaDonID, int TotalPrice, DateTime DateDelivery, string CustomerName, string DeliveryContact, string DeliveryAddress)
        {
            this.Id = Id;
            this.HoaDonID = HoaDonID;
            this.TotalPrice = TotalPrice;
            this.DateDelivery = DateDelivery;
            this.CustomerName = CustomerName;
            this.DeliveryAddress = DeliveryAddress;
            this.DeliveryContact = DeliveryContact;
        }
    }
}
