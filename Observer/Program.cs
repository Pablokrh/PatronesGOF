using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            new PesoArgObservador(subject);
            //Cuando se instancian C/U de estas 3 clases. Desde su constructor se agregan a la
            //lista observadores, presente en la clase Subject.
            new PesoChiObservador(subject);
            // Que se note que no se está haciendo:
            // PesoChiObservador pesoChiObservador = new PesoChiObservador(subject);
            // "porque solo necesitamos la instancia no necesariamente acceder a sus metodos o algo asi"
            //Eso dijo alguien en el chat.
            new PesoMexObservador(subject);

            Console.WriteLine("Si desea cambiar 10 dólares, obtendrá:");
            subject.SetEstado(10);
            //Apenas se cambia el estado, se dispara automáticamente la notificación Actualizar.

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Si desea cambiar 250 dólares, obtendrá:");
            subject.SetEstado(250);

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Si desea cambiar 400 dólares, obtendrá:");
            subject.SetEstado(400);
            Console.ReadKey();

        }
    }

    public class Subject
    {
        private List<Observador> observadores = new List<Observador>();
        private int estado;

        public int GetEstado()
        {
            return estado;
        }
        public void SetEstado(int estado)
        {
            this.estado = estado;
            NotificarTodosObservadores();
            //Apenas cambia el estado se dispara esta notificación que están suscritos a este sujeto.
        }
        public void AgregarObservadores(Observador observador)
        {
            observadores.Add(observador);
        }
        public void NotificarTodosObservadores()
        {
            foreach (var item in observadores)
            {
                item.Actualizar();
            }
        }        
    }

    public abstract class Observador
    {
        protected double valorCambio;
        protected Subject sujeto;
        protected string moneda;

        public void Actualizar()
        {
            Console.WriteLine(moneda +": " + (sujeto.GetEstado() * valorCambio));
        }
    }

    public class PesoArgObservador : Observador
    {
      
        public PesoArgObservador(Subject sujeto)
        {
            moneda = "ARS";
            valorCambio = 467;
            this.sujeto = sujeto;
            this.sujeto.AgregarObservadores(this);
            //Ahí se envía a la clase sujeto para que se agregue a la lista el presente observador
        }
       
    }
    public class PesoMexObservador : Observador
    {
        
        public PesoMexObservador(Subject sujeto)
        {
            moneda = "MEX";
            valorCambio = 30;
            this.sujeto = sujeto;
            this.sujeto.AgregarObservadores(this);
        }
      
    }
    public class PesoChiObservador : Observador
    {
        
        public PesoChiObservador(Subject sujeto)
        {
            moneda = "CHI";
            valorCambio = 18;
            this.sujeto = sujeto;
            this.sujeto.AgregarObservadores(this);
        }
       
    }

}
