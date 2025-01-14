using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotelMauiApp.Services
{
    public class RestService<T> : IRestService<T>
    {
        HttpClient client;

        string RestUrl = "https://192.168.100.7.45455/api/{0}"; // ------------------ URL

        public RestService(string endpoint)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            client = new HttpClient(httpClientHandler);
            RestUrl = string.Format(RestUrl, endpoint);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> items = new List<T>();
            try
            {
                Uri uri = new Uri(RestUrl);
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
            }

            return items;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T item = default(T);
            try
            {
                Uri uri = new Uri($"{RestUrl}/{id}");
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
            }

            return item;
        }

        public async Task<bool> CreateAsync(T item)
        {
            try
            {
                Uri uri = new Uri(RestUrl);
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            try
            {
                Uri uri = new Uri($"{RestUrl}/{id}");
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uri, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Uri uri = new Uri($"{RestUrl}/{id}");
                HttpResponseMessage response = await client.DeleteAsync(uri);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                return false;
            }
        }
    }
}