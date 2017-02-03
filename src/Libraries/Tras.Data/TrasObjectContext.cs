using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Tras.Core;
using Tras.Core.Domain.Configuration;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.Ration;
using Tras.Core.Domain.Residence;
using Tras.Core.Domain.Distribution;
using Tras.Core.Domain.Store;
using Tras.Core.Domain.UserAuth;
using Tras.Data.Infrastructure;
using Tras.Data.Mapping.Configuration;
using Tras.Data.Mapping.Employee;
using Tras.Data.Mapping.Ration;

namespace Tras.Data
{
    public class TrasObjectContext : DbContext, IDbContext
    {
        public TrasObjectContext()
            : base("Name=DefaultConnection")
        {
        }
        
        //Config
        public DbSet<Lookup> Lookups { get; set; }

        public DbSet<RationItemCategory> RationItemCategories { get; set; }
        public DbSet<RationItem> RationItems { get; set; }
        public DbSet<RationHead> RationHeads { get; set; }
        public DbSet<RationSubHead> RationSubHeads { get; set; }
        public DbSet<Package> Packages { get; set; }
        
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<PersonPackage> PersonPackages { get; set; }

        // People Type
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<FamilyInfo> FamilyInfos { get; set; }
        public DbSet<Station> Stations { get; set; }
        // User Auth
        public DbSet<User> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMethod> RoleMethods { get; set; }

        // Residence
        public DbSet<Mess> Messes { get; set; }
        public DbSet<Room> Rooms { get; set; }

        //Dispersion 
        public DbSet<DispersionRecord> DispersionRecords { get; set; }
        public DbSet<DispersionItemRecord> DispersionItemRecords { get; set; }
        public DbSet<MessDispersionRecord> MessDispersionRecords { get; set; }
        public DbSet<MessDispersionItemRecord> MessDispersionItemRecords { get; set; }
        //Store
        public DbSet<DemandRecord> DemandRecords { get; set; }
        public DbSet<DemandItemRecord> DemandItemRecords { get; set; }
        public DbSet<StockRecord> StockRecords { get; set; }
        public DbSet<StockItemRecord> StockItemRecords { get; set; }

        #region IDbContext Implementation

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Get DbEntityEntry
        /// </summary>
        /// <param name="entity">Entity Object</param>
        /// <returns>DbEntityEntry</returns>
        public new DbEntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null,
            params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => !String.IsNullOrEmpty(type.Namespace))
               .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
