using System;
using System.Net.Http;

namespace HttpClientNet
{
    public class HeadDetails
    {
        public async static void GetHeadRequest()
        {
            var url = "http://webcode.me";
            using var client = new HttpClient();

            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            Console.WriteLine("\n\n\n*****************Getting Request Headers*******************");
            Console.WriteLine("          (Use HttpClient Component For .net)            \n");
            Console.WriteLine(result);
        }
    }
}
