using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryTypeRepository CategoryType { get; }

        ICategoryRepository Category { get; }

        void SaveChanges();

        //ICompanyRepository Company { get; }
        //IApplicationUserRepository ApplicationUser { get; }
        //IShoppingCartRepository ShoppingCart { get; }
        //IOrderDetailRepository OrderDetail { get; }
        //IOrderHeaderRepository OrderHeader { get; }

    }
}
