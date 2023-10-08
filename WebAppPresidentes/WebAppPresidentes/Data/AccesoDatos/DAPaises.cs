using Microsoft.EntityFrameworkCore;
using WebAppPresidentes.Data;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Data.AccesoDatos
{
    public class DAPaises
    {
        public IEnumerable<Paises> GetPaises()
        {
            var listado = new List<Paises>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Paises.ToList();
            }
            return listado;

        }
        public int InsertPais(Paises paises)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(paises);
                db.SaveChanges();
                resultado = paises.IdPais;
            }
            return resultado;
        }
        public Paises GetIdPais(int id)
        {
            var resultado = new Paises();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Paises.Where(item => item.IdPais == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdatePais(Paises paises)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Paises.Attach(paises);
                db.Entry(paises).State = EntityState.Modified;
                db.Entry(paises).Property(item => item.IdPais).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        //public Boolean UpdateUPresidente(Paises Paises)
        //{
        //    var resultado = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Paises.Attach(Paises);
        //        db.Entry(Paises).State = EntityState.Modified;
        //        db.Entry(Paises).Property(item => Paises.IdPresidente).IsModified = false;
        //        resultado = db.SaveChanges() != 0;
        //    }
        //    return resultado;
        //}

        public Boolean DeletePais(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Paises() { IdPais = id };
                db.Paises.Attach(entidad);//Referenciamos al registro que vamos a eliminar
                db.Paises.Remove(entidad);//Elimina el registro
                resultado = db.SaveChanges() != 0; //guardamos en la db
            }
            return resultado;
        }
    }
}
