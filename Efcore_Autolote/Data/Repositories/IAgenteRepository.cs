using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.DBModels;

namespace Data.Repositories
{
    public interface IAgenteRepository
    {

        bool Save(Agente agente);

        Agente GetbyId(int id);

        IQueryable<Agente> GetAll();

        bool Update(Agente agente);

        bool Delete(int id);

        bool Exist(int id);

        bool Exist(string Nombre);



    }


}
