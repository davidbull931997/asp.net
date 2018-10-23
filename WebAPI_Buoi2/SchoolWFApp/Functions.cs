using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SchoolWFApp
{
    public class Functions
    {
        private static string url = "http://localhost:49732/api/students";

        public async static Task<bool> Login(string username, string password)
        {
            try
            {
                string url_login = "http://localhost:49732/api/Account";
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    StringContent data = new StringContent(
                        JsonConvert.SerializeObject(new LoginVM() { Username = username, Password = password }),Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync(url_login, data))
                    {
                        return true;
                    }
                }

            }
            catch (Exception)
            {
            }
            return false;
        }

        //get list student
        public async static Task<List<Student>> GetStudents()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    string response = await client.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<List<Student>>(response);
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        //get student
        public async static Task<Student> GetStudent(int id)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    string response = await client.GetStringAsync($"{url}/{id}");
                    return JsonConvert.DeserializeObject<Student>(response);
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async static Task<bool> PostStudent(Student s)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    StringContent data = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync(url, data))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async static Task<bool> PutStudent(Student s)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    StringContent data = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                    using (var response = await client.PutAsync($"{url}/{s.Id}", data))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async static Task<bool> DeleteStudent(int id)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient(handler))
                {
                    using (var response = await client.DeleteAsync($"{url}/{id}"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

    }
}
