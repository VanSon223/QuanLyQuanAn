using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }
        public async Task<List<Staff>> GetAllStaffAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://resmant11111-001-site1.anytempurl.com/staff/List";


                HttpResponseMessage response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {

                    string json = await response.Content.ReadAsStringAsync();


                    List<Staff> staffList = JsonConvert.DeserializeObject<List<Staff>>(json);
                    return staffList;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Staff> LoginAsync(string userName, string passWord)
        {
            string url = $"https://resmant11111-001-site1.anytempurl.com/staff/Login?username={userName}&password={passWord}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu POST tới API
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    // Nếu đăng nhập thành công (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        // Giả sử API trả về thông tin Staff dưới dạng JSON
                        Staff loggedInStaff = JsonConvert.DeserializeObject<Staff>(json);
                        return loggedInStaff;
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception while logging in: {ex.Message}");
                    return null;
                }
            }
        }

    }
}
