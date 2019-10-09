using PatronRepositorio.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL
{
    public interface IRepository <T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Buscar(int d);
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
    }


    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto contexto;
        public RepositorioBase()
        {
            contexto = new Contexto();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (contexto.Set<T>().Add(entity) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;

            try
            {
                contexto.Entry(entity).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T entity = contexto.Set<T>().Find(id);
                contexto.Set<T>().Remove(entity);

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual T Buscar(int id)
        {
            T entity;

            try
            {
                entity = contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();

            try
            {
                Lista = contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        } 

    }
}
