using Data.Repositories;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Injection;

namespace Data
{
    public class DIRegisterData
    {
        public static List<IClassType> GetDataList()
        {
            var list = new List<IClassType>();
            list.Add(new ClassType<IAgenteRepository, AgenteRepository>());
            list.Add(new ClassType<IBaseRepository, BaseRepository>());
            list.Add(new ClassType<IAutoRepository, AutoRepository>());
            list.Add(new ClassType<IClienteRepository, ClienteRepository>());
            list.Add(new ClassType<IMecanicoRepository, MecanicoRepository>());
            list.Add(new ClassType<IOrdenRepository, OrdenRepository>());
            list.Add(new ClassType<IReparacionRepository, ReparacionRepository>());
            return list;
        }
    }
}
