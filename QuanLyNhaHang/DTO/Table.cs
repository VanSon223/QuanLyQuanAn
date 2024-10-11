using Newtonsoft.Json;

namespace QuanLyNhaHang.DTO
{
    public class Table
    {
        public Table() { }

        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }

        [JsonProperty("tableId")]
        public int ID { get; set; }

        [JsonProperty("tableNumber")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
