using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
namespace SHOPPER.Models
{
    public class MaHoa
    {
        public static string mahoa(string text)
        {
            string result = "";
            using (SHA256 s = SHA256.Create() ) {
                //Chuyển đổi mật khẩu thành mã các byte
                byte[] byteArr = Encoding.UTF8.GetBytes(text);
                //Băm và trả về mã các byte
                byte[] passEncode = s.ComputeHash(byteArr);
                result = BitConverter.ToString(passEncode);
            }
            return result;
        }
    }
}