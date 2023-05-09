using ConsoleApp1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ChamadaAPI();
            
        }

        public static async void ChamadaAPI()
        {
            try
            {
                int id = int.Parse(Console.ReadLine());

                string url = "https://jsonplaceholder.typicode.com/posts";
                HttpClient client = new HttpClient();
                var response =  client.GetAsync(url).Result;
                string json = await response.Content.ReadAsStringAsync();

                List<MyModel> items = JsonConvert.DeserializeObject<List<MyModel>>(json);

                MyModel item = items.FirstOrDefault(x => x.Id == id);               
              

                if(item != null && item.Id == 3)
                {
                    await Console.Out.WriteLineAsync("achou");
                }
                else
                {
                    await Console.Out.WriteLineAsync("cu");
                }
            }
            catch (Exception ex)
            {
                
            }

            Console.ReadLine();
        }
    }
}
