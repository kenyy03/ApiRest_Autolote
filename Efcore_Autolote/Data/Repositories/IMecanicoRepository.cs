using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IMecanicoRepository
    {
        bool Save(Mecanico mechanic);

        bool Delete(int id);

        bool Update(Mecanico mechanic);

        bool Exist(int id);

        bool Exist(string name);

        Mecanico GetbyId(int id);

        IQueryable<Mecanico> GetAll();


    }
}
