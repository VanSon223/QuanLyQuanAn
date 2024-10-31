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
                string url = "https://resmant1111-001-site1.jtempurl.com/staff/List";


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
        public async Task<bool> LoginAsync(string userName, string passWord)
        {
           
                string url = $"https://resmant1111-001-site1.jtempurl.com/staff/Login?username={userName}&password={passWord}";

                
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Gửi yêu cầu PUT tới API
                        HttpResponseMessage response = await client.PostAsync(url, null); // Không cần body, chỉ truyền query string

                        // Kiểm tra nếu yêu cầu thành công
                        return response.IsSuccessStatusCode;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception while updating staff status: {ex.Message}");
                        return false;
                    }
                }
        }
    }
}
