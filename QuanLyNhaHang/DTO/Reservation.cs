using Newtonsoft.Json;
using System;

namespace QuanLyNhaHang.DTO
{
    public class Reservation
    {
        
        public Reservation(int reservationId, int customerId, int tableId, string status, DateTime? reservationTime )
        {
            ReservationId = reservationId;
            CustomerId = customerId;
            TableId = tableId;
            ReservationTime = reservationTime;
            Status = status;
        }

        public Reservation() { }

        [JsonProperty("reservationId")]
        public int ReservationId { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("tableId")]
        public int TableId { get; set; }

        [JsonProperty("reservationTime")]
        public DateTime? ReservationTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
