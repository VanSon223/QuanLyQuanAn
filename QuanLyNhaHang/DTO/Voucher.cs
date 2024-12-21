using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Voucher
    {
        public Voucher() { }
        public Voucher(int voucherId, int voucherType, int voucherPoint)
        {
            VoucherId = voucherId;
            VoucherType = voucherType;
            VoucherPoint = voucherPoint;
            

        }
        [JsonProperty("voucherId")]
        public int VoucherId { get; set; }
        [JsonProperty("voucherType")]
        public int VoucherType { get; set; }
        [JsonProperty("voucherPoint")]
        public int VoucherPoint { get; set; }
       
    }
}
