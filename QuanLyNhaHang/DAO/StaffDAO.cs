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
        //public async Task<int?> GetStaffIDByCredentialsAsync(string username, string password)
        //{
        //    List<Staff> staffList = await GetAllStaffAsync();

        //    if (staffList != null)
        //    {
        //        // Tìm nhân viên có username và password trùng khớp
        //        Staff matchingStaff = staffList.FirstOrDefault(staff =>
        //            staff.Username == username && staff.Password == password);


        public async Task<Staff> LoginAsync(string userName, string passWord)
        {
            string url = $"https://resmant11111-001-site1.anytempurl.com/staff/Login?username={userName}&password={passWord}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Staff loggedInStaff = JsonConvert.DeserializeObject<Staff>(json);

                        if (loggedInStaff != null && loggedInStaff.StaffID > 0)
                        {
                            return loggedInStaff; // Trả về đối tượng nhân viên nếu có ID
                        }
                        else
                        {
                            Console.WriteLine("API không trả về StaffID hoặc thông tin không đầy đủ.");
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Đăng nhập thất bại: {response.StatusCode}");
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
