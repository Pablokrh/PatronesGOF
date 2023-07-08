using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            AntivirusAvanzado av = new AntivirusAvanzado();
            Contexto contexto1 = new Contexto(new AntivirusSimple());
            contexto1.Ejecutar();
            Thread.Sleep(1500);
            Console.Clear();
            Contexto contexto2 = new Contexto(av);
            contexto2.Ejecutar();
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    public interface IEstrategia
    {
        void Analizar();
    }

    public abstract class AnalisisSimple : IEstrategia
    {
        public void Analizar()
        {
            Iniciar();
            SaltarZip();
            Detener();
        }
        public abstract void Iniciar();
        public abstract void SaltarZip();
        public abstract void Detener();
    }

    public abstract class AnalisisAvanzado : IEstrategia
    {
        public void Analizar()
        {
            Iniciar();
            AnalizarMemoria();
            AnalizarKeyLoggers();
            AnalizarRootKits();
            DescomprimirZip();
            Detener();
        }
        public abstract void Iniciar();
        public abstract void AnalizarMemoria();
        public abstract void AnalizarKeyLoggers();
        public abstract void AnalizarRootKits();
        public abstract void DescomprimirZip();
        public abstract void Detener();
    }

   public class AntivirusSimple : AnalisisSimple
    {
        public override void Iniciar()
        {
            Console.WriteLine("Antivirus Simple - Análisis simple iniciado");
        }
        public override void SaltarZip()
        {
            try
            {
                Console.WriteLine("Analizando...");
                Thread.Sleep(2500);
                Console.WriteLine("No se pudo analizar archivos con la extensión '.zip'");
            } catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message); 
            }
        }
        public override void Detener()
        {
            Console.WriteLine("Antivirus Simple - Análisis simple finalizado");
        }
   }

    public class AntivirusAvanzado : AnalisisAvanzado
    {
        public override void AnalizarKeyLoggers()
        {
            try
            {
                Console.WriteLine("Analizando KeyLoggers...");
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
                //Qué será stacktrace??
            }
        }

        public override void AnalizarMemoria()
        {
            try
            {
                Console.WriteLine("Analizando memoria RAM...");
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
                //Qué será stacktrace??
            }
        }

        public override void AnalizarRootKits()
        {
            try
            {
                Console.WriteLine("Analizando en búsqueda de Root Kits...");
                Thread.Sleep(1500);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
                //Qué será stacktrace??
            }
        }

        public override void DescomprimirZip()
        {
            try
            {
                Console.WriteLine("Analizando archivos '.zip' ...");
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
                //Qué será stacktrace??
            }
        }

        public override void Detener()
        {
            Console.WriteLine("Antivirus Avanzado - Análisis avanzado finalizado");
        }

        public override void Iniciar()
        {
            Console.WriteLine("Antivirus Avanzado - Análisis avanzado iniciado");
        }
    }

    public class Contexto
    {
        private IEstrategia estrategia;
        public Contexto(IEstrategia estrategia)
        {
            this.estrategia = estrategia;
        }

        public void Ejecutar()
        {
            this.estrategia.Analizar();
        }

    }

}
