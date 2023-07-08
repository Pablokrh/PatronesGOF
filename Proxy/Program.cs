using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta(21, "Pepe", 5000);
            CuentaProxy cuentaProxy = new CuentaProxy();
            cuentaProxy.MostrarSaldo(cuenta);
            cuenta = cuentaProxy.DepositarDinero(cuenta, 2000);
            cuentaProxy.MostrarSaldo(cuenta);
            cuenta = cuentaProxy.RetirarDinero(cuenta, 3500);
            cuentaProxy.MostrarSaldo(cuenta);
            cuenta = cuentaProxy.RetirarDinero(cuenta, 4500);
            cuentaProxy.MostrarSaldo(cuenta);
            Console.ReadLine(); 

        }
    }

    interface ICuenta
    {
        Cuenta RetirarDinero(Cuenta cuenta, double monto);
        Cuenta DepositarDinero(Cuenta cuenta, double monto);
        void MostrarSaldo(Cuenta cuenta);
    }

    public class CuentaBancoAImpl : ICuenta
    {
        public Cuenta DepositarDinero(Cuenta cuenta, double monto)
        {
            double saldoActual = cuenta.GetSaldoInicial() - monto;
            cuenta.SetSaldoInicial(saldoActual);
            return cuenta;
        }

        public void MostrarSaldo(Cuenta cuenta)
        {
            Console.WriteLine($"El saldo actual es : $ {cuenta.GetSaldoInicial()}");
        }

        public Cuenta RetirarDinero(Cuenta cuenta, double monto)
        {
            double saldoActual = cuenta.GetSaldoInicial() + monto;
            cuenta.SetSaldoInicial(saldoActual);
            return cuenta;
        }
    }

    public class CuentaProxy : ICuenta
    {
        private CuentaBancoAImpl cuentaReal;

        public Cuenta DepositarDinero(Cuenta cuenta, double monto)
        {
            if (cuentaReal == null)
            {
                cuentaReal = new CuentaBancoAImpl();
                return cuentaReal.RetirarDinero(cuenta, monto);
            }
            else return cuentaReal.RetirarDinero(cuenta, monto);

        }

        public void MostrarSaldo(Cuenta cuenta)
        {
            if (cuentaReal == null)
            {
                cuentaReal = new CuentaBancoAImpl();
                cuentaReal.MostrarSaldo(cuenta);
            }
            else cuentaReal.MostrarSaldo(cuenta);
        }

        public Cuenta RetirarDinero(Cuenta cuenta, double monto)
        {
            if (cuentaReal == null)
            {
                cuentaReal = new CuentaBancoAImpl();
                return cuentaReal.DepositarDinero(cuenta, monto);
            }
            else return cuentaReal.DepositarDinero(cuenta, monto);
        }
    }


    public class Cuenta
    {
        private int idCuenta;
        private string usuario;
        private double saldoInicial;

        public Cuenta (int idCuenta, string usuario, double saldoInicial)
        {
            this.idCuenta = idCuenta;
            this.usuario = usuario;
            this.saldoInicial = saldoInicial;
        }      

        public int GetIdCuenta()
        {
            return idCuenta;
        }
        public void SetIdCuenta(int idCuenta)
        {
            this.idCuenta = idCuenta;
        }
        public string GetUsuario()
        {
            return usuario;
        }
        public void SetUsuario( string usuario)
        {
            this.usuario = usuario;
        }
         public double GetSaldoInicial()
        {
            return saldoInicial;
        }

        public double SetSaldoInicial(double saldo)
        {
            this.saldoInicial = saldo;
            return saldo;
        }


    }

}
