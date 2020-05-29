using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class OrdenRepository : IOrdenRepository
    {
        public readonly DB_Context db;

        //Default Constructor
        public OrdenRepository()
        {
            db = new DB_Context();
        }

        //Methods

        public bool Save(Orden order)
        {
            try
            {
                var data = ConvertToTable(order);
                db.TOrden.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TOrden.Find(id);
                if (data != null)
                {
                    db.TOrden.Remove(data);
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

        public bool Update(Orden order)
        {
            try
            {
                var data = db.TOrden.Find(order.IdOrden);

                if (data != null)
                {
                    data.IdCliente = order.IdCliente == null ? data.IdCliente : order.IdCliente;
                    data.IdAuto = order.IdAuto == null ? data.IdAuto : order.IdAuto;
                    data.Fecha = order.Fecha == null ? data.Fecha : order.Fecha;
                    data.RentaFechaInicio = order.RentaFechaInicio == null ? data.RentaFechaInicio : order.RentaFechaInicio;
                    data.RentaFechaFin = order.RentaFechaFin == null ? data.RentaFechaFin : order.RentaFechaFin;
                    data.FechaCancelacion = order.FechaCancelacion == null ? data.FechaCancelacion : order.FechaCancelacion;
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
                var data = db.TOrden.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(DateTime fecha)
        {
            try
            {
                var data = db.TOrden.Any(x => x.Fecha == fecha);
                return data;
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }

        public IQueryable<Orden> GetAll()
        {
            try
            {
                var data = db.TOrden.Select(x => new Orden()
                {
                    IdOrden = x.IdOrden,
                    IdCliente = x.IdCliente,
                    IdAuto = x.IdAuto,
                    Fecha = x.Fecha,
                    RentaFechaInicio = x.RentaFechaInicio,
                    RentaFechaFin = x.RentaFechaFin,
                    FechaCancelacion = x.FechaCancelacion
                });
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Orden GetbyId(int id)
        {
            try
            {
                var data = db.TOrden.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
       
        #region Convert Methods
        TOrden ConvertToTable(Orden order)
        {
            return new TOrden
            {
                IdOrden = order.IdOrden,
                IdCliente = order.IdCliente,
                IdAuto = order.IdAuto,
                Fecha = order.Fecha,
                RentaFechaInicio = order.RentaFechaInicio,
                RentaFechaFin = order.RentaFechaFin
            };
        }

        Orden ConvertToDomain (TOrden torder)
        {
            return new Orden
            {
                IdOrden = torder.IdOrden,
                IdCliente = torder.IdCliente,
                IdAuto = torder.IdAuto,
                Fecha = torder.Fecha,
                RentaFechaInicio = torder.RentaFechaInicio,
                RentaFechaFin = torder.RentaFechaFin
            };
        }
        #endregion



    }
}
