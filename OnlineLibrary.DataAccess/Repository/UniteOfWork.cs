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
            CategoryType = new CategoryTypeRepository(_db);
            Category = new CategoryRepository(_db);

        }
        public ICategoryTypeRepository CategoryType { get; private set; }
        public ICategoryRepository Category { get; private set; }


        public void SaveChanges( )
        {
            _db.SaveChanges();
        }

        //void IUnitOfWork.SaveChanges( )
        //{
        //    throw new NotImplementedException();
        //}
    }
}
