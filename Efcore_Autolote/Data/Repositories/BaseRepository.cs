using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class BaseRepository:IBaseRepository
    {
        public readonly DB_Context db;

        //Default Constructor
        public BaseRepository()
        {
            db = new DB_Context();
        }

        //Methods
        public bool Delete(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                if (data != null)
                {
                    db.TBase.Remove(data);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(string Nombre)
        {
            try
            {
                var data = db.TBase.Any(x => x.Nombre == Nombre);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Base> GetAll()
        {
            try
            {
                var data = db.TBase.Select(x => new Base()
                {
                    IdBase = x.IdBase,
                    Nombre = x.Nombre,
                    Departamento = x.Departamento,
                    Ciudad = x.Ciudad,
                    Direccion = x.Direccion,
                    NumeroTelefono = x.NumeroTelefono
                });
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Base GetbyId(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                
                return data != null ? ConvertToClassBase(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Base pbase)
        {
            try
            {
                var data = ConvertToDBTableBase(pbase);
                db.TBase.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Base pbase)
        {
            try
            {
                var data = db.TBase.Find(pbase.IdBase);
                if (data != null)
                {
                    data.Nombre = pbase.Nombre == null ? data.Nombre : pbase.Nombre;
                    data.Departamento = pbase.Departamento == null ? data.Departamento : pbase.Departamento;
                    data.Ciudad = pbase.Ciudad == null ? data.Ciudad : pbase.Ciudad;
                    data.Direccion = pbase.Direccion == null ? data.Direccion : pbase.Direccion;
                    data.NumeroTelefono = pbase.NumeroTelefono == null ? data.NumeroTelefono : pbase.NumeroTelefono;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public int Asociar(TAgente agente)
        {
            try
            {
                var data = db.TBase.Find(agente.IdBase);

                return data != null ? data.IdBase = agente.IdBase : 0;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        #region Convert Methods

        public TBase ConvertToDBTableBase(Base pbase)
        {
            return new TBase
            {
                Nombre = pbase.Nombre,
                Departamento = pbase.Departamento,
                Ciudad = pbase.Ciudad,
                Direccion = pbase.Direccion,
                NumeroTelefono= pbase.NumeroTelefono
            };
        }

        public Base ConvertToClassBase(TBase pbase)
        {
            return new Base
            {
                Nombre = pbase.Nombre,
                Departamento = pbase.Departamento,
                Ciudad = pbase.Ciudad,
                Direccion = pbase.Direccion,
                NumeroTelefono = pbase.NumeroTelefono
            };
        }

        #endregion


    }
}
