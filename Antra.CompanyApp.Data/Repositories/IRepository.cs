using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Data.Repositories
{
    interface IRepository<T>
    {
        int PrintAll(IEnumerable<T> lst);
        int Insert(T item);
        int Delete(T item);
        int Updata(T item);
        T GetById(int id);
        T GetByCondition(string condition);

    }
}
