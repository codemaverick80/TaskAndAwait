using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskAndAwait.Shared;

namespace TaskAndAwait.Library
{
    public class PersonRepository
    {
        public async Task<List<Person>> Get()
        {

            await Task.Delay(4000);
            using (var client=new HttpClient())
            {
                InitializeClient(client);
                HttpResponseMessage response =await client.GetAsync("api/people");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Person>>();
                }
                return new List<Person>();
            }

        }
        public async Task<Person> Get(int id)
        {
            using (var client=new HttpClient())
            {
                InitializeClient(client);
                HttpResponseMessage response = await client.GetAsync("api/people/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Person>();
                }
                return null;
            }

        }
        private static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:53322/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
      
    }


    
}
