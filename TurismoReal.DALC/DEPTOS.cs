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
    
    public partial class DEPTOS
    {
        public DEPTOS()
        {
            this.CHECK_IN = new HashSet<CHECK_IN>();
            this.CHECK_OUT = new HashSet<CHECK_OUT>();
            this.ITEMS_DEPTO = new HashSet<ITEMS_DEPTO>();
            this.RESERVA = new HashSet<RESERVA>();
        }
    
        public long ID_DEPTO { get; set; }
        public short DISPONIBILIDAD { get; set; }
        public string ESTADO_DEPTO { get; set; }
        public string REGION { get; set; }
        public string COMUNA { get; set; }
        public string DIRECCION { get; set; }
        public long PRECIO_DIA { get; set; }
    
        public virtual ICollection<CHECK_IN> CHECK_IN { get; set; }
        public virtual ICollection<CHECK_OUT> CHECK_OUT { get; set; }
        public virtual ICollection<ITEMS_DEPTO> ITEMS_DEPTO { get; set; }
        public virtual FOTO_DEPTO FOTO_DEPTO { get; set; }
        public virtual ICollection<RESERVA> RESERVA { get; set; }
    }
}
