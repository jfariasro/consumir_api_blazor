using BlazorApp1.DTOs;

namespace BlazorApp1.Client.Services.Contracts
{
    public interface IProductoService
    {
        Task<int> Registrar(ProductoDTO productoDTO);

        Task<int> Editar(ProductoDTO productoDTO, int id);

        Task<bool> Eliminar(int id);

        Task<List<ProductoDTO>> Listar();

        Task<ProductoDTO> Buscar(int id);
    }
}
