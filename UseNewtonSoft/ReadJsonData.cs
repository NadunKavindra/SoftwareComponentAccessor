using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace UseNewtonSoft
{
    public class ReadJsonData
    {
        public async static void ReadUrlJsonData()
        {
            using var client = new HttpClient();

            var url = "http://webcode.me/users.json";

            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            Users? data = JsonConvert.DeserializeObject<Users>(json);

            if (data != null)
            {
                Console.WriteLine("\n\n\n***********************Read Json Data*************************");
                Console.WriteLine("  (Use NewtonSoft.Json Component For Deserialize Json Object)             \n");
                foreach (var user in data.users)
                {
                    Console.WriteLine(user);
                }
            }     

        }
    }
 
}
