using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Switch @switch = new Switch();
            @switch.Presionar();
            //Antes de este Presionar(), el estado actual del switch es encendido.
            //por eso va a entrar a Encendido, donde va a hacer New Apagado() y así...
            @switch.Presionar();
            @switch.Presionar();
            @switch.Presionar();
            Console.WriteLine("-----------------------",Environment.NewLine);
            Console.WriteLine("Ahora lo apaga Dios");
            @switch.DefinirEstado(new Apagado());
            @switch.Presionar();

            Console.ReadKey();
        }
    }

    public class Switch
    {
        Estado _estado;

        public Switch()
        {
            _estado = new Encendido();
            //Al instanciarse, el estado es encendido.
        }

        public void DefinirEstado(Estado estado)
        {
            _estado = estado;
        }

        public void Presionar()
        {
            _estado.ControlarEstado(this);
            Console.WriteLine(_estado.Describir());
        }
    }

    public interface Estado
    {
        void ControlarEstado(Switch sw);
        string Describir();     
    }

    public class Encendido : Estado
    {
        public void ControlarEstado(Switch sw)
        {
            sw.DefinirEstado(new Apagado());
        }

        public string Describir()
        {
            return "Switch encendido";
        }
    }

    public class Apagado : Estado
    {
        public void ControlarEstado(Switch sw)
        {
            sw.DefinirEstado(new Encendido());
        }

        public string Describir()
        {
            return "Switch apagado";
        }
    }

}