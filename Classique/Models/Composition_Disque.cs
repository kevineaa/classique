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
    
    public partial class Composition_Disque
    {
        public int Code_Contenir { get; set; }
        public Nullable<int> Code_Disque { get; set; }
        public Nullable<int> Code_Morceau { get; set; }
        public Nullable<int> Position { get; set; }
    
        public virtual Disque Disque { get; set; }
        public virtual Enregistrement Enregistrement { get; set; }
    }
}
