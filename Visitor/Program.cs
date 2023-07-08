using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IVisitor visitante = new VisitanteConcreto();
            Componente dr = new DiscoRigido("1238-AF");
            Componente pb=new PlacaBase("AB-152");
            Componente p = new Procesador("KFS-SJDS123");

            IVisitor visitante2 = new VisitanteConcreto2();


            dr.Aceptar(visitante);
            pb.Aceptar(visitante);
            //En este momente se ejecuta el método Aceptar. Va al visitante y visitar. Ahí hace el printeo.
            p.Aceptar(visitante);

            Console.WriteLine("------------------------------", Environment.NewLine);
            //Acá se ve como al cambiar el visitante, cambia el resultado. Daría cuenta del polimorfismo
            dr.Aceptar(visitante2);
            pb.Aceptar(visitante2);
            p.Aceptar(visitante2);

            Console.ReadKey();

        }
    }

    public abstract class Componente
    {
        private string _serial;

        public Componente(string serial)
        {
            _serial = serial;
        }

        public string Serial()
        {
            return _serial;
        }

        //Este antes no existía
        public void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(_serial);
            //esto viola el encapsulamiento...Eso es malo.
        }
    }

    public class PlacaBase : Componente
    {
        public PlacaBase(string serial): base(serial) { }

        /*
         * Así estaban antes los 3 componentes
        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
        */
    }
    public class Procesador : Componente
    {
        public Procesador(string serial) : base(serial) { }

        /*
        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
        */
    }
    public class DiscoRigido : Componente
    {
        public DiscoRigido(string serial) : base(serial) { }

        /*
        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this);
        }
        */
    }

    public interface IVisitor
    {
        void Visitar(string serie);
        /*
         * ASI ERA EL CÓDIGO EN UN PRIMER MOMENTO
        void Visitar(Procesador componente);
        void Visitar(PlacaBase componente);
        void Visitar(DiscoRigido componente);
        */
    }

    public class VisitanteConcreto : IVisitor
    {
        public void Visitar(string serie)
        {
            Console.WriteLine(string.Format(" s/n {0}", serie ) );
        }


        /*
         * ASI ERA ORIGINALMENTE
        public void Visitar(Procesador componente)
        {
            Console.WriteLine(string.Format("Procesador s/n {0}", componente.Serial()));        }

        public void Visitar(PlacaBase componente)
        {
            Console.WriteLine(string.Format("Placa base s/n {0}", componente.Serial()));
        }
        public void Visitar(DiscoRigido componente)
        {
            Console.WriteLine(string.Format("Disco rígido s/n {0}", componente.Serial()));
        }
        */
    }

    public class VisitanteConcreto2 : IVisitor
    {
        public void Visitar(string serie)
        {
            Console.WriteLine(string.Format(" Número de serie es {0}", serie));
        }


    }

}

