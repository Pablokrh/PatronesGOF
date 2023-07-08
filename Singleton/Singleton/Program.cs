
Console.WriteLine( Singleton.Instance.mensaje);
Console.WriteLine("------------------------------------------"+Environment.NewLine);
Console.WriteLine( Singleton.Instance.mensaje);
//Singleton sing = new Singleton();
Console.WriteLine(Singleton.Instance.suma(5, 7));
Console.WriteLine(Singleton.InstaciaTrucha.suma(5, 7));
Console.WriteLine(Singleton.InstaciaTrucha.suma(5, 7));
Console.WriteLine(Singleton.InstaciaTrucha.suma(5, 7));




public class Singleton
{
    private static Singleton instance=null;
    public string mensaje = "";

    private Singleton() 
        //HDeLeon pone aquí protected
    {
        mensaje=  "Hola mundo!";

    }
    public int suma(int num1, int num2)
    {
        return num1+num2;
    }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    public static Singleton InstaciaTrucha 
    {  
        get { return instance = new Singleton(); }
    }
}