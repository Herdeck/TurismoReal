using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;
using System.ComponentModel.DataAnnotations;

namespace TurismoReal.Negocio
{
    public class PagoReserva
    {
        [Required, Range(0, 10000)]
        public decimal IdPago { get; set; }
        [Required, Range(0, 10000)]
        public decimal IdReserva { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }
        [Required, Range(1, 1000000)]
        public decimal Monto { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<PagoReserva> ReadAll()
        {
            return this.db.PAGO_RESERVA.Select(p => new PagoReserva() { 
                IdPago = p.ID_PAGO,
                IdReserva = p.ID_RESERVA,
                FechaPago = p.FECHA_PAGO,
                Monto = p.MONTO
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_PAGORESERVA(this.IdPago,this.IdReserva,this.FechaPago,this.Monto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public PagoReserva Find(int id)
        {
            return this.db.PAGO_RESERVA.Select(p => new PagoReserva()
            {
                IdPago = p.ID_PAGO,
                IdReserva = p.ID_RESERVA,
                FechaPago = p.FECHA_PAGO,
                Monto = p.MONTO
            }).Where(p => p.IdPago == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_PAGORESERVA(this.IdPago, this.IdReserva, this.FechaPago, this.Monto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.SP_DELETE_PAGORESERVA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
