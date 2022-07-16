using Cadastro_Usuario.Models;
using Cadastro_Usuario.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Usuario.Services
{
    internal class DataServices
    {

        public async Task<List<Usuarios>> GetUsuariosAsync()
        {
            try
            {
                string url = "http://192.168.15.6:5000/api/Usuario";
                HttpClient client = new HttpClient();
                var data = await client.GetAsync(url);
                if (data.IsSuccessStatusCode)
                {
                    string content = await data.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Usuarios>>(content);
                }

                return new List<Usuarios>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task AddUsuarioAsync(UsuarioViewModel usuario)
        //{
        //    try
        //    {
        //        string url = "http://localhost:5000/api/Usuario";
        //        var data = JsonConvert.SerializeObject(usuario);
        //        var content = new StringContent(data, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = null;

        //        response = await client.PostAsync(url, content);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Erro ao incluir produto");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public async Task UpdateProdutoAsync(Usuario usuario)
        //{
        //    string url = "http://localhost:5000/api/Usuario/{0}";
        //    var uri = new Uri(string.Format(url, usuario.Id));
        //    var data = JsonConvert.SerializeObject(usuario);
        //    var content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = null;
        //    response = await client.PutAsync(uri, content);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Erro ao atualizar produto");
        //    }
        //}
        //public async Task DeletaProdutoAsync(Usuario usuario)
        //{
        //    string url = "http://localhost:5000/api/Usuario/{0}";
        //    var uri = new Uri(string.Format(url, usuario.Id));
        //    await client.DeleteAsync(uri);
        //}
    }
}
