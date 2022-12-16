using OnlineLibrary.Data;
using OnlineLibrary.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository
{
    public class Book : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public Book(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Book obj)
        {

        }
    }
}
