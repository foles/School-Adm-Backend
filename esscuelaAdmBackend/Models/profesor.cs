//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace esscuelaAdmBackend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class profesor
    {
        public profesor()
        {
            this.materia = new HashSet<materia>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<System.DateTime> fechanac { get; set; }
        public string correo { get; set; }
        public string foto { get; set; }
        public int idEscuela { get; set; }
    
        public virtual escuela escuela { get; set; }
        public virtual ICollection<materia> materia { get; set; }
    }
}
