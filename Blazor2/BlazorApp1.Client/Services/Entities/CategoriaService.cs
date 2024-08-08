using BlazorApp1.Client.Services.Contracts;
using BlazorApp1.DTOs;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.Entities
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CategoriaDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<CategoriaDTO>>($"api/Categoria/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Editar(CategoriaDTO categoriaDTO, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Categoria/Editar/{id}", categoriaDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Categoria/Eliminar/{id}");
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.EsCorrecto!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<CategoriaDTO>> Listar()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<CategoriaDTO>>>("api/Categoria/Listar");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Registrar(CategoriaDTO categoriaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Categoria/Registrar", categoriaDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
