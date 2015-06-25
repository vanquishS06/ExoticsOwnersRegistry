using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

// This is the Generics Repository pattern Base class to create further specialized repositories
namespace WebEntityFramework.Models.Repositories
{
    // Generic Db context
    // Methods could be virtual to force superclass to implement them
//    public class Repository <T> where T : class
//    {
//        private bool disposed = false;
//        private ArtistDbContext context = null;

//        // Create a generic DbSet
//        protected DbSet<T> DbSet { get; set; }
        
//        // Constructor - create context
//        public Repository()
//        {
//            context = new ArtistDbContext();
//            // init DbSet
//            DbSet = context.Set<T>();
//        }
//        // constructor - pass a conext
//        public Repository (ArtistDbContext context)
//        {
//            this.context = context;
//        }

//        // All CRUD (Create/Read/Update/Delete) operations
//        public List <T> GetAll()
//        {
//            return DbSet.ToList();
//        }
//        public T Get(int id)
//        {
//            return DbSet.Find(id);
//        }
//        public void Add(T entity)
//        {
//            DbSet.Add(entity);
//        }
//        public void Delete(int id)
//        {
//            T rec = DbSet.Find(id);
//            if (rec != null)
//                DbSet.Remove(rec);
//            // Note: dont call savechanges as this is a 1 trip operation and save will be done on the server
//        }
//        public virtual void Update(T entity)
//        {
////            DbSet.Entry(entity).State = EntityState.Modified;
//            context.Entry(entity).State = EntityState.Modified;
//        }

//        public void SaveChanges()
//        {
//            context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            if (!disposed)
//            {
//                context.Dispose();
//                disposed = true;
//            }
//        }
//    }
}