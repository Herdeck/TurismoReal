using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class CheckIn
    {
        

        [Required, Range(0, 10000)]
        public decimal IdCheckIn { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public decimal IdDepto { get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public decimal IdPago { get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]

        public decimal IdServicio { get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]

        public byte[] DocumentoAceptacion { get; set; }





        TurismoRealEntities db = new TurismoRealEntities();

        public List<CheckIn> ReadAll()
        {
            return this.db.CHECK_IN.Select(i => new CheckIn()
            {
                IdCheckIn = i.ID_CHECKIN,
                IdDepto = i.ID_DEPTO,
                IdPago = i.ID_PAGO,
                IdServicio = i.ID_SERVICIO,
                DocumentoAceptacion = i.DOCUMENTO_ACEPTACIÓN
            }).ToList();
        }


        public bool Save()
        {
            try
            {
                db.SP_CREATE_CHECKIN(this.IdCheckIn, this.IdDepto, this.IdPago, this.IdServicio, this.DocumentoAceptacion);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public CheckIn Find(int id)
        {
            return this.db.CHECK_IN.Select(i => new CheckIn()
        
            {
                IdCheckIn = i.ID_CHECKIN,
                IdDepto = i.ID_DEPTO,
                IdPago = i.ID_PAGO,
                IdServicio = i.ID_SERVICIO,
                DocumentoAceptacion = i.DOCUMENTO_ACEPTACIÓN

            }).Where(i => i.IdCheckIn == id).FirstOrDefault();
        }


        public bool Update()
        {
            try
            {
                db.SP_UPDATE_CHECKIN(this.IdCheckIn, this.IdDepto, this.IdPago, this.IdServicio, this.DocumentoAceptacion);
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
                db.SP_DELETE_CHECKIN(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}