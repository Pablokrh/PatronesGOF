using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            BebidaComponente cafe = new CafeSolo();
            cafe = new Leche(cafe);
            cafe = new Azucar(cafe);
            Console.WriteLine($" Producto: {cafe.Descripcion} tiene un costo de: ${cafe.Costo}");

            Console.ReadKey();
        }
    }

    public abstract class BebidaComponente
    {
        public abstract double Costo { get; }
        public abstract string Descripcion { get; }
        
    }

    public class CafeSolo : BebidaComponente
    {
        public override double Costo => 10;
        public override string Descripcion => "Café solo";
    }
    public class CafeExpresso : BebidaComponente
    {
        public override double Costo => 11;
        public override string Descripcion => "Café Expreso";
    }
    public class CafeDescafeinado : BebidaComponente
    {
        public override double Costo => 15;
        public override string Descripcion => "Café descafeinado";
    }
    public class TeTradicional : BebidaComponente
    {
        public override double Costo => 8;
        public override string Descripcion => "Té tradicional";
    }
     
    public abstract class AgregadoDecorator : BebidaComponente
    {
        protected BebidaComponente bebidaComponente;
        //Acá se la define como protected. Serán los hijos las que la utilicen.
            public AgregadoDecorator( BebidaComponente bebida)
        {
            bebidaComponente = bebida;
        }
    }

    public class Leche : AgregadoDecorator
    {
        public Leche(BebidaComponente bebidaComponente) : base(bebidaComponente) { }
        //Construtore.

        public override double Costo => bebidaComponente.Costo + 2;
        public override string Descripcion => string.Format($"{bebidaComponente.Descripcion}, Leche");
        //public override string Descripcion => bebidaComponente.Descripcion + ", Leche";
    }

    public class Edulcorante:AgregadoDecorator
    {
        public Edulcorante(BebidaComponente bebidaComponente): base(bebidaComponente) {}
       
        public override double Costo => bebidaComponente.Costo + 1;
        public override string Descripcion => string.Format($"{bebidaComponente.Descripcion}, Edulcorante");
    }

    public class Azucar : AgregadoDecorator
    {
        public Azucar(BebidaComponente bebidaComponente) : base(bebidaComponente) { }

        public override double Costo => bebidaComponente.Costo + 0.5;
        public override string Descripcion => string.Format($"{bebidaComponente.Descripcion}, Azucar");
    }

    public class Crema : AgregadoDecorator
    {
        public Crema(BebidaComponente bebidaComponente) : base(bebidaComponente) { }

        public override double Costo => bebidaComponente.Costo + 4;
        public override string Descripcion => string.Format($"{bebidaComponente.Descripcion}, Crema");
    }
}
