using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using si.ineor.app.Entities;
using si.ineor.app.Models.Users;

namespace si.ineor.app.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        string ClientUri = "https://192.168.0.40:7098";
        public AuthenticateResponse loggedUser;

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
#if DEBUG
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
#endif
            client = new HttpClient(httpClientHandler);

            
        }

        public string GetUri() {
            return ClientUri;
        }

        public async Task<AuthenticateResponse> Login(AuthenticateRequest request)
        {

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"{ClientUri}/Users/Authenticate", request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticateResponse>();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {result.Token}");
                    loggedUser = result;
                    return result;
                }
                else
                {
                    Console.WriteLine("");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;

            }

        }
        public async Task<IEnumerable<Movie>> GetMovies(string searchText = "")
        {

            try
            {
            HttpResponseMessage response;
            if (!string.IsNullOrEmpty(searchText))
            {
                response = await client.GetAsync($"{ClientUri}/api/Movies/SearchAllMovies?SearchText={searchText}");

            }
            else
            {
                response = await client.GetAsync($"{ClientUri}/api/Movies/SearchAllMovies");

            }

            if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Movie>>();
                }
                else
                {
                    Console.WriteLine("");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;

            }

        }
        public async Task<Movie> AddMovie(Movie movie)
        {

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"{ClientUri}/api/Movies/AddMovie", movie);


                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Movie>();
                }
                else
                {
                    Console.WriteLine("");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;

            }

        }
        public async Task<bool> DeleteMovie(Guid id)
        {

            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{ClientUri}/api/Movies/DeleteMovie/{id}");


                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return false;

            }

        }

    }
    

}

