using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IReparacionRepository
    {
        bool Save(Reparacion reparation);

        Reparacion GetbyId(int id);

        IQueryable<Reparacion> GetAll();

        bool Update(Reparacion reparation);

        bool Delete(int id);

        bool Exist(int id);

        bool Exist(DateTime date);
    }
}
