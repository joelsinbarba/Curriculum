//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVGenerator.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pais
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pais()
        {
            this.Curricula = new HashSet<Curriculum>();
        }

        public int id { get; set; }
        public string descripcion { get; set; }
        public string codigo2 { get; set; }
        public string codigo3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Curriculum> Curricula { get; set; }

        public Pais(int id, string description)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

    }
}
