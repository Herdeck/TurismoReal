using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class FotoDepto
    {
        [Required,Range(0,10000)]
        public decimal Id { get; set; }
        [Required]
        public byte[] Foto { get; set; }

        TurismoRealEntities db = new TurismoRealEntities();

        public List<FotoDepto> ReadAll()
        {
            return this.db.FOTO_DEPTO.Select(f => new FotoDepto()
            {
                Id = f.ID_DEPTO,
                Foto = f.FOTO
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_FOTODEPTO(this.Id, this.Foto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public FotoDepto Find(int id)
        {
            return this.db.FOTO_DEPTO.Select(f => new FotoDepto()
            {
                Id = f.ID_DEPTO,
                Foto = f.FOTO
            }).Where(f => f.Id == id).FirstOrDefault();
        }


        public bool Update()
        {
            try
            {
                db.SP_CREATE_FOTODEPTO(this.Id, this.Foto);
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
                db.SP_DELETE_FOTODEPTO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
