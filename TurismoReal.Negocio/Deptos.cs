using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class Deptos
    {
        [Required, Range(0,10000)]
        public decimal Id { get; set; }
        [Required, Range(0,1)]
        public decimal Disponibilidad { get; set; }
        [Required, MinLength(3, ErrorMessage ="El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Estado { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Region { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Comuna { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Direccion { get; set; }
        [Required, Range(1,1000000)]
        public decimal PrecioDia { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Deptos> ReadAll()
        {
            return this.db.DEPTOS.Select(d => new Deptos() {
                Id = d.ID_DEPTO,
                Disponibilidad = d.DISPONIBILIDAD,
                Estado = d.ESTADO_DEPTO,
                Region = d.REGION,
                Comuna = d.COMUNA,
                Direccion = d.DIRECCION,
                PrecioDia = d.PRECIO_DIA,
            }).ToList();
        }


        public bool Save()
        {
            try
            {

                db.SP_CREATE_DEPTOS(this.Id, this.Disponibilidad, this.Estado, this.Region, this.Comuna, this.Direccion, this.PrecioDia);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public Deptos Find(int id)
        {
            return this.db.DEPTOS.Select(d => new Deptos()
            {
                Id = d.ID_DEPTO,
                Disponibilidad = d.DISPONIBILIDAD,
                Estado = d.ESTADO_DEPTO,
                Region = d.REGION,
                Comuna = d.COMUNA,
                Direccion = d.DIRECCION,
                PrecioDia = d.PRECIO_DIA,
            }).Where(d => d.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_DEPTOS(this.Id, this.Disponibilidad, this.Estado, this.Region, this.Comuna, this.Direccion, this.PrecioDia);
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
                db.SP_DELETE_DEPTOS(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}