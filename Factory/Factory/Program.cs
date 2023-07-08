//Hay varios objetos que heredan de la misma clase en este patrón.
//Se hace que una clase externa gestione la creación de estos objetos.
BebidaEmbriagente obebida = Creador.CreadorBebida(Creador.Vino_Tinto);
Console.WriteLine(obebida.CuantoEmbriagaPorHora());
Console.WriteLine("------------------------------------------\n");
BebidaEmbriagente obebida2 = Creador.CreadorBebida(Creador.Cerveza);
Console.WriteLine(obebida2.CuantoEmbriagaPorHora());



public class Creador
{
    public const int Vino_Tinto = 1;
    public const int Cerveza = 2;
   
    public static BebidaEmbriagente CreadorBebida(int tipo)
    {
        switch (tipo)
        {
            case Vino_Tinto:
                return new VinoTinto();
                case Cerveza:
                return new Cerveza();
                default: return null;
        }
    }
}

public abstract class BebidaEmbriagente
{
    public abstract int CuantoEmbriagaPorHora();
}

public class VinoTinto : BebidaEmbriagente
{
    public override int CuantoEmbriagaPorHora()
    {
        return 20;
    }
}

public class Cerveza : BebidaEmbriagente
{
    public override int CuantoEmbriagaPorHora()
    {
        return 12;
    }
}