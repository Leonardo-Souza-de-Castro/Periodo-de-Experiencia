using Cadastro_Usuario.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Usuario.Services
{
    internal class UsuariosAPI
    {
        const string URL = "http://192.168.15.6:5000/api/Usuario";

        private HttpClient GetClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<List<Usuarios>> GetUsers()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) //codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuarios>>(content);
            }
            return new List<Usuarios>();
        }

        public async Task<Usuarios> GetUser(Guid Id)
        {
            string dados = URL + "/" + Id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            if (response.IsSuccessStatusCode) //codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuarios>(content);
                return usuario;
            }
            return new Usuarios();
        }

        public async Task CreateUser(Usuarios Usuario_Novo)
        {
            string dados = URL;
            string json = JsonConvert.SerializeObject(Usuario_Novo);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);
        }

        public async Task UpDateUser(Usuarios Usuario_Atualizado)
        {
            string dados = URL + "/" + Usuario_Atualizado.Id;
            string json = JsonConvert.SerializeObject(Usuario_Atualizado);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }

        public async Task DeleteUser(Guid Id)
        {
            string dados = URL + "/" + Id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}
