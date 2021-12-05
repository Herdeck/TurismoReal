using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class Reserva
    {
        [Required, Range(0,10000)]
        public decimal IdReserva { get; set; }
        [Required, Range(0, 10000)]
        public decimal IdUser { get; set; }
        [Required, Range(0, 10000)]
        public decimal IdDepto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yy}",ApplyFormatInEditMode =true)]
        public DateTime FechaReserva { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yy}", ApplyFormatInEditMode = true)]
        public DateTime FechaTermino { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Reserva> ReadAll()
        {
            return this.db.RESERVA.Select(r => new Reserva()
            {

                IdReserva = r.ID_RESERVA,
                IdUser = r.ID_USER,
                IdDepto = r.ID_DEPTO,
                FechaReserva = r.FECHA_RESERVA,
                FechaInicio = r.FECHA_INICIO,
                FechaTermino = r.FECHA_TERMINO

            }).ToList();
        }


        public bool Save()
        {
            try
            {
                db.SP_CREATE_RESERVA(this.IdReserva,this.IdUser,this.IdDepto,this.FechaReserva,this.FechaInicio,this.FechaTermino);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Reserva Find(int id)
        {
            return this.db.RESERVA.Select(r => new Reserva()
            {

                IdReserva = r.ID_RESERVA,
                IdUser = r.ID_USER,
                IdDepto = r.ID_DEPTO,
                FechaReserva = r.FECHA_RESERVA,
                FechaInicio = r.FECHA_INICIO,
                FechaTermino = r.FECHA_TERMINO

            }).Where(r => r.IdReserva == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_RESERVA(this.IdReserva, this.IdUser, this.IdDepto, this.FechaReserva, this.FechaInicio, this.FechaTermino);
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
                db.SP_DELETE_RESERVA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
