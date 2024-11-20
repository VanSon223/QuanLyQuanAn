using Newtonsoft.Json;
using System;

namespace QuanLyNhaHang.DTO
{
    public class Reservation
    {
        // Constructor sửa lại, đặt tham số 'status' trước 'reservationTime'
        public Reservation(  int tableId, DateTime? reservationTime = null)
        {
            //ReservationId = reservationId;
            //CustomerId = customerId;
            TableId = tableId;
            ReservationTime = reservationTime;
            //Status = status;
        }

        public Reservation() { }

        //[JsonProperty("reservationId")]
        //public int ReservationId { get; set; }

        //[JsonProperty("customerId")]
        //public int CustomerId { get; set; }

        [JsonProperty("tableId")]
        public int TableId { get; set; }

        [JsonProperty("reservationTime")]
        public DateTime? ReservationTime { get; set; }

        //[JsonProperty("status")]
        //public string Status { get; set; }
    }
}
