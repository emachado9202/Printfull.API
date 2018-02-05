using System;
using System.Text;

namespace Printful.API.Manager
{
    public class API
    {
        /// <summary>    
        /// Encode API to Base64 method.    
        /// </summary>    
        /// <param name="APIDecoded">API copied from account Printfull</param>    
        /// <returns>Returns - String API Encoded</returns>
        public static string Encode(string APIDecoded)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(APIDecoded));
        }
    }
}