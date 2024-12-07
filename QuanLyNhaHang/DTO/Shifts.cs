using Newtonsoft.Json;
using System;


namespace QuanLyNhaHang.DTO
{
    public class Shifts
    {



        public Shifts(int shiftId, int staffId, DateTime startTime, DateTime endTime)
        {
            this.ShiftID = shiftId;
            this.StaffID = staffId;
            this.StartTime = startTime;
            this.EndTime = endTime;


        }


        public Shifts() { }

        [JsonProperty("shiftId")]
        public int ShiftID { get; set; }

        [JsonProperty("staffId")]
        public int StaffID { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

    }
}
