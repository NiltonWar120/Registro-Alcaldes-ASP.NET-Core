using WebAppPresidentes.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WebAppPresidentes.Data.AccesoDatos
{
    public class DAPresidentes
    {
        public IEnumerable<Presidentes> GetPresidentes()
        {
            var LDetalle = new List<Presidentes>();
            using (var db = new ApplicationDbContext())
            {
                LDetalle = db.Presidentes.Include(item => item.Conyuge)
                     .Include(item => item.Paises).Include(item => item.Profesion).ToList();
            }
            return LDetalle;

        }
        public int InsertPresidente(Presidentes presidentes)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(presidentes);
                db.SaveChanges();
                resultado = presidentes.IdPresidente;
            }
            return resultado;
        }
        public Presidentes GetIdPresidentes(int id)
        {
            var resultado = new Presidentes();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Presidentes.Where(item => item.IdPresidente == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdatePresidente(Presidentes presidentes)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Presidentes.Attach(presidentes);//Referenciarnos a la fila
                db.Entry(presidentes).State = EntityState.Modified;
                //db.Entry(presidentes).Property(item => item.IdPresidente).IsModified = false;
                resultado = db.SaveChanges() != 0;

            }
            return resultado;
        }

        //public Boolean UpdateUPresidente(Presidentes presidentes)
        //{
        //    var resultado = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Presidentes.Attach(presidentes);
        //        db.Entry(presidentes).State = EntityState.Modified;
        //        db.Entry(presidentes).Property(item => presidentes.IdPresidente).IsModified = false;
        //        resultado = db.SaveChanges() != 0;
        //    }
        //    return resultado;
        //}

        public Boolean DeletePresidente(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Presidentes() { IdPresidente = id };
                db.Presidentes.Attach(entidad);//Referenciamos al registro que vamos a eliminar
                db.Presidentes.Remove(entidad);//Elimina el registro
                resultado = db.SaveChanges() != 0; //guardamos en la db
            }
            return resultado;
        }
    }
}
