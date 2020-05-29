using System;
using System.Collections.Generic;
using System.Linq;
using Entity.DBModels;
using System.Text;
using Data.DbModels;

namespace Data.Repositories
{
    public interface IBaseRepository
    {
        bool Save(Base pbase);

        Base GetbyId(int id);

        IQueryable<Base> GetAll();

        bool Update(Base pbase);

        bool Delete(int id);

        bool Exist(int id);

        bool Exist(string Nombre);

        int Asociar(TAgente agente);
    }
}
