//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurismoReal.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class FOTO_DEPTO
    {
        public long ID_DEPTO { get; set; }
        public byte[] FOTO { get; set; }
    
        public virtual DEPTOS DEPTOS { get; set; }
    }
}
