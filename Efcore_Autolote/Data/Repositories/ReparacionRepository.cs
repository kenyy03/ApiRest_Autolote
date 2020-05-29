using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class ReparacionRepository
    {
        public readonly DB_Context db;

        //Default Constructor
        public ReparacionRepository()
        {
            db = new DB_Context();
        }

        //Methods


        public bool Delete(int id)
        {
            try
            {
                var data = db.TReparacion.Find(id);
                if (data != null)
                {
                    db.TReparacion.Remove(data);
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
                var data = db.TReparacion.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(DateTime date)
        {
            try
            {
                var data = db.TReparacion.Any(x => x.Fecha == date);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Reparacion> GetAll()
        {
            try
            {
                var data = db.TReparacion.Select(x => new Reparacion()
                {
                    IdReparacion = x.IdReparacion,
                    IdAuto = x.IdAuto,
                    IdMecanico = x.IdMecanico,
                    Fecha = x.Fecha,
                    Costo = x.Costo,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Reparacion GetbyId(int id)
        {
            try
            {
                var data = db.TReparacion.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Reparacion reparation)
        {
            try
            {
                var data = ConvertToDBTable(reparation);
                db.TReparacion.Add(data);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Reparacion reparation)
        {
            try
            {
                var data = db.TReparacion.Find(reparation.IdReparacion);

                if (data != null)
                {
                    data.IdAuto = reparation.IdAuto == null ? data.IdAuto : reparation.IdAuto;
                    data.IdMecanico = reparation.IdMecanico == null ? data.IdMecanico : reparation.IdMecanico;
                    data.Fecha = reparation.Fecha == null ? data.Fecha : reparation.Fecha;
                    data.Costo = reparation.Costo == null ? data.Costo : reparation.Costo;

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

        public TReparacion ConvertToDBTable(Reparacion reparation)
        {
            return new TReparacion
            {
                Fecha = reparation.Fecha,
                Costo = reparation.Costo,
                IdMecanico = reparation.IdMecanico,
                IdReparacion = reparation.IdReparacion,
                IdAuto = reparation.IdAuto
            };
        }

        public Reparacion ConvertToDomain(TReparacion treparation)
        {
            return new Reparacion
            {
                Fecha = treparation.Fecha,
                Costo = treparation.Costo,
                IdMecanico = treparation.IdMecanico,
                IdReparacion = treparation.IdReparacion,
                IdAuto = treparation.IdAuto
            };
        }

        #endregion


    }
}
