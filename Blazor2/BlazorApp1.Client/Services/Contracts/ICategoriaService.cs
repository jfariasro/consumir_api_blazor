using BlazorApp1.DTOs;

namespace BlazorApp1.Client.Services.Contracts
{
    public interface ICategoriaService
    {
        Task<int> Registrar(CategoriaDTO categoriaDTO);

        Task<int> Editar(CategoriaDTO categoriaDTO, int id);

        Task<bool> Eliminar(int id);

        Task<List<CategoriaDTO>> Listar();

        Task<CategoriaDTO> Buscar(int id);
    }
}
