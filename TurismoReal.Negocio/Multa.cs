using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class Multa
    {

        public decimal IdMulta { get; set; }
        public string Detalle { get; set; }
        public decimal ValorMulta { get; set; }


        TurismoRealEntities db = new TurismoRealEntities();


        public List<Multa> ReadAll()
        {
            return this.db.MULTAS.Select(i => new Multa()
            {
                IdMulta = i.ID_MULTA,
                Detalle = i.DETALLE,
                ValorMulta = i.VALOR_MULTA

            }).ToList();


        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_MULTAS(this.IdMulta, this.Detalle, this.ValorMulta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Multa Find(int IdMulta)
        {
            return this.db.MULTAS.Select(p => new Multa()
            {



                IdMulta = p.ID_MULTA,
                Detalle = p.DETALLE,
                ValorMulta = p.VALOR_MULTA

            }).Where(p => p.IdMulta == IdMulta).FirstOrDefault();

        }
        public bool Update()
        {
            try
            {
                db.SP_UPDATE_MULTAS(this.IdMulta, this.Detalle, this.ValorMulta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          

        }
        public bool Delete(int IdMulta)
        {
            try
            {
                db.SP_DELETE_MULTAS(IdMulta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
