using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonaDao dao = new PersonaDaoImpl();
            dao.listarTodos().ForEach(x => Console.WriteLine(x.GetNombre()));

            Persona per = new Persona("Sluzky");
            per.SetId(3);
            dao.Registrar(per);

            Console.ReadKey(); 
        }
    }

    public class Persona
    {
        private int id;
        private String nombre;

        public Persona(String nombre)
        {
            this.nombre = nombre;
        }
        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
        public String GetNombre()
        {
            return nombre;
        }
    }

    public interface IPersonaDao
    {
        List<Persona> listarTodos();
        Persona leerPorId(int id);
        void Registrar(Persona persona);
        void Actualizar(Persona persona);
        void Eliminar(int id);
    }

    public class PersonaDaoImpl : IPersonaDao
    {
        public void Actualizar(Persona persona)
        {
            Console.WriteLine("Persona " + persona.GetNombre() + " actualizada");
        }

        public void Eliminar(int id)
        {
            Console.WriteLine("Id: "+ id + " eliminado");
        }

        public Persona leerPorId(int id)
        {
            //Acá va toda la lógica lógica
            return null;
        }

        public List<Persona> listarTodos()
        {
            List<Persona> lista = new List<Persona>();
            Persona per = new Persona("Mito");
            per.SetId(1);

            lista.Add(per);
            per = new Persona("Code");
            per.SetId(2);
            lista.Add(per);
            return lista; 
        }

        public void Registrar(Persona persona)
        {
            Console.WriteLine("Persona "+ persona.GetNombre()+ " registrada");      
        }
    }
}
