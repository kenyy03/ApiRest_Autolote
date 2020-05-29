using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IOrdenRepository
    {
        bool Save(Orden order);

        Orden GetbyId(int id);

        IQueryable<Orden> GetAll();

        bool Update(Orden order);

        bool Delete(int id);

        bool Exist(int id);

        bool Exist(DateTime date);
    }
}
