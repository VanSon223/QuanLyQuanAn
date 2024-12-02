using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class ReservationDAO
    {
        private static ReservationDAO instance;
        public static ReservationDAO Instance
        {
            get { if (instance == null) instance = new ReservationDAO(); return ReservationDAO.instance; }
            private set { ReservationDAO.instance = value; }
        }

        private static readonly HttpClient client = new HttpClient();

        // Phương thức để lấy danh sách bàn từ API
        public async Task<List<Reservation>> GetReservationsFromApiAsync()
        {
            string url = "https://resmant1111-001-site1.anytempurl.com/Reservation/List"; // Thay URL API

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<Reservation> reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonResponse);
                        return reservations;
                    }
                    else
                    {
                        Console.WriteLine($"Lỗi khi gọi API: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

    }
}
