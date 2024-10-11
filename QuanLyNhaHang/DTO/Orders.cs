using Newtonsoft.Json;
using System;

using System.Collections.Generic;
namespace QuanLyNhaHang.DTO
{
    public class Orders
    {
        public Orders(int orderID, int tableID, DateTime? orderTime, decimal? totalAmount, string status)
        {
            this.OrderID = orderID;
            this.TableID = tableID;
            this.OrderTime = orderTime;
            this.TotalAmount = totalAmount;
            this.Status = status;
        }

        public Orders() { }

        [JsonProperty("orderId")]
        public int OrderID { get; set; }

        [JsonProperty("tableId")]
        public int TableID { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerID { get; set; } // Change to nullable

        [JsonProperty("orderTime")]
        public DateTime? OrderTime { get; set; }

        [JsonProperty("totalAmount")]
        public decimal? TotalAmount { get; set; } // Change to nullable

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
