//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLigaSur.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Campeonato_Equipo
    {
        public int id_campeonato_equi { get; set; }
        public int id_campeonato { get; set; }
        public int id_Equipo { get; set; }
        public decimal inscripcion { get; set; }
        public decimal garantia { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
