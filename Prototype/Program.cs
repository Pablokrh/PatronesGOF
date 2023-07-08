using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Patas = 4;
            animal.Nombre = "Dolly";
            Console.WriteLine(animal.Nombre+ " "+ animal.Patas);
            Animal animalclonado = animal.Clone() as Animal;

            animalclonado.Patas = 8;
            animalclonado.Nombre = "Wally";
            Console.WriteLine("-----------------------------\nTras uso de Clone:");
            Console.WriteLine(animalclonado.Nombre + " " + animalclonado.Patas);
            Console.WriteLine(animal.Nombre + " " + animal.Patas);


            Console.ReadKey();
        }
    }

    public class Animal: ICloneable
    {
        public int Patas { get; set; }
        public string Nombre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

   

}
