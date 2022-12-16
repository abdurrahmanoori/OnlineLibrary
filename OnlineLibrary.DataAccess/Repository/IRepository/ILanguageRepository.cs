using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository.IRepository
{
    public interface ILanguageRepository : IRepository<Language>
    {
        void Update(Language obj);
    }
}
