using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDeep
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal1 = new Animal() { Nombre = "Holton", Patas = 6 };
            animal1.Rasgos = new Detalles();
            animal1.Rasgos.Color = "Naranjeta";
            animal1.Rasgos.Raza = "Gato obvio";

            Console.WriteLine("El viviente se llama "+ animal1.Nombre +
                " y tiene "+ animal1.Patas + " patas"+
                "\nEs de color "+ animal1.Rasgos.Color+
                ". Es de raza "+ animal1.Rasgos.Raza);

            Console.WriteLine("-----------------------------------\n");

            Animal animalclonado = animal1.Clone() as Animal;
            animalclonado.Nombre = "Larry";
            animalclonado.Patas = 2;
            animalclonado.Rasgos.Raza = "Perro";
            animalclonado.Rasgos.Color = "Negrazo";
            Console.WriteLine("El viviente se llama " + animalclonado.Nombre +
               " y tiene " + animalclonado.Patas + " patas" +
               "\nEs de color " + animalclonado.Rasgos.Color +
               ". Es de raza " + animalclonado.Rasgos.Raza);
            Console.WriteLine(  "\n");

            Console.WriteLine("El viviente se llama " + animal1.Nombre +
               " y tiene " + animal1.Patas + " patas" +
               "\nEs de color " + animal1.Rasgos.Color +
               ". Es de raza " + animal1.Rasgos.Raza);

            Console.ReadKey();
        }
    }


    public class Animal : ICloneable
    {
        public int Patas { get; set; }
        public string Nombre { get; set; }
        public Detalles Rasgos { get; set; }

        public object Clone()
        {
            Animal clonado = this.MemberwiseClone() as Animal;
            Detalles detalles = new Detalles();
            detalles.Color = this.Rasgos.Color;
            detalles.Raza = this.Rasgos.Raza;
            clonado.Rasgos = detalles;

            return clonado;
          
        }
    }

    public class Detalles
    {
        public string Color { get; set; }
        public string Raza { get; set; }

    }

}
