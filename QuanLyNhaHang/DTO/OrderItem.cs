using Newtonsoft.Json;
using System;

namespace QuanLyNhaHang.DTO
{
    public class OrderItem
    {
        public OrderItem( int orderItemID, int orderID, int menuItemID, int quantity, string note)
        {
            this.OrderItemID = orderItemID;
            this.OrderID = orderID;
            this.MenuItemID = menuItemID;
            this.Quantity = quantity;
            this.Note = note;
        }

        public OrderItem() { }

       
        [JsonProperty("orderItemId")]
        public int OrderItemID { get; set; }
        [JsonProperty("orderId")]
        public int OrderID { get; set; }

        [JsonProperty("menuItemId")]
        public int MenuItemID { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("note")]
        public String Note { get; set; }
    }
}
