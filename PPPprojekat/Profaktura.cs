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
    
    public partial class Profaktura
    {
        public int IDProfakture { get; set; }
        public Nullable<int> RbStavkeProfakture { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<System.TimeSpan> Vreme { get; set; }
        public Nullable<double> UkupnaVrednost { get; set; }
    
        public virtual StavkaProfakture StavkaProfakture { get; set; }
    }
}
