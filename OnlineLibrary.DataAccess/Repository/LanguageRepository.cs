using OnlineLibrary.Data;
using OnlineLibrary.DataAccess.Repository.IRepository;
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly ApplicationDbContext _db;

        public LanguageRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Language obj)
        {
            _db.Languages.Update(obj);
        }
    }
}
