using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DTOs
{
    public class ProductoDTO
    {
        public int Idproducto { get; set; }

        public int? Idmarca { get; set; }

        public int? Idcategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public virtual CategoriaDTO? Categoria { get; set; }

        public virtual MarcaDTO? Marca { get; set; }

        public static string CamposVacios(ProductoDTO productoDTO)
        {
            string mensaje = "";

            if (string.IsNullOrWhiteSpace(productoDTO.Nombre))
            {
                mensaje += "El nombre del producto es obligatorio.<br>";
            }

            if (string.IsNullOrWhiteSpace(productoDTO.Descripcion))
            {
                mensaje += "La descripción del producto es obligatoria.<br>";
            }

            if (productoDTO.Idmarca <= 0 || string.IsNullOrWhiteSpace(productoDTO.Idmarca.ToString()))
            {
                mensaje += "Debes seleccionar una marca.<br>";
            }

            if (productoDTO.Idcategoria <= 0 || string.IsNullOrWhiteSpace(productoDTO.Idcategoria.ToString()))
            {
                mensaje += "Debes seleccionar una categoria.<br>";
            }

            if (productoDTO.Cantidad <= 0 || string.IsNullOrWhiteSpace(productoDTO.Cantidad.ToString()))
            {
                mensaje += "La cantidad debe ser mayor a 0.<br>";
            }

            if (productoDTO.Precio <= 0 || string.IsNullOrWhiteSpace(productoDTO.Precio.ToString()))
            {
                mensaje += "El precio debe ser mayor a 0.<br>";
            }

            return mensaje;
        }
    }
}
