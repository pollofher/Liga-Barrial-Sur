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
    
    public partial class Arbitro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arbitro()
        {
            this.Partido_Arbitro = new HashSet<Partido_Arbitro>();
        }
    
        public int Id_arbitro { get; set; }
        public string ced_arbitro { get; set; }
        public string nom_arbitro { get; set; }
        public string apell_arbitro { get; set; }
        public string dir_arbitro { get; set; }
        public string Pais { get; set; }
        public string telf_arbitro { get; set; }
        public string correo_arbitro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partido_Arbitro> Partido_Arbitro { get; set; }
    }
}
