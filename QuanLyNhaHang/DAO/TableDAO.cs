using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private static readonly HttpClient client = new HttpClient();

        // Phương thức để lấy danh sách bàn từ API
        public async Task<List<Table>> GetTablesFromApiAsync()
        {
            string url = "https://resmant1111-001-site1.anytempurl.com/Table/List";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(jsonResponse);
                    return tables;
                }
                else
                {
                    Console.WriteLine("Lỗi khi lấy danh sách bàn.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        // Phương thức để cập nhật trạng thái bàn
        public async Task<bool> UpdateTableStatusAsync(int tableID, string status)
        {
            string url = $"https://resmant1111-001-site1.jtempurl.com/Table/UpdateStatus?tableID={tableID}&status={status}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu PUT tới API
                    HttpResponseMessage response = await client.PutAsync(url, null); // Không cần body, chỉ truyền query string

                    // Kiểm tra nếu yêu cầu thành công
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception while updating table status: {ex.Message}");
                    return false;
                }
            }
        }



        // Phương thức để lấy bàn theo ID
        public async Task<Table> GetTableByIDAsync(int tableID)
        {
            string url = $"https://resmant1111-001-site1.jtempurl.com/Table/GetById?id={tableID}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Table table = JsonConvert.DeserializeObject<Table>(jsonResponse);
                    return table;
                }
                else
                {
                    Console.WriteLine("Lỗi khi lấy bàn theo ID.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
    }
}
