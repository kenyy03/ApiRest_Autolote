using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public interface IClienteRepository
    {
        bool Save(Cliente client);

        bool Update(Cliente client);

        bool Delete(int id);

        Cliente GetbyId(int id);

        IQueryable<Cliente> GetAll();

        bool Exist(int id);

        bool Exist(string name);


    }
}
