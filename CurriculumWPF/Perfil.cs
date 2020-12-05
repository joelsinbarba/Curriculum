using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumWPF
{
    class Perfil
    {
        public static async Task<dynamic> ObtenerPerfil(string username)
        {
            using (var client = new HttpClient())
            {
                
                    client.BaseAddress = new Uri("https://api.github.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                HttpResponseMessage respuesta = await client.GetAsync($"users/{username}");
                    if (respuesta.IsSuccessStatusCode)
                    {
                    dynamic perfil = await respuesta.Content.ReadAsAsync<dynamic>();
                    
                        return perfil;
                }
                else
                {

                    return null;
                }
                
            }
        }
    }

}