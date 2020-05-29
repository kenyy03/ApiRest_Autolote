using Data.DbModels;
using Entity.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly DB_Context db;
        public ClienteRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TCliente.Find(id);
                if (data!=null)
                {
                    db.TCliente.Remove(data);
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
                var data = db.TCliente.Find(id);
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
                var data = db.TCliente.Any(x => x.Nombre == name);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<Cliente> GetAll()
        {
            try
            {
                var data = db.TCliente.Select(x => new Cliente()
                {
                    IdCliente = x.IdCliente,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    NumeroTelefono = x.NumeroTelefono,
                    Direccion = x.Direccion
                });
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Cliente GetbyId(int id)
        {
            try
            {
                var data = db.TCliente.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Cliente client)
        {
            try
            {
                var data = ConvertToTable(client);
                db.TCliente.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Cliente client)
        {
            try
            {
                var data = db.TCliente.Find(client.IdCliente);
                if (data != null)
                {
                    data.Nombre = client.Nombre == null ? data.Nombre : client.Nombre;
                    data.Apellido = client.Apellido == null ? data.Apellido : client.Apellido;
                    data.NumeroTelefono = client.NumeroTelefono == null ? data.NumeroTelefono : client.NumeroTelefono;
                    data.Direccion = client.Direccion == null ? data.Direccion : client.Direccion;

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
        TCliente ConvertToTable(Cliente client)
        {
            return new TCliente
            {
                IdCliente = client.IdCliente,
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                NumeroTelefono = client.NumeroTelefono,
                Direccion = client.Direccion
            };
        }

        Cliente ConvertToDomain(TCliente tclient)
        {
            return new Cliente
            {
                IdCliente = tclient.IdCliente,
                Nombre = tclient.Nombre,
                Apellido = tclient.Apellido,
                NumeroTelefono = tclient.NumeroTelefono,
                Direccion = tclient.Direccion
            };
        }
        #endregion
    }
}
