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
    
    public partial class CHECK_IN
    {
        public long ID_CHECKIN { get; set; }
        public long ID_DEPTO { get; set; }
        public long ID_PAGO { get; set; }
        public long ID_SERVICIO { get; set; }
        public byte[] DOCUMENTO_ACEPTACIÓN { get; set; }
    
        public virtual DEPTOS DEPTOS { get; set; }
        public virtual PAGO_RESERVA PAGO_RESERVA { get; set; }
        public virtual SERVICIOS_EXTRA SERVICIOS_EXTRA { get; set; }
    }
}