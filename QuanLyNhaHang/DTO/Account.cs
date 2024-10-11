using Newtonsoft.Json;

namespace QuanLyNhaHang.DTO
{
    public class Account
    {
        public Account(string userName, string role, string password = null)
        {
            this.Username = userName;
            this.Role = role;
            this.Password = password;
        }

        public Account() { }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
