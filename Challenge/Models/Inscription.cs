//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Challenge.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inscription
    {
        public Nullable<int> Id_User { get; set; }
        public Nullable<int> Id_Subject { get; set; }
        public Nullable<System.DateTime> Inscription_Date { get; set; }
        public int Id_Inscription { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
    }
}
