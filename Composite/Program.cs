using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Componente root = new Directorio("Raíz");

            Componente archivo1 = new Archivo("archivo1.txt", 10);
            Componente archivo2 = new Archivo("archivo2.txt", 30);
            Componente archivo3 = new Archivo("archivo3.txt", 120);
            Componente archivo4 = new Archivo("archivo4.txt", 800);
            Componente archivo5 = new Archivo("archivo5.txt", 340);

            Componente dir1 = new Directorio("Dir1");
            Componente dir2 = new Directorio("Dir2");
            Componente dir3 = new Directorio("Dir3");
            Componente dirPablo = new Directorio("DirPablo");

            dir1.AgregarHijo(archivo1);
            dir2.AgregarHijo(archivo2);
            dir3.AgregarHijo(archivo3);
            dir3.AgregarHijo(archivo4);
            dir1.AgregarHijo(dir3);

            root.AgregarHijo(dir1);
            root.AgregarHijo(dir2);
            root.AgregarHijo(archivo5);
                      
            Console.WriteLine("El tamaño del archivo" + archivo3.Nombre + " es " + archivo3.ObtenerTamaño) ;
            Console.WriteLine($"El tamaño del directorio {root.Nombre} es {root.ObtenerTamaño}");
            Console.WriteLine($"El tamaño del directorio {dir1.Nombre} es {dir1.ObtenerTamaño}");
            Console.WriteLine($"El tamaño del directorio {dir2.Nombre} es {dir2.ObtenerTamaño}");
            Console.WriteLine($"El tamaño del directorio {dir3.Nombre} es {dir3.ObtenerTamaño}");

            Console.ReadKey();

        }
    }


    public abstract class Componente
    {

        public Componente (string nombre)
        {
            Nombre = nombre;

        }

        public string Nombre { get; }

        public abstract void AgregarHijo(Componente c);

        public abstract IList<Componente> ObtenerHijos();

        public abstract int ObtenerTamaño { get; }

    }

    public class Directorio : Componente
    {
        private List<Componente> _hijos;

        public Directorio (string nombre) : base(nombre)
        {
            _hijos = new List<Componente>();            
        }

        public override void AgregarHijo(Componente c)
        {
            //Acá recomienda hacer validaciones. Como por ejemplo, que no existan ya hijos con el mismo nombre.
            _hijos.Add(c);
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos.ToArray();
        }

        //Muy extraño el método siguiente:
        
        public override int ObtenerTamaño
        {
            get
            {
                int t = 0;

                foreach (var item in _hijos)
                {
                    t += item.ObtenerTamaño;
                }
                return t;
            }
        }
    }

    public class Archivo : Componente
    {
        int _tamaño;
        public Archivo (string nombre, int tamaño) : base (nombre)
        {
            _tamaño = tamaño;
        }

        public int Tamaño { get { return _tamaño; } }
        //El otro getter lo hice sencillito, este no se por qué lo hacen así.

       public override void AgregarHijo(Componente c)
       {

       }
        public override IList<Componente> ObtenerHijos()
        {
            return null;
        }

        //Como archivo no crea hijos, estos 2 métodos están vacíos. Está mal esto ehh!!!
        //Se viola el ppio de segregación de interfaces.

        public override int ObtenerTamaño
        {
            get
            {
                return _tamaño;
            }
        }
    }

}
