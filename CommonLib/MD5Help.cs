using System.Security.Cryptography;
using System.Text;

namespace CommonLib
{
    public class MD5Help
    {
        public static string GenerateMD5(string text)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                byte[] newbuffer = mi.ComputeHash(buffer);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < newbuffer.Length; i++)
                {
                    stringBuilder.Append(newbuffer[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
