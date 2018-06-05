//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Classique.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enregistrement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enregistrement()
        {
            this.Achat = new HashSet<Achat>();
            this.Composition_Disque = new HashSet<Composition_Disque>();
            this.Direction = new HashSet<Direction>();
            this.Interpreter = new HashSet<Interpreter>();
        }
    
        public int Code_Morceau { get; set; }
        public string Titre { get; set; }
        public int Code_Composition { get; set; }
        public string Nom_de_Fichier { get; set; }
        public string Duree { get; set; }
        public Nullable<int> Duree_Seconde { get; set; }
        public Nullable<decimal> Prix { get; set; }
        public byte[] Extrait { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Achat> Achat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Composition_Disque> Composition_Disque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direction> Direction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interpreter> Interpreter { get; set; }
    }
}
