
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
    
public partial class Direction
{

    public int Code_Direction { get; set; }

    public Nullable<int> Code_Musicien { get; set; }

    public Nullable<int> Code_Morceau { get; set; }

    public Nullable<int> Code_Orchestre { get; set; }



    public virtual Enregistrement Enregistrement { get; set; }

    public virtual Musicien Musicien { get; set; }

    public virtual Orchestres Orchestres { get; set; }

}

}
