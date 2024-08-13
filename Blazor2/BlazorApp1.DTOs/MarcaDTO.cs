using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DTOs
{
    public class MarcaDTO
    {
        public int Idmarca { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public static string CamposVacios(MarcaDTO marcaDTO)
        {
            string mensaje = "";

            if (string.IsNullOrWhiteSpace(marcaDTO.Nombre))
            {
                mensaje += "El nombre de la marca es obligatorio.<br>";
            }

            if (string.IsNullOrWhiteSpace(marcaDTO.Descripcion))
            {
                mensaje += "La descripción de la marca es obligatoria.<br>";
            }

            return mensaje;
        }

    }
}
