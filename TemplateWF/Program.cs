using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateWF
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }

    public abstract class Credito : Verificaciones
    {
        public Credito(Cliente c)
        {
            _cliente = c;
        }

        protected abstract override string VerificarAcciones();
        protected abstract override string VerificarBalance();
        protected abstract override string VerificarIngresos();
        protected abstract override string VerificarCreditos();
        //No entiendo la gracia de agregarles override a estos 4 métodos.
    }

    public abstract class Verificaciones
    {
        protected Cliente _cliente;

        public string[] Verificar()
        {
            var msg = new List<string>();
            msg.Add($"Verificando crédito para {_cliente.Nombre}");
            msg.Add(VerificarAcciones());
            msg.Add(VerificarBalance());
            msg.Add(VerificarIngresos());
            msg.Add(VerificarCreditos());
            return msg.ToArray();
        }
        protected abstract string VerificarAcciones();
        protected abstract string VerificarBalance();
        protected abstract string VerificarIngresos();
        protected abstract string VerificarCreditos();

    }
    public class CreditoPersonal : Credito
    {
        public CreditoPersonal(Cliente c):base (c)
        {

        }

        protected override string VerificarAcciones()
        {
            return "No es requerido verificar acciones para un préstamo personal";
        }

        protected override string VerificarBalance()
        {
            return "Verificando balance para préstamo personal";
        }

        protected override string VerificarCreditos()
        {
            return "Verificando créditos para préstamo personal";
        }

        protected override string VerificarIngresos()
        {
            return "Verificando ingresos para asignar préstamo personal";
        }
    }
    public class CreditoHipotecario : Credito
    {
        public CreditoHipotecario(Cliente c) : base(c)
        {

        }

        protected override string VerificarAcciones()
        {
            return "Verificando acciones";
        }

        protected override string VerificarBalance()
        {
            return "Verificando balance";
        }

        protected override string VerificarCreditos()
        {
            return "Verificando créditos";
        }

        protected override string VerificarIngresos()
        {
            return "Verificando ingresos";
        }
    }


}
