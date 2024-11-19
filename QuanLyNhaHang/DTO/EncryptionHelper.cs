using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class EncryptionHelper
    {
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(password); // Chuyển đổi mật khẩu thành mảng byte
            return Convert.ToBase64String(bytes); // Mã hóa Base64
        }

        // Phương thức giải mã mật khẩu
        public static string DecryptPassword(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
                return string.Empty;

            var bytes = Convert.FromBase64String(encryptedPassword); // Giải mã Base64
            return Encoding.UTF8.GetString(bytes); // Chuyển mảng byte thành chuỗi văn bản
        }
    }
}
