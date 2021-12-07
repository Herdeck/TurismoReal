using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class CheckOut
    {


        [Required, Range(0, 10000)]
        public decimal IdCheckOut { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public decimal IdMulta{ get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public decimal IdDepto { get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]

        public decimal IdReserva { get; set; }

        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]

        public byte[] DocumentoEntrega{ get; set; }





        TurismoRealEntities db = new TurismoRealEntities();

        public List<CheckOut> ReadAll()
        {
            return this.db.CHECK_OUT.Select(i => new CheckOut()
            {
               IdCheckOut = i.ID_CHECKOUT,
               IdMulta    = (decimal)i.ID_MULTA,
               IdDepto    = i.ID_DEPTO,
               IdReserva  = i.ID_RESERVA,
               DocumentoEntrega = i.DOCUMENTO_ENTREGA



              
            }).ToList();
        }


        public bool Save()
        {
            try
            {
                db.SP_CREATE_CHECKOUT(this.IdCheckOut,this.IdMulta,this.IdDepto,this.IdReserva,this.DocumentoEntrega);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public CheckOut Find(int id)
        {
            return this.db.CHECK_OUT.Select(i => new CheckOut()

            {
               IdCheckOut = i.ID_CHECKOUT,
               IdMulta    = (decimal)i.ID_MULTA,
               IdDepto    = i.ID_DEPTO,
               IdReserva  = i.ID_RESERVA,
               DocumentoEntrega = i.DOCUMENTO_ENTREGA


            }).Where(i => i.IdCheckOut == id).FirstOrDefault();
        }


        public bool Update()
        {
            try
            {
                db.SP_UPDATE_CHECKOUT(this.IdCheckOut,this.IdMulta,this.IdDepto,this.IdReserva,this.DocumentoEntrega);
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
                db.SP_DELETE_CHECKOUT(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}