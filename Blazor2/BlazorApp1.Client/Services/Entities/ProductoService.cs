using BlazorApp1.Client.Services.Contracts;
using BlazorApp1.DTOs;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services.Entities
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductoDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<ProductoDTO>>($"api/Producto/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Editar(ProductoDTO productoDTO, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Producto/Editar/{id}", productoDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Producto/Eliminar/{id}");
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.EsCorrecto!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ProductoDTO>> Listar()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<ProductoDTO>>>("api/Producto/Listar");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Registrar(ProductoDTO productoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Producto/Registrar", productoDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
