
using Newtonsoft.Json;
namespace QuanLyNhaHang.DTO
{
    public class VoucherWallet
    {
        public  VoucherWallet(){}
        public VoucherWallet(int voucherWalletId, int voucherId, int customerId, int quantity)
        {
            VoucherWalletId = voucherWalletId;
            VoucherId = voucherId;
            CustomerId = customerId;
            Quantity = quantity;
            
        }
        [JsonProperty("voucherWalletId")]
        public int VoucherWalletId { get; set; }
        [JsonProperty("voucherId")]
        public int VoucherId { get; set; }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        
    
        
    }
}
