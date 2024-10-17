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
        public async Task<Orders> GetCurrentPendingOrderByTableID(int tableID)
        {
            
            OrdersDAO orderDAO = new OrdersDAO();
            List<Orders> listOrder = await orderDAO.GetListOrderByTableIDAsync();

            // Lọc đơn hàng theo TableID và trạng thái "pending"
            return listOrder.FirstOrDefault(o => o.TableID == tableID && o.Status == "Pending");
        }
        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            string url = $"https://resmant1111-001-site1.jtempurl.com/Order/Update"; 
            var orderData = new { orderId = orderId, status = status }; 
            string jsonData = JsonConvert.SerializeObject(orderData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    return response.IsSuccessStatusCode; // Trả về true nếu thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception while updating order status: {ex.Message}");
                    return false; // Trả về false nếu có lỗi
                }
            }
        }

    }
}
