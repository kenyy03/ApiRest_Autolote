using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class AutoRepository : IAutoRepository
    {
        public readonly DB_Context db;

        public AutoRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TAuto.Find(id);
                if (data != null)
                {
                    db.TAuto.Remove(data);
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
                var data = db.TAuto.Find(id);
                if (data != null)
                {
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

        public bool Exist(string brand)
        {
            try
            {
                var data = db.TAuto.Any(x=> x.Marca == brand);
                return data;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Auto> GetAll()
        {
            try
            {
                var data = db.TAuto.Select(x => new Auto()
                {
                    IdAuto = x.IdAuto,
                    IdBase= x.IdBase,
                    Marca= x.Marca,
                    Modelo= x.Modelo,
                    NumeroRegistro= x.NumeroRegistro,
                    AnioProduccion= x.AnioProduccion,
                    PrecioRenta= x.PrecioRenta,
                    Categoria= x.Categoria
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Register(Auto auto)
        {
            try
            {
                var data = ConvertToTable(auto);
                db.TAuto.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Auto SearchToId(int id)
        {
            try
            {
                var data = db.TAuto.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Update(Auto auto)
        {
            try
            {
                var data = db.TAuto.Find(auto.IdAuto);
                if (data != null)
                {
                    data.IdBase = auto.IdBase == null ? data.IdBase : auto.IdBase;
                    data.Marca = auto.Marca == null ? data.Marca : auto.Marca;
                    data.Modelo = auto.Modelo == null ? data.Modelo : auto.Modelo;
                    data.NumeroRegistro = auto.NumeroRegistro == null ? data.NumeroRegistro : auto.NumeroRegistro;
                    data.AnioProduccion = auto.AnioProduccion == null ? data.AnioProduccion : auto.AnioProduccion;
                    data.PrecioRenta = auto.PrecioRenta == null ? data.PrecioRenta : auto.PrecioRenta;
                    data.Categoria = auto.Categoria == null ? data.Categoria : auto.Categoria;

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

        #region ConvertMethods
        TAuto ConvertToTable(Auto auto)
        {
            return new TAuto
            {
                IdAuto = auto.IdAuto,
                IdBase = auto.IdBase,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                NumeroRegistro = auto.NumeroRegistro,
                AnioProduccion = auto.AnioProduccion,
                PrecioRenta = auto.PrecioRenta,
                Categoria = auto.Categoria
            };
        }

        Auto ConvertToDomain(TAuto auto)
        {
            return new Auto
            {
                IdAuto = auto.IdAuto,
                IdBase = auto.IdBase,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                NumeroRegistro = auto.NumeroRegistro,
                AnioProduccion = auto.AnioProduccion,
                PrecioRenta = auto.PrecioRenta,
                Categoria = auto.Categoria
            };
        }
        #endregion
    }
}
