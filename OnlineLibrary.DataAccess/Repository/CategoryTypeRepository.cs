using OnlineLibrary.Data;
using OnlineLibrary.DataAccess.Repository.IRepository;
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository
{
    public class CategoryTypeRepository : Repository<CategoryType>,ICategoryTypeRepository
    {
        private ApplicationDbContext _db;

        public CategoryTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(CategoryType obj)
        {
            _db.CategoryTypes.Update(obj);
        }
    }
}
