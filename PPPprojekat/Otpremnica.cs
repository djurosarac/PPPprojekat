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
    
    public partial class Otpremnica
    {
        public int IDOtpremnice { get; set; }
        public Nullable<int> RbStavkeOtpremnice { get; set; }
        public Nullable<int> BarKodArtikla { get; set; }
        public Nullable<double> Kolicina { get; set; }
        public string Opis { get; set; }
    
        public virtual StavkaOtpremnice StavkaOtpremnice { get; set; }
    }
}
