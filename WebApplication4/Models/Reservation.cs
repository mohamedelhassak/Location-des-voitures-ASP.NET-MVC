//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int Id { get; set; }
        public Nullable<int> client { get; set; }
        public Nullable<int> prop { get; set; }
        public Nullable<int> voiture { get; set; }
        public Nullable<System.DateTime> date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public Nullable<decimal> montant { get; set; }
    
        public virtual Client Client1 { get; set; }
        public virtual Propretaire Propretaire { get; set; }
        public virtual Voiture Voiture1 { get; set; }
    }
}
