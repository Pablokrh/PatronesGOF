using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Motor motorNaftero = new MotorNaftero();
            motorNaftero.Arrancar();
            motorNaftero.Acelerar();
            motorNaftero.Detener();
            motorNaftero.CargarCombustible();

            Console.WriteLine("-----------------------------" + Environment.NewLine);
            Motor motorElectrico = new MotorElectricoAdapter();
            motorElectrico.Arrancar();
            motorElectrico.Acelerar();
            motorElectrico.Detener();
            motorElectrico.CargarCombustible();

            Console.ReadKey();
        }
    }
    public abstract class Motor
    {
        public abstract void Acelerar();
        public abstract void Arrancar();
        public abstract void Detener();
        public abstract void CargarCombustible();
    }

    public class MotorDiesel : Motor
    {
        public override void Acelerar()
        {
            Console.WriteLine("Acelerando el motor diesel...");
        }

        public override void Arrancar()
        {
            Console.WriteLine("Arrancando el motor diesel...");
        }

        public override void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible al motor diesel...");
        }

        public override void Detener()
        {
            Console.WriteLine("Deteniendo el motor diesel...");
        }
    }
    public class MotorNaftero : Motor
    {
        public override void Acelerar()
        {
            Console.WriteLine("Acelerando el motor naftero...");
        }

        public override void Arrancar()
        {
            Console.WriteLine("Arrancando el motor naftero...");
        }

        public override void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible al motor naftero...");
        }

        public override void Detener()
        {
            Console.WriteLine("Deteniendo el motor naftero...");
        }
    }
    public class MotorElectricoAdapter : Motor
    {
        MotorElectrico motorElectrico = new MotorElectrico();

        public override void Acelerar()
        {
            motorElectrico.Mover();
        }

        public override void Arrancar()
        {
            motorElectrico.Conectar();
            motorElectrico.Activar();
        }

        public override void CargarCombustible()
        {
            motorElectrico.Enchufar();
        }

        public override void Detener()
        {
            motorElectrico.Parar();
            motorElectrico.Desconectar();
            motorElectrico.Desactivar();
        }
    }

    public class MotorElectrico
    {
        bool _conectado;
        bool _activo;
        bool _moviendo;

        public void Conectar()
        {
            if (_conectado)
            {
                Console.WriteLine("El auto ya se encuentra conectado");
            }
            else
            {
                _conectado = true;
                Console.WriteLine("¡Motor conectado!");
            }
        }

        public void Activar()
        {
            if (_activo)
            {
                Console.WriteLine("El auto ya se encontraba activo");
            }
            else
            {
                Console.WriteLine("El motor eléctrico se ha activado");
                _activo = true;
            }
        }

        public void Mover()
        {
            if (_moviendo)
            {
                Console.WriteLine("El auto ya se estaba moviendo");
            }
            else
            {
                _moviendo = true;               
                Console.WriteLine("El auto eléctrico ha empezado a moverse");
            }
        }

        public void Enchufar()
        {
            if (_activo)
            {
                Console.WriteLine("Imposible enchufar un auto activo");
            }
            else
            {
                Console.WriteLine("Enchufastes el motor electrico para cargarlo");
            }
        }

        public void Parar()
        {
            if (_activo)
            {
                _moviendo = false;
                _activo = false;
                Console.WriteLine("El motor eléctrico se ha detenido");
            }
            else
            {
                Console.WriteLine("El motor ya se encuentra apagado");
            }
        }

        public void Desconectar()
        {

            Console.WriteLine("El auto se ha desconectado");
        }
        public void Desactivar()
        {
            if (_activo)
            {
                _activo = false;
                Console.WriteLine("El motor eléctrico se ha desactivado");
            }
            else
            {   
                Console.WriteLine("El auto ya se encontraba desactivado");
            }
        }
    }

}
