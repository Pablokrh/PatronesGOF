using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Comprador comprador = new Comprador();
            Gerente gerente = new Gerente();
            Director director = new Director();

            comprador.AgregarSiguiente(gerente);
            gerente.AgregarSiguiente(director);

            var c = new Compra();
            double importe = 1;
            while (importe != 0)
            {
                Console.WriteLine("Ingrese el importe de la compra (0 para salir)");
                importe = double.Parse(Console.ReadLine());
                c.Importe = importe;
                comprador.Procesar(c);            
            }
            Console.ReadKey();
        }
    }

    public abstract class Aprobador
    {
        protected Aprobador _siguiente;

        public void AgregarSiguiente (Aprobador aprobador)
        {
            _siguiente = aprobador;
        }

        public abstract void Procesar(Compra C);
    }

    public class Compra
    {
        public double Importe { get; set; }

    }

    public class Comprador : Aprobador
    {
        public override void Procesar(Compra c)
        {
            if (c.Importe < 100)
            {
                Console.WriteLine("Compra aprobada por el {0}", this.GetType().Name);
            }
            else
            {
                _siguiente.Procesar(c);
            }
        }
    }
    public class Gerente : Aprobador
    {
        public override void Procesar(Compra c)
        {
            if (c.Importe <= 1000)
            {
                Console.WriteLine("Compra aprobada por el {0}", this.GetType().Name);
            }
            else
            {
                _siguiente.Procesar(c);
            }
        }
    }
    public class Director : Aprobador
    {
        public override void Procesar(Compra c)
        {     
            Console.WriteLine("Compra aprobada por el {0}", this.GetType().Name);
            //Es el último eslabón de la cadena, por lo que no requiere condiciones.
            //Si el pedido llega a él, es necesario que lo apruebe
        }
    }
}
