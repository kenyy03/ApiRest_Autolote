using Data.Repositories;
using Entity.DBModels;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        //Objects statics
        static AgenteRepository repository = new AgenteRepository();
        static Agente Agente = new Agente();

        static BaseRepository brepository = new BaseRepository();
        static Base Obase = new Base();
        static void Main(string[] args)
        {
            int resp = 1;
            bool operacionexitosa = false;

            do
            {
                Console.WriteLine("============================");
                Console.WriteLine("1. Registrar agente");
                Console.WriteLine("2. Actualizar agente");
                Console.WriteLine("3. Eliminar agente");
                Console.WriteLine("4. Buscar agente");
                Console.WriteLine("5. Listar todos los agentes");
                Console.WriteLine("6. Asociar Agente a Base");
                Console.WriteLine("7. Salir");
                Console.WriteLine("============================");

                Console.WriteLine("Ingrese opcion");
                resp = Convert.ToInt32(Console.ReadLine());

                switch (resp)
                {
                    case 1:
                        Agente = Agregar();
                        operacionexitosa = repository.Save(Agente);

                        if (operacionexitosa)
                            Console.WriteLine("Se ha agregado el registro");
                        break;

                    case 2:
                        Agente = Actualizar();
                        operacionexitosa = repository.Update(Agente);
                        if (operacionexitosa)
                        {
                            Console.WriteLine("Se ha actualizado el registro");
                        }
                        break;

                    case 3:
                        Delete();
                        break;

                    case 4:
                        Buscar();
                        break;

                    case 5:
                        Listar();
                        break;

                    case 6:
                        //LISTA DE BASES DISPONIBLES
                        BListar();
                        Console.WriteLine("Ingrese Id Base que desea asociar: ");
                        Console.Write("--->");
                        int inputIdBase = Convert.ToInt32(Console.ReadLine());
                        //LISTA DE AGENTE DONDE SE ASOCIARA LA BASE
                        Listar();
                        Console.WriteLine("Ingrese Id Agente que desea asociar: ");
                        Console.Write("--->");
                        int inputIdAgente = Convert.ToInt32(Console.ReadLine());

                        

                        Agente = Actualizar(inputIdAgente,inputIdBase);
                        operacionexitosa = repository.Update(Agente);
                        if (operacionexitosa)
                        {
                            Console.WriteLine("Se ha actualizado el registro");
                        }
                        break;

                    default:
                        break;
                }


            } while (resp != 7);
        }

        static Agente Agregar()
        {
            Agente agente = new Agente();
            Console.WriteLine("Nombre: ");
            agente.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            agente.Apellido = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            agente.NumeroTelefono = Console.ReadLine();
            Console.WriteLine("Salario: ");
            agente.Salario = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Id Base: ");
            agente.IdBase = Convert.ToInt32(Console.ReadLine());

            return agente;
        }

        static Agente Actualizar()
        {

            Agente agente = new Agente();


            Console.WriteLine("Ingrese el id del agente");
            int id = Convert.ToInt32(Console.ReadLine());

            agente = repository.GetbyId(id);

            Console.WriteLine("Nombre: ");
            agente.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            agente.Apellido = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            agente.NumeroTelefono = Console.ReadLine();
            Console.WriteLine("Salario: ");
            agente.Salario = Convert.ToDecimal(Console.ReadLine());

            return agente;
        }
        static Agente Actualizar(int idagente, int idbase)
        {
            Agente agente = new Agente();
            agente = repository.GetbyId(idagente);
            agente.IdBase = idbase;

            return agente;
        }

        static void Delete()
        {
            Console.WriteLine("Ingrese el id del agente");
            int id = Convert.ToInt32(Console.ReadLine());
            bool operacionexistosa = repository.Delete(id);
            if (operacionexistosa)
            {
                Console.WriteLine("El registro ha sido eliminado");
            }

        }

        static void Buscar()
        {
            Console.WriteLine("Ingrese el id del agente");
            int id = Convert.ToInt32(Console.ReadLine());
            Agente = repository.GetbyId(id);
            if (Agente != null)
            {
                MostrarInfo(Agente);
            }
        }

        static void Listar()
        {
            var data = repository.GetAll();
            if (data != null)
            {
                Console.Clear();
                foreach (var item in data)
                {
                    MostrarInfo(item);
                }
            }
        }

        static void BListar()
        {
            var data = brepository.GetAll();
            if (data != null)
            {
                Console.Clear();
                foreach (var item in data)
                {
                    MostrarInfo(item);
                }
            }
        }

        static void MostrarInfo(Agente agente)
        {
            Console.WriteLine("======================");
            Console.WriteLine("{0} : {1}", "Id", agente.IdAgente);
            Console.WriteLine("{0} : {1}", "Nombre", agente.Nombre);
            Console.WriteLine("{0} : {1}", "Apellido", agente.Apellido);
            Console.WriteLine("{0} : {1}", "IdBase", agente.IdBase);
            Console.WriteLine("{0} : {1}", "Numero Telefono", agente.NumeroTelefono);
            Console.WriteLine("{0} : {1}", "Salario", agente.Salario);
            Console.WriteLine("======================");
        }
        static void MostrarInfo(Base pbase)
        {
            Console.WriteLine("======================");
            Console.WriteLine("{0} : {1}", "Id", pbase.IdBase);
            Console.WriteLine("{0} : {1}", "Nombre", pbase.Nombre);
            Console.WriteLine("{0} : {1}", "Departamento", pbase.Departamento);
            Console.WriteLine("{0} : {1}", "Ciudad", pbase.Ciudad);
            Console.WriteLine("{0} : {1}", "Direccion", pbase.Direccion);
            Console.WriteLine("{0} : {1}", "Numero Telefono", pbase.NumeroTelefono);
            Console.WriteLine("======================");
        }
    }
}
