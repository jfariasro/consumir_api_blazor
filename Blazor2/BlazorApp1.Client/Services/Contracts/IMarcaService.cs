using BlazorApp1.DTOs;

namespace BlazorApp1.Client.Services.Contracts
{
    public interface IMarcaService
    {
        Task<int> Registrar(MarcaDTO marcaDTO);

        Task<int> Editar(MarcaDTO marcaDTO, int id);

        Task<bool> Eliminar(int id);

        Task<List<MarcaDTO>> Listar();

        Task<MarcaDTO> Buscar(int id);
    }
}
