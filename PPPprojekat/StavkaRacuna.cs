//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPPprojekat
{
    using System;
    using System.Collections.Generic;
    
    public partial class StavkaRacuna
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StavkaRacuna()
        {
            this.Racun = new HashSet<Racun>();
        }
    
        public int RbStavkeRacuna { get; set; }
        public Nullable<int> BarKodArtikla { get; set; }
        public Nullable<double> Kolicina { get; set; }
        public Nullable<double> Vrednost { get; set; }
    
        public virtual Proizvod Proizvod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racun { get; set; }
    }
}