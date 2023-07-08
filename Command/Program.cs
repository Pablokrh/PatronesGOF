using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta1 = new Cuenta(15, 200);
            DepositarImpl opDepositar = new DepositarImpl(cuenta1, 100);
            RetirarImpl opRetirar = new RetirarImpl(cuenta1, 68);
            Invoker myInvoker = new Invoker();
            myInvoker.RecibirOperacion(opDepositar);
            myInvoker.RecibirOperacion(opRetirar);
            myInvoker.realizarOperaciones();

            Console.ReadKey();
        }
    }

    public class Cuenta
    {
        //Clase receiver/Request. Es sobre la que se hace la petición
        private int id;
        private double saldo;

        public Cuenta (int id, double saldo)
        {
            this.id = id;
            this.saldo = saldo;
        }

        public void Retirar (double monto)
        {
            saldo -= monto;
            Console.WriteLine("[COMANDO RETIRAR] Cuenta: "+id + " Saldo: "+ saldo);
        }

        public void Depositar(double monto)
        {
            saldo += monto;
            Console.WriteLine("[COMANDO DEPOSITAR] Cuenta: " + id + " Saldo: " + saldo);
        }
    }

   public interface IOperacion
    {
        //Esta es la parte command
        void Execute();
    }

    public class DepositarImpl : IOperacion
    {
        private Cuenta cuenta;
        private double monto;

        public DepositarImpl(Cuenta cuenta, double monto)
        {
            this.cuenta = cuenta;
            this.monto = monto;
        }

        public void Execute()
        {
            this.cuenta.Depositar(this.monto);
        }
    }
    public class RetirarImpl : IOperacion
    {
        private Cuenta cuenta;
        private double monto;

        public RetirarImpl(Cuenta cuenta, double monto)
        {
            this.cuenta = cuenta;
            this.monto = monto;
        }

        public void Execute()
        {
            this.cuenta.Retirar(this.monto);
        }
    }
    public class Invoker
    {
        //Invoker es el responable de apilar las operaciones y ejecutarlas
        private List<IOperacion> operaciones = new List<IOperacion>();

        public void RecibirOperacion(IOperacion operacion)
        {
            operaciones.Add(operacion);
        }
        public void realizarOperaciones()
        {
            operaciones.ForEach(x => x.Execute()); //Lambda
            operaciones.Clear();
        }

    }
}
