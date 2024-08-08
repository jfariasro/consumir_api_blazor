using BlazorApp1.Client.Services.Contracts;
using BlazorApp1.DTOs;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.Entities
{
    public class MarcaService : IMarcaService
    {
        private readonly HttpClient _httpClient;

        public MarcaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MarcaDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<MarcaDTO>>($"api/Marca/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Editar(MarcaDTO marcaDTO, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Marca/Editar/{id}", marcaDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Marca/Eliminar/{id}");
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.EsCorrecto!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<MarcaDTO>> Listar()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<MarcaDTO>>>("api/Marca/Listar");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Registrar(MarcaDTO marcaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Marca/Registrar", marcaDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
