using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DTOs
{
    public class CategoriaDTO
    {
        public int Idcategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public static string CamposVacios(CategoriaDTO categoriaDTO)
        {
            string mensaje = "";

            if (string.IsNullOrWhiteSpace(categoriaDTO.Nombre))
            {
                mensaje += "El nombre de la categoria es obligatorio.<br>";
            }

            if (string.IsNullOrWhiteSpace(categoriaDTO.Descripcion))
            {
                mensaje += "La descripción de la categoria es obligatoria.<br>";
            }

            return mensaje;
        }


    }
}
