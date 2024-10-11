using Newtonsoft.Json;
using System;

namespace QuanLyNhaHang.DTO
{
    public class Payment
    {
        public Payment() { }

        public Payment(int paymentId, int orderId, string paymentMethod, decimal amountPaid, DateTime paymentTime)
        {
            this.PaymentId = paymentId;
            this.OrderId = orderId;
            this.PaymentMethod = paymentMethod;
            this.AmountPaid = amountPaid;
            this.PaymentTime = paymentTime;
        }

        [JsonProperty("paymentId")]
        public int PaymentId { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("amountPaid")]
        public decimal AmountPaid { get; set; }

        [JsonProperty("paymentTime")]
        public DateTime PaymentTime { get; set; }
    }
}
