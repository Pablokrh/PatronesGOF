using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder2
{
    class Program
    {
        static void Main(string[] args)
        {
            Director miDirector = new Director();
            IBuilderNormal normal = new IBuilderNormal();
            miDirector.Construye(normal);
            //Acá se le pasa al método construye del objeto miDirector como parámetro el IbuiilderNormal
            //miDirector habría solo 1 que se reutiliza

            Producto auto1 = normal.ObtenProducto();
            //Una vez construido, el método obten producto te lo entrega, en este caso a una instancia de la clase producto
            Console.WriteLine("------------------------------" + Environment.NewLine);
            auto1.MostrarAuto();
            auto1.ColocarMotor(new MotorGrande());
            Console.WriteLine("------------------------------" + Environment.NewLine);
            //Como señala un usuario. Este código permite modificar desde el main las partes del auto, eso sería un error.
            auto1.MostrarAuto();
            //Esto sería el printeo
            Console.ReadKey();
        }
    }

    public class Director
    {
        public void Construye (IBuilder _constructor)
        {
            _constructor.ConstruyeMotor();
            _constructor.ConstruyeLlantas();
            _constructor.ConstruyeCarroceria();
        }
    }

    public class IBuilderNormal : IBuilder
    {
        private Producto auto = new Producto();

        public void ConstruyeCarroceria()
        {
            auto.ColocarMotor(new MotorBasico());
        }

        public void ConstruyeLlantas()
        {
            auto.ColocarLlantas(new Llantas12());
        }

        public void ConstruyeMotor()
        {
            auto.ColocarCarroceria(new CarroceriaBasica());
        }

        public Producto ObtenProducto()
        {
            return auto;
        }
    }

    public class IBuilderPremium  : IBuilder
    {
        private Producto auto = new Producto();

        public void ConstruyeCarroceria()
        {
            auto.ColocarMotor(new MotorGrande());
        }

        public void ConstruyeLlantas()
        {
            auto.ColocarLlantas(new LlantasSuper());
        }

        public void ConstruyeMotor()
        {
            auto.ColocarCarroceria(new CarroceriaEspecial());
        }
        public Producto ObtenProducto()
        {
            return auto;
        }
    }

    public class Producto
    {
        private IMotor motor;
        private ICarroceria carroceria;
        private ILlanta llanta;

        public void ColocarMotor(IMotor _motor)
        {
            motor = _motor;
            Console.WriteLine("Se ha colocado el motor: {0}", motor.especificaciones());
        }

        public void ColocarCarroceria(ICarroceria _carroceria)
        {
            carroceria = _carroceria;
            Console.WriteLine("Se ha colocado una carrocería: " + carroceria.caracteristicas());              
        }
        public void ColocarLlantas(ILlanta _llanta)
        {
            llanta = _llanta;
            Console.WriteLine("Se ha colocado una llanta: "+llanta.informacion());
        }

        public void MostrarAuto()
        {
            Console.WriteLine("Tu auto tiene {0}, {1}. {2}", motor.especificaciones(), llanta.informacion(), carroceria.caracteristicas());
        }
    }

    public interface IBuilder
    {
        void ConstruyeMotor();
        void ConstruyeCarroceria();
        void ConstruyeLlantas();
    }

    public interface ICarroceria
    {
        string caracteristicas();
    }

    public class CarroceriaBasica : ICarroceria
    {
        public string caracteristicas()
        {
            return "Carrocería de metal";
        }
    }
    public class CarroceriaEspecial : ICarroceria
    {
        public string caracteristicas()
        {
            return "Carrocería de fibra de carbono";
        }
    }

    public interface IMotor
    {
        string especificaciones();
    }

    public class MotorBasico : IMotor
    {
        public string especificaciones()
        {
            return "Motor de 4 cilindros";
        }
    }
    public class MotorGrande : IMotor
    {
        public string especificaciones()
        {
            return "Motor de 8 cilindros";
        }
    }

    public interface ILlanta
    {
        string informacion();
    }

    public class Llantas12 : ILlanta
    {
        public string informacion()  
        { 
            return " Llantas de 14 pulgadas";
        }
    }
    public class LlantasSuper : ILlanta
    {
        public string informacion()
        {
            return " Llantas de 18 pulgadas. Rines de aluminio";
        }
    }
}
