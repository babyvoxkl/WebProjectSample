using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Model;

namespace DataAccess
{
    public class DbAccess
    {
        public DbAccess()
        {
            ContextType = DbType.Cpoe;
            _dbContext = CreateContext();
        }

        public DbAccess(DbType dbType)
        {
            ContextType = dbType;
            _dbContext = CreateContext();
        }

        public DbAccess(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public enum DbType
        {
            Cpoe = 1
        }

        private readonly DbContext _dbContext;

        private DbType ContextType { get; }



        //private readonly string dbConnection;

        /// <summary>
        /// 链接数据库类型
        /// </summary>
        /// <returns></returns>
        private DbContext CreateContext()
        {
            DbContext dbContext;

            switch (ContextType)
            {
                case DbType.Cpoe:
                    {
                        dbContext = new DemoDbContext();
                    }
                    break;
                default:
                    {
                        dbContext = new DemoDbContext();
                    }
                    break;
            }

            return dbContext;
        }

        private DbContext CreateContext(DbConnection existingConnection, bool contextOwnsConnection)
        {
            DbContext dbContext;

            switch (ContextType)
            {
                case DbType.Cpoe:
                    {
                        dbContext = new DemoDbContext(existingConnection, contextOwnsConnection);
                    }
                    break;
                default:
                    {
                        dbContext = new DemoDbContext(existingConnection, contextOwnsConnection);
                    }
                    break;
            }

            return dbContext;
        }

        public delegate T DelegateGetEntity<T>(DbSet<T> dbSet) where T : class;

        public delegate List<T> DelegateGetEntityList<T>(DbSet<T> dbSet) where T : class;

        public delegate T DelegateGetEntityById<T>(DbSet<T> dbSet) where T : class;

        public delegate List<T> DelegateGetEntityListById<T>(DbSet<T> dbSet) where T : class;

        public T GetEntity<T>(DelegateGetEntity<T> delegateGetEntity, DbTransaction transaction) where T : class
        {
            T entity;
            DbContext dbContext = transaction != null
                ? CreateContext(transaction.Connection, false)
                : _dbContext;
            using (dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction);
                }
                DbSet<T> dbSet = dbContext.Set<T>();
                entity = delegateGetEntity(dbSet);
            }
            return entity;
        }

        public List<T> GetEntityList<T>(DelegateGetEntityList<T> delegateGetEntityList, DbContextTransaction transaction) where T : class
        {
            List<T> entityList;
            using (DbContext dbContext = _dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction.UnderlyingTransaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }
                try
                {
                    DbSet<T> dbSet = dbContext.Set<T>();
                    entityList = delegateGetEntityList(dbSet);
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }

            }
            return entityList;
        }

        public List<T> GetEntityListBySql<T>(string sql, DbContextTransaction transaction, params object[] parameters) where T : class
        {
            List<T> entityList;
            using (DbContext dbContext = _dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction.UnderlyingTransaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }
                try
                {
                    entityList = dbContext.Database.SqlQuery<T>(sql, parameters).ToList();
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }

            }
            return entityList;
        }

        public List<T> GetEntityListBySql<T>(string sql, DbContextTransaction transaction, int pageSize, int pageNum, out int count, params object[] parameters) where T : class
        {
            int skipCount = pageSize * (pageNum - 1);
            count = 0;
            List<T> entityList;
            using (DbContext dbContext = _dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction.UnderlyingTransaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }
                try
                {

                    var query = dbContext.Database.SqlQuery<T>(sql, parameters).ToList();
                    count = query.Count;
                    entityList =
                        query.Skip(skipCount).Take(pageSize).ToList();

                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }

            }
            return entityList;
        }

        public void AddOrUpdateEntity<T>(T entity, DbTransaction transaction) where T : class
        {
            DbContext dbContext = transaction != null
                ? CreateContext(transaction.Connection, false)
                : _dbContext;
            using (dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction);
                }
                DbSet<T> dbSet = dbContext.Set<T>();
                dbSet.AddOrUpdate(entity);
                dbContext.SaveChanges();
            }
        }

        public void AddOrUpdateEntityList<T>(List<T> entityList, DbTransaction transaction) where T : class
        {
            DbContext dbContext = transaction != null ? new DbContext(transaction.Connection, false) : _dbContext;
            using (dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }
                try
                {
                    DbSet<T> dbSet = dbContext.Set<T>();
                    dbSet.AddOrUpdate(entityList.ToArray());
                    dbContext.SaveChanges();
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }
            }
        }

        public void DeleteEntity<T>(DelegateGetEntityById<T> delegateGetEntityById, DbTransaction transaction) where T : class
        {
            DbContext dbContext = transaction != null ? new DbContext(transaction.Connection, false) : _dbContext;
            using (dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }

                try
                {
                    DbSet<T> dbSet = dbContext.Set<T>();
                    T entity = delegateGetEntityById(dbSet);
                    if (entity != null)
                    {
                        dbSet.Remove(entity);
                    }
                    dbContext.SaveChanges();
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }

            }
        }

        public void DeleteEntityList<T>(DelegateGetEntityListById<T> delegateGetEntityListById, DbTransaction transaction) where T : class
        {
            DbContext dbContext = transaction != null ? new DbContext(transaction.Connection, false) : _dbContext;
            using (dbContext)
            {
                if (transaction != null)
                {
                    dbContext.Database.UseTransaction(transaction);
                }
                else
                {
                    dbContext.Database.BeginTransaction();
                }
                try
                {
                    DbSet<T> dbSet = dbContext.Set<T>();
                    List<T> entityList = delegateGetEntityListById(dbSet);
                    if (entityList.Any())
                    {
                        dbSet.RemoveRange(entityList);
                    }
                    dbContext.SaveChanges();
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    if (transaction == null)
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }
                    throw;
                }
            }
        }

        private string GetConfigConnection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }

}