using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IAutoRepository
    {
        bool Register(Auto auto);

        bool Delete(int id);

        bool Update(Auto auto);

        bool Exist(int id);

        bool Exist(string brand);

        Auto SearchToId(int id);

        IQueryable<Auto> GetAll();
    }
}
