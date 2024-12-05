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
            string url = "https://resmant11111-001-site1.anytempurl.com/Order/List";

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
        public async Task<List<Orders>> GetListOrderByTableIDSAsync(int tableID)
        {
            // Cập nhật URL API để bao gồm tableID
            string url = $"https://resmant11111-001-site1.anytempurl.com/Order/GetById?tableID={tableID}";

            // Gửi yêu cầu GET tới API
            HttpResponseMessage response = await client.GetAsync(url);

            // Kiểm tra xem phản hồi có thành công không
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(jsonResponse);
                Console.WriteLine(orders.Count);
                return orders;
            }
            else
            {
                // Thông báo lỗi nếu yêu cầu không thành công
                Console.WriteLine("Lỗi khi lấy danh sách đơn hàng.");
                return null;
            }
        }

        public async Task<Orders> GetCurrentPendingOrderByTableID(int tableID)
        {
            
            OrdersDAO orderDAO = new OrdersDAO();
            List<Orders> listOrder = await orderDAO.GetListOrderByTableIDSAsync(tableID);
            Console.WriteLine(listOrder.Count);
            // Lọc đơn hàng theo TableID và trạng thái "pending"
            Orders order = listOrder.Find(o => o.TableID == tableID && o.Status == "Pending");
            //Console.WriteLine(order.OrderID);
            return order;
        }
        public async Task<bool> UpdateOrderStatusAsync(Orders o )
        {
            
            string url = $"https://resmant11111-001-site1.anytempurl.com/Order/Update"; 
            
            string jsonData = JsonConvert.SerializeObject(o);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsync(url, content);
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
