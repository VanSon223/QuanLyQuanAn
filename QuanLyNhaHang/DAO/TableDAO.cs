using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public  class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        // Thay đổi phương thức này để lấy dữ liệu từ API
        private static readonly HttpClient client = new HttpClient();

        // Phương thức để lấy danh sách Table từ API
        public async Task<List<Table>> GetTablesFromApiAsync()
        {
            string url = "https://resmant1111-001-site1.jtempurl.com/Table/List";

            try
            {
                // Gửi yêu cầu GET tới API
                HttpResponseMessage response = await client.GetAsync(url);

                // Kiểm tra nếu yêu cầu thành công
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung phản hồi (dạng JSON)
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Chuyển đổi JSON thành danh sách Table
                    List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(jsonResponse);

                    return tables;
                }
                else
                {
                    Console.WriteLine("Lỗi: Không thể lấy dữ liệu từ API.");
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
