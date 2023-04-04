using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_Eventos.Models
{
    public class Usuario_Login
    {
        [Key]
        public int id_Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string nombre_Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string contrasena { get; set; }

    }
}