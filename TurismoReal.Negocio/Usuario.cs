using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.DALC;

namespace TurismoReal.Negocio
{
    public class Usuario
    {
        [Required]
        public decimal id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string tipo_cuenta { get; set; }
        [Required]
        public string pNombre { get; set; }
        [Required]
        public string sNombre { get; set; }
        [Required]
        public string pApellido { get; set; }
        [Required]
        public string sApellido { get; set; }
        [Required]
        public decimal rut { get; set; }
        [Required]
        public string dVer { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]

        TurismoRealEntities db = new TurismoRealEntities();

        public List<Usuario> RealAll()
        {
            return this.db.USUARIOS.Select(p => new Usuario()
            {
                
                id = (decimal)p.ID_USER,
                email = p.EMAIL_USER,
                tipo_cuenta = p.TIPO_CTA,
                pNombre = p.P_NOM,
                sNombre = p.S_NOM,
                pApellido = p.P_APE,
                sApellido = p.S_APE,
                rut = (decimal)p.RUT,
                dVer = p.D_VER,
                cargo = p.CARGO

            }).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_USUARIOS(this.id, this.email,
                    this.tipo_cuenta, this.pNombre, sNombre, this.pApellido, this.sApellido,
                    this.rut, this.dVer, this.cargo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Usuario Find(int id)
        {
            return this.db.USUARIOS.Select(p => new Usuario()
            {

                id = (decimal)p.ID_USER,
                email = p.EMAIL_USER,
                tipo_cuenta = p.TIPO_CTA,
                pNombre = p.P_NOM,
                sNombre = p.S_NOM,
                pApellido = p.P_APE,
                sApellido = p.S_APE,
                rut = (decimal)p.RUT,
                dVer = p.D_VER,
                cargo = p.CARGO

            }).Where(p => p.id == id).FirstOrDefault();

        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_USUARIOS(this.id, this.email,
                    this.tipo_cuenta, this.pNombre, sNombre, this.pApellido, this.sApellido,
                    this.rut, this.dVer, this.cargo);
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
                db.SP_DELETE_USUARIO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Autenticar()
        {
            return db.USUARIOS
                 .Where(u => u.EMAIL_USER == this.email && u.RUT == this.rut)
                 .FirstOrDefault() != null;

        }
    }
}
