using Microsoft.EntityFrameworkCore;
using WebAppPresidentes.Models.Entidades;

namespace WebAppPresidentes.Data.AccesoDatos
{
    public class DAConyuge
    {
        public IEnumerable<Conyuge> GetConyuge()
        {
            var listado = new List<Conyuge>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Conyuge.ToList();
            }
            return listado;

        }
        public int InsertConyuge(Conyuge Conyuge)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Conyuge);
                db.SaveChanges();
                resultado = Conyuge.IdConyuge;
            }
            return resultado;
        }
        public Conyuge GetIdConyuge(int id)
        {
            var resultado = new Conyuge();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Conyuge.Where(item => item.IdConyuge == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdateConyuge(Conyuge Conyuge)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Conyuge.Attach(Conyuge);
                db.Entry(Conyuge).State = EntityState.Modified;
                db.Entry(Conyuge).Property(item => item.IdConyuge).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        //public Boolean UpdateUPresidente(Conyuge Conyuge)
        //{
        //    var resultado = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Conyuge.Attach(Conyuge);
        //        db.Entry(Conyuge).State = EntityState.Modified;
        //        db.Entry(Conyuge).Property(item => Conyuge.IdPresidente).IsModified = false;
        //        resultado = db.SaveChanges() != 0;
        //    }
        //    return resultado;
        //}

        public Boolean DeleteConyuge(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Conyuge() { IdConyuge = id };
                db.Conyuge.Attach(entidad);//Referenciamos al registro que vamos a eliminar
                db.Conyuge.Remove(entidad);//Elimina el registro
                resultado = db.SaveChanges() != 0; //guardamos en la db
            }
            return resultado;
        }
    }
}
