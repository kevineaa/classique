
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
    
public partial class Instrument
{

    public Instrument()
    {

        this.Instrumentation = new HashSet<Instrumentation>();

        this.Interpréter = new HashSet<Interpréter>();

        this.Musicien = new HashSet<Musicien>();

    }


    public int Code_Instrument { get; set; }

    public string Nom_Instrument { get; set; }

    public byte[] Image { get; set; }



    public virtual ICollection<Instrumentation> Instrumentation { get; set; }

    public virtual ICollection<Interpréter> Interpréter { get; set; }

    public virtual ICollection<Musicien> Musicien { get; set; }

}

}
