//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Eventos_Progra_V.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evento
    {
        public int id_Evento { get; set; }
        public string nombre_Evento { get; set; }
        public int id_Tipo_Evento { get; set; }
        public System.DateTime fecha_Evento { get; set; }
        public System.TimeSpan hora_Evento { get; set; }
        public int id_Lugar { get; set; }
    
        public virtual Lugar Lugar { get; set; }
        public virtual Tipo_Evento Tipo_Evento { get; set; }
    }
}