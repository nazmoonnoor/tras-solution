using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tras.Core;
using Tras.Core.Domain.Common;

namespace Tras.Data.Infrastructure
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        //http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                entity.Active = Active.Y;
                entity.Deleted = false;
                this.Entities.Add(entity);

                this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
                return null;
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                {
                    entity.Active = Active.Y;
                    entity.Deleted = false;
                    this.Entities.Add(entity);
                }

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("{0}{1}", "Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}", Environment.NewLine);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                entity.Active = Active.Y;
                entity.Deleted = false;
                _context.Entry(entity).State = EntityState.Modified;
                //_context.ObjectStateManager.Entry(entity).State = EntityState.Modified;
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                //this.Entities.Remove(entity);
                entity.Deleted = true;
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> objects = this.Entities.Where<T>(predicate).AsQueryable();
            foreach (T obj in objects)
                this.Entities.Remove(obj);
        }

        public virtual int Count
        {
            get { return this.Entities.Count(); }
        }

        public virtual bool Contains(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Count(predicate) > 0;
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).FirstOrDefault<T>();
        }

        public virtual T Find(params object[] keys)
        {
            return this.Entities.Find(keys);
        }

        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return this.Entities.Find(id);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
             return this.Entities.Where(predicate);
        }

        public IQueryable<T> Filter<TKey>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? this.Entities.Where(filter).AsQueryable() : this.Entities.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get { return this.Entities.AsNoTracking(); }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
