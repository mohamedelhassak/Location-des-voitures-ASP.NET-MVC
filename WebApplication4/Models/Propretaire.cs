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
    using System.ComponentModel.DataAnnotations;

    public partial class Propretaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Propretaire()
        {
            this.Voitures = new HashSet<Voiture>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "svp ce champ ne doit pas etre vide")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le Nom doit etre entre 3 et 20 caracteres")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "svp ce champ ne doit pas etre vide")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le Prenom doit etre entre 3 et 20 caracteres")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "svp ce champ ne doit pas etre vide")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([azA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Enter un valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "svp ce champ ne doit pas etre vide")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Le Tel doit etre entre 10 et 13 caracteres")]

        public string Tel { get; set; }

        public Nullable<int> PropetaireType { get; set; }
    
        public virtual PropretaireType PropretaireType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voiture> Voitures { get; set; }
    }
}
