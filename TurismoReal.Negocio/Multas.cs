using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;
using System.ComponentModel.DataAnnotations;

namespace TurismoReal.Negocio
{
    public class Multas
    {
        [Required, Range(0,10000)]
        public decimal Id { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe contener minimo {1} caracteres"), MaxLength(50)]
        public string Detalle { get; set; }
        [Required, Range(1,1000000)]
        public decimal ValorMulta { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Multas> ReadAll()
        {
            return this.db.MULTAS.Select(m => new Multas()
            {

                Id = m.ID_MULTA,
                Detalle = m.DETALLE,
                ValorMulta = m.VALOR_MULTA           
            
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_MULTAS(this.Id,this.Detalle,this.ValorMulta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Multas Find(int id)
        {
            return this.db.MULTAS.Select(m => new Multas()
            {

                Id = m.ID_MULTA,
                Detalle = m.DETALLE,
                ValorMulta = m.VALOR_MULTA

            }).Where(m => m.Id == id).FirstOrDefault();

        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_MULTAS(this.Id, this.Detalle, this.ValorMulta);
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
                db.SP_DELETE_MULTAS(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
