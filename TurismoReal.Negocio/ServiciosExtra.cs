using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;
using System.ComponentModel.DataAnnotations;

namespace TurismoReal.Negocio
{
    public class ServiciosExtra
    {
        [Required, Range(0, 10000)]
        public decimal IdServicio { get; set; }
        [Required, Range(0, 10000)]
        public decimal IdReserva { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string NombreServicio { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Descripcion { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<ServiciosExtra> ReadAll()
        {
            return this.db.SERVICIOS_EXTRA.Select(s => new ServiciosExtra()
            {
                IdServicio = s.ID_SERVICIO,
                IdReserva = s.ID_RESERVA,
                NombreServicio = s.NOMBRE_SERVICIO,
                Descripcion = s.DESCRIPCION
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_SERVICIOSEXTRA(this.IdServicio,this.IdReserva,this.NombreServicio,this.Descripcion);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public ServiciosExtra Find(int id)
        {
            return this.db.SERVICIOS_EXTRA.Select(s => new ServiciosExtra()
            {
                IdServicio = s.ID_SERVICIO,
                IdReserva = s.ID_RESERVA,
                NombreServicio = s.NOMBRE_SERVICIO,
                Descripcion = s.DESCRIPCION
            }).Where(s => s.IdServicio == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_CREATE_SERVICIOSEXTRA(this.IdServicio, this.IdReserva, this.NombreServicio, this.Descripcion);
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
                db.SP_DELETE_SERVICIOSEXTRA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
