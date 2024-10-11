using System;
using Newtonsoft.Json;

namespace QuanLyNhaHang.DTO
{
    public class Customers

    {

        public Customers(int customerId, string username, string password, string fullName, string email, string phoneNumber, int point, DateTime? dateJoined = null)
        {
            CustomerId = customerId;
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Point = point;
            DateJoined = dateJoined ?? DateTime.Now;
        }
        public  Customers() { }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("dateJoined")]
        public DateTime? DateJoined { get; set; }
        [JsonProperty("point")]
        public int Point { get; set; }

        
    }
}
