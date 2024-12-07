using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.DAO
{
    public class ShiftDAO
    {
        private static ShiftDAO instance;

        public static ShiftDAO Instance
        {
            get { return instance ?? (instance = new ShiftDAO()); }
        }

        private static readonly HttpClient client = new HttpClient();

        public async Task<bool> UpdateShiftAsync(int shiftID, DateTime endTime)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Đảm bảo rằng URL được tạo chính xác với tham số ShiftId và endTime
                    string url = $"https://resmant11111-001-site1.anytempurl.com/Shift/UpdateEndTime?ShiftId={shiftID}&endtime={endTime.ToString("yyyy-MM-ddTHH:mm:ss")}";

                    // Gửi yêu cầu PUT tới API
                    HttpResponseMessage response = await client.PutAsync(url, null); // Không cần body, chỉ truyền query string

                    // Kiểm tra nếu yêu cầu thành công
                    if (response.IsSuccessStatusCode)
                    {
                        return true; // Cập nhật thành công
                    }
                    else
                    {
                        // Nếu API trả về lỗi, hiển thị thông báo lỗi
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API trả về lỗi: {response.StatusCode}. Chi tiết lỗi: {errorResponse}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi trong quá trình gửi yêu cầu, thông báo lỗi
                MessageBox.Show($"Lỗi khi gọi API UpdateShift: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Trả về false nếu có lỗi
        }






        public async Task<Shifts> InsertShiftAsync(int staffID, DateTime startTime)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Tạo URL API với tham số
                    string url = $"https://resmant11111-001-site1.anytempurl.com/Shift/Insert?staffid={staffID}&starttime={startTime.ToString("yyyy-MM-ddTHH:mm:ss")}";
                    
                    // Gửi yêu cầu POST
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc phản hồi JSON
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Giả sử API trả về JSON như:
                        // {
                        //     "shiftId": 10,
                        //     "staffId": 1017,
                        //     "startTime": "2024-12-07T14:30:00",
                        //     "endTime": null,
                        //     "staff": null
                        // }

                        // Chuyển đổi phản hồi JSON thành đối tượng Shifts
                        Shifts shiftData = Newtonsoft.Json.JsonConvert.DeserializeObject<Shifts>(jsonResponse);

                        return shiftData; // Trả về đối tượng Shifts
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API trả về lỗi: {response.StatusCode}. Chi tiết lỗi: {errorResponse}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gọi API InsertShift: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // Trả về null nếu có lỗi
        }
    }
}
