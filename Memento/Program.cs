using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreJuego = "Superjuegazo-3000";
            Juego juego1 = new Juego();
            juego1.setNombre(nombreJuego);
            juego1.setCheckpoint(1);

            Caretaker caretaker = new Caretaker();
            Originator originator = new Originator();

            juego1 = new Juego();
            juego1.setNombre(nombreJuego);
            juego1.setCheckpoint(2);
            originator.setEstado(juego1);

            juego1 = new Juego();
            juego1.setNombre(nombreJuego);
            juego1.setCheckpoint(3);
            originator.setEstado(juego1);

            caretaker.AddMementos(originator.Guardar()); //Se guarda en posición 0
            juego1 = new Juego();
            juego1.setNombre(nombreJuego);
            juego1.setCheckpoint(4);

            originator.setEstado(juego1);
            caretaker.AddMementos(originator.Guardar());  //Se guarda en posición 1

            juego1 = new Juego();
            juego1.setNombre(nombreJuego);
            juego1.setCheckpoint(5);
            originator.setEstado(juego1);
            caretaker.AddMementos(originator.Guardar());
            originator.Restaurar(caretaker.GetMemento(0));

            juego1 = originator.getEstado();
            Console.WriteLine(juego1.toString());
            Console.ReadKey();
        }
    }

    public class Juego
    {
        private string nombre;
        private int checkpoint;

        public int getCheckpoint()
        {
            return checkpoint;
        }
        public void setCheckpoint (int checkpoint)
        {
            this.checkpoint = checkpoint;
        }
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre (string nombre)
        {
            this.nombre = nombre;
        }
         public string toString()
        {
            return "Juego [Nombre= "+nombre+ ". Checkpoint= "+ checkpoint+"]";
        }
    }

    public class Originator
    {
        private Juego estado;
        public void setEstado(Juego estado)
        {
            this.estado = estado;
        }

        public Juego getEstado()
        {
            return estado;
        }

        public Memento Guardar()
        {
            return new Memento(estado);
        }
        public void Restaurar(Memento m)
        {
            this.estado = m.GetEstado();
        }
    }

    public class Memento
    {
        private Juego estado;

        public Memento(Juego estado)
        {
            this.estado = estado;
        }
        public Juego GetEstado()
        {
            return estado;
        }
    }

    public class Caretaker
    {
        private List<Memento> mementos = new List<Memento>();
        public void AddMementos(Memento m)
        {
            mementos.Add(m);
        }
        public Memento GetMemento(int index)
        {
            return mementos[index];
        }
    }
   

}
