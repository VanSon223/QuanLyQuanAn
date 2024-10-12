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
    public class OrdersDAO
    {
        private static OrdersDAO instance;

        public static OrdersDAO Instance
        {
            get { if (instance == null) instance = new OrdersDAO(); return OrdersDAO.instance; }
            private set { OrdersDAO.instance = value; }
        }
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Orders>> GetListOrderByTableIDAsync()
        {
            string url = "https://resmant1111-001-site1.jtempurl.com/Order/List";

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(jsonResponse);

                return orders;
            }
            else
            {
                Console.WriteLine("Lỗi khi lấy danh sách đơn hàng.");
                return null;
            }
        }
    }
}
