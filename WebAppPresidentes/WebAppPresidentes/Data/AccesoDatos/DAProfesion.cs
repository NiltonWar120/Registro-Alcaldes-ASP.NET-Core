using Microsoft.EntityFrameworkCore;
using WebAppPresidentes.Models.Entidades;
using WebAppPresidentes.Data;

namespace WebAppPresidentes.Data.AccesoDatos
{
    public class DAProfesion
    {
        public IEnumerable<Profesion> GetProfesion()
        {
            var listado = new List<Profesion>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Profesiones.ToList();
            }
            return listado;

        }
        public int InsertProfesion(Profesion Profesion)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Profesion);
                db.SaveChanges();
                resultado = Profesion.IdProfesion;
            }
            return resultado;
        }
        public Profesion GetIdProfesion(int id)
        {
            var resultado = new Profesion();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Profesiones.Where(item => item.IdProfesion == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdateProfesion(Profesion Profesion)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Profesiones.Attach(Profesion);
                db.Entry(Profesion).State = EntityState.Modified;
                db.Entry(Profesion).Property(item => item.IdProfesion).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        //public Boolean UpdateUPresidente(Profesion Profesion)
        //{
        //    var resultado = false;
        //    using (var db = new ApplicationDbContext())
        //    {
        //        db.Profesion.Attach(Profesion);
        //        db.Entry(Profesion).State = EntityState.Modified;
        //        db.Entry(Profesion).Property(item => Profesion.IdPresidente).IsModified = false;
        //        resultado = db.SaveChanges() != 0;
        //    }
        //    return resultado;
        //}

        public Boolean DeleteProfesion(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Profesion() { IdProfesion = id };
                db.Profesiones.Attach(entidad);//Referenciamos al registro que vamos a eliminar
                db.Profesiones.Remove(entidad);//Elimina el registro
                resultado = db.SaveChanges() != 0; //guardamos en la db
            }
            return resultado;
        }
    }
}
