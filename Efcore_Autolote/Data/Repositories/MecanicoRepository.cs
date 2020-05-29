using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class MecanicoRepository:IMecanicoRepository
    {
        public readonly DB_Context db;

        public MecanicoRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TMecanico.Find(id);
                if (data!=null)
                {
                    db.TMecanico.Remove(data);
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
                var data = db.TMecanico.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(string name)
        {
            try
            {
                var data = db.TMecanico.Any(x => x.Nombre == name);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Mecanico> GetAll()
        {
            try
            {
                var data = db.TMecanico.Select(x=> new Mecanico()
                {
                    IdMecanico = x.IdMecanico,
                    IdBase = x.IdBase,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    NumeroTelefono = x.NumeroTelefono,
                    Salario = x.Salario,
                    FechaContratacion = x.FechaContratacion
                });
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Mecanico GetbyId(int id)
        {
            try
            {
                var data = db.TMecanico.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Mecanico mechanic)
        {
            try
            {
                var data = ConvertToTable(mechanic);
                db.TMecanico.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Mecanico mechanic)
        {
            try
            {
                var data = db.TMecanico.Find(mechanic.IdMecanico);
                if (data!=null)
                {
                    data.IdBase = mechanic.IdBase == null ? data.IdBase : mechanic.IdBase;
                    data.Nombre = mechanic.Nombre == null ? data.Nombre : mechanic.Nombre;
                    data.Apellido = mechanic.Apellido == null ? data.Apellido : mechanic.Apellido;
                    data.NumeroTelefono = mechanic.NumeroTelefono == null ? data.NumeroTelefono : mechanic.NumeroTelefono;
                    data.Salario = mechanic.Salario == null ? data.Salario : mechanic.Salario;
                    data.FechaContratacion = mechanic.FechaContratacion == null ? data.FechaContratacion : mechanic.FechaContratacion;
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

        #region ConvertMethods
        TMecanico ConvertToTable(Mecanico mechanic)
        {
            return new TMecanico
            {
                IdMecanico = mechanic.IdMecanico,
                IdBase = mechanic.IdMecanico,
                Nombre = mechanic.Nombre,
                Apellido = mechanic.Apellido,
                NumeroTelefono = mechanic.NumeroTelefono,
                Salario = mechanic.Salario,
                FechaContratacion = mechanic.FechaContratacion
            };
        }

        Mecanico ConvertToDomain(TMecanico tmechanic)
        {
            return new Mecanico
            {

                IdMecanico = tmechanic.IdMecanico,
                IdBase = tmechanic.IdMecanico,
                Nombre = tmechanic.Nombre,
                Apellido = tmechanic.Apellido,
                NumeroTelefono = tmechanic.NumeroTelefono,
                Salario = tmechanic.Salario,
                FechaContratacion = tmechanic.FechaContratacion
            };
        }
        #endregion
    }
}
