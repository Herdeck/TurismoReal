using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class ItemsDepto
    {
        public decimal IdItem { get; set; }
        public decimal IdDepto { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        

        TurismoRealEntities db = new TurismoRealEntities();

        public List<ItemsDepto> ReadAll()
        {
            return this.db.ITEMS_DEPTO.Select(i => new ItemsDepto()
            {
                IdItem = i.ID_ITEM,
                IdDepto = i.ID_DEPTO,
                Descripcion = i.DESCRIPCION,
                Valor = i.VALOR
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_ITEMSDEPTO(this.IdItem,this.IdDepto,this.Descripcion,this.Valor);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public ItemsDepto Find(int id)
        {
            return this.db.ITEMS_DEPTO.Select(i => new ItemsDepto()
            {
                IdItem = i.ID_ITEM,
                IdDepto = i.ID_DEPTO,
                Descripcion = i.DESCRIPCION,
                Valor = i.VALOR

            }).Where(i => i.IdItem == id).FirstOrDefault();
        }


        public bool Update()
        {
            try
            {
                db.SP_UPDATE_ITEMSDEPTO(this.IdItem,this.IdDepto,this.Descripcion,this.Valor);
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
                db.SP_DELETE_ITEMSDEPTO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
