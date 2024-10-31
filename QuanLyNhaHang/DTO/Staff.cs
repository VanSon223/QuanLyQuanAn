using Newtonsoft.Json;


namespace QuanLyNhaHang.DTO
{
    public class Staff
    {
        
        public Staff(int staffId, string userName, string fullName, string role, string password = null)
        {
            this.StaffID = staffId;
            this.Username = userName;
            this.FullName = fullName;
            this.Password = password;
            this.Role = role;
        }

        
        public Staff() { }

        [JsonProperty("staffId")]
        public int StaffID { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
