using JsonPlaceholder.Managers.Contracts;
using JsonPlaceholder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonPlaceholder.Managers
{
    public class Requester : IRequester
    {
        private const string URL_REQUEST = "http://jsonplaceholder.typicode.com/";
        private const string ALBUMS = "albums";
        private const string USERS = "users";
        public Requester()
        {
        }
        
        public Album GetAlbum(int id)
        {
            string responseBody = string.Empty;
            var request = String.Concat(URL_REQUEST, ALBUMS, "/", id);
            responseBody = GetRequest(request).Result;
            var res = JsonConvert.DeserializeObject<Album>(responseBody);
            return res;
        }

        public List<Album> GetAlbums()
        {
            string responseBody = string.Empty;
            var request = String.Concat(URL_REQUEST, ALBUMS);
            responseBody = GetRequest(request).Result;
            var res = JsonConvert.DeserializeObject<List<Album>>(responseBody);
            return res;
        }

        public List<User> GetUser()
        {
            string responseBody = string.Empty;
            var request = String.Concat(URL_REQUEST, USERS);
            responseBody = GetRequest(request).Result;
            var res = JsonConvert.DeserializeObject<List<User>>(responseBody);
            return res;
        }

        public User GetUser(int userId)
        {
            string responseBody = string.Empty;
            var request = String.Concat(URL_REQUEST, USERS, "/", userId);
            responseBody = GetRequest(request).Result;
            var res = JsonConvert.DeserializeObject<User>(responseBody);
            return res;
        }

        public List<Album> GetUserAlbums(int userId)
        {
            string responseBody = string.Empty;
            var request = String.Concat(URL_REQUEST, ALBUMS, "?userId=", userId);
            responseBody = GetRequest(request).Result;
            var res = JsonConvert.DeserializeObject<List<Album>>(responseBody);
            return res;
        }

        private async Task<string> GetRequest(string request)
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(request);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            return responseBody;
        }
    }
}
