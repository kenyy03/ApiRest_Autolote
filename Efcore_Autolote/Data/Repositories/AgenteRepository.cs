using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Repositories
{
    public class AgenteRepository : IAgenteRepository
    {
        public readonly DB_Context db;
        public AgenteRepository()
        {
            db = new DB_Context();
        }


        public bool Delete(int id)
        {
            try
            {
                var data = db.TAgente.Find(id);
                if (data != null)
                {
                    db.TAgente.Remove(data);
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
                var data = db.TAgente.Find(id);
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
                var data = db.TAgente.Any(x => x.Nombre == Nombre);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Agente> GetAll()
        {
            try
            {
                var data = db.TAgente.Select(x => new Agente()
                {
                    IdAgente = x.IdAgente,
                    IdBase = x.IdBase,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    NumeroTelefono = x.NumeroTelefono,
                    Salario = x.Salario
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Agente GetbyId(int id)
        {
            try
            {
                var data = db.TAgente.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Agente agente)
        {
            try
            {
                var data = ConvertToDBTable(agente);
                db.TAgente.Add(data);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Agente agente)
        {
            try
            {
                var data = db.TAgente.Find(agente.IdAgente);

                if (data != null)
                {
                    data.Nombre = agente.Nombre == null ? data.Nombre : agente.Nombre;
                    data.Apellido = agente.Apellido == null ? data.Apellido : agente.Apellido;
                    data.NumeroTelefono = agente.NumeroTelefono == null ? data.NumeroTelefono : agente.NumeroTelefono;
                    data.Salario = agente.Salario == null ? data.Salario : agente.Salario;
                    data.IdBase = agente.IdBase == 0 ? data.IdBase : agente.IdBase;

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

        #region OtrosMetodos

        public TAgente ConvertToDBTable(Agente agente)
        {
            return new TAgente
            {
                Nombre = agente.Nombre,
                Apellido = agente.Apellido,
                NumeroTelefono = agente.NumeroTelefono,
                Salario = agente.Salario,
                IdBase = agente.IdBase,
                IdAgente = agente.IdAgente
            };
        }

        public Agente ConvertToDomain(TAgente agente)
        {
            return new Agente
            {
                Nombre = agente.Nombre,
                Apellido = agente.Apellido,
                NumeroTelefono = agente.NumeroTelefono,
                Salario = agente.Salario,
                IdBase = agente.IdBase,
                IdAgente = agente.IdAgente
            };
        }

        #endregion


    }
}
