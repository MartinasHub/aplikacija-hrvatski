//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplikacija.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Seminar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seminar()
        {
            this.Predbiljezbas = new HashSet<Predbiljezba>();
        }

        public int IdSeminar { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public System.DateTime? Datum { get; set; }
        public bool Popunjen { get; set; }

        public int BrojPolaznika { get; set; }
        public string Predavac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predbiljezba> Predbiljezbas { get; set; }
    }
}
