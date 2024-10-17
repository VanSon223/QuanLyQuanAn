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
    public class OrderItemsDAO
    {
        
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<OrderItem>> GetListOrderItemByOrderIDAsync(int OrderID)
        {
            string url = "https://resmant1111-001-site1.jtempurl.com/OrderItem/List";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<OrderItem> listOrderItem = JsonConvert.DeserializeObject<List<OrderItem>>(jsonResponse);
                    List<OrderItem> list = listOrderItem.Where(o=>o.OrderID == OrderID).ToList();
                    return list;
                    
                }
                else
                {
                    Console.WriteLine("Lỗi: Không thể lấy dữ liệu từ API.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;

            }

        }
    }

}
