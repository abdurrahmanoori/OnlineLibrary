using OnlineLibrary.Data;
using OnlineLibrary.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            //Category = new ICategoryRepository(_db);

        }
       // public ICategoryRepository Category { get; private set; }

        public void Save( )
        {
            _db.SaveChanges();
        }

    }
}
