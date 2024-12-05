using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;
namespace QuanLyNhaHang.DAO
{
    public class MenuDAO
    {
        
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<MenuItem>> GetMenuListAsync()
        {
            string url = "https://resmant11111-001-site1.anytempurl.com/Menu/List";
            List<MenuItem> menuItems = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    menuItems = JsonConvert.DeserializeObject<List<MenuItem>>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return menuItems;
        }

    }
}
