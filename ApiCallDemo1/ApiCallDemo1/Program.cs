using ApiCallDemo1;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        //HttpClient client = new HttpClient();
        string postReqUrl = "https://www.komuna.dev/interview/api/broker-ftds"; 
        string getReqUrl = "https://www.komuna.dev/interview/api/broker-ftds";
        string apiKey = "1234";
        //StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //HttpResponseMessage response = await client.PostAsync(url, content);
        

        using (HttpClient client = new HttpClient())
        {
            // Add API key in headers
            client.DefaultRequestHeaders.Add("Authorization", apiKey); // Some APIs use "Authorization" instead
            HttpResponseMessage response = await client.GetAsync(getReqUrl);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                Lead user = JsonSerializer.Deserialize<Lead>(data, options);
                Console.WriteLine("data: " + data);
                //Console.WriteLine($"Response data: User ID: {user.Id} \n  Title: {user.Title} \n ");
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
       /*
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Data: " + data);
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }*/

    }
}
