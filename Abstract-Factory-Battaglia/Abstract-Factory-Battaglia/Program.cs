//Afirma que es fácil agregar familias (pizzerías) de productos.
//Dice que es dificil agregar nuevos tipos de productos(por ejemplo, empanadas), ya que hay que refactorizar mucho código.
//Violándose el principio Solid Open Closed.
//Dice también que toda fábrica-familia debe crear todos los tipos de productos.
//Si o si tienen que estar definidos los tipos de productos.
Pizzeria fabrica;
fabrica = new PizzeriaArgentina();

Pizza pizza = fabrica.CrearPizza();
Empanada empanada = fabrica.CrearEmpanada();
Console.WriteLine(empanada.Descripcion);

Console.WriteLine(  pizza.Descripcion);

fabrica = new PizzeriaItaliana();
empanada = fabrica.CrearEmpanada();
Console.WriteLine(empanada.Descripcion);
pizza = fabrica.CrearPizza();
Console.WriteLine(pizza.Descripcion);

fabrica = new PizzeriaYanqui();
pizza = fabrica.CrearPizza();
empanada = fabrica.CrearEmpanada();
Console.WriteLine(empanada.Descripcion);
Console.WriteLine(pizza.Descripcion);


public abstract class Pizzeria
{
    public abstract Pizza CrearPizza();
    public abstract Empanada CrearEmpanada();
}

public class PizzeriaArgentina : Pizzeria
{
    public override Pizza CrearPizza()
    {
        return new PizzaCancha();
    }

    public override Empanada CrearEmpanada()
    {
        return new EmpanadaDeCarne();
    }
}
public class PizzeriaItaliana:Pizzeria
{
    public override Pizza CrearPizza()
    {
        return new PizzaNapolitana();
    }
    public override Empanada CrearEmpanada()
    {
        return new EmpanadaCapresse();
    }
}

public class PizzeriaYanqui : Pizzeria
{
    public override Pizza CrearPizza()
    {
        return new PizzaConCheddar();
    }

    public override Empanada CrearEmpanada()
    {
        return new EmpanadaDeCheddar();
    }
}

public abstract class Pizza
{
    protected string descripcion;

    public object Descripcion
    {
        get
        {
            return descripcion;
        }
    }
}

public class PizzaCancha : Pizza
{
    public PizzaCancha()
    {
        descripcion = "Pizza de cancha";
    }
}

public class PizzaConCheddar : Pizza
{
    public PizzaConCheddar()
    {
        descripcion = "Pizza de Cheddar";
    }
}
public class PizzaNapolitana : Pizza
{
    public PizzaNapolitana()
    {
        descripcion = "Pizza napolitana";
    }
}

public abstract class Empanada
{
    protected string descripcion;

    public object Descripcion
    {
        get
        {
            return descripcion;
        }
    }
}

public class EmpanadaDeCarne:Empanada
{
    public EmpanadaDeCarne()
    {
        descripcion = "Empanada de Carne";
    }
}
public class EmpanadaCapresse : Empanada
{
    public EmpanadaCapresse()
    {
        descripcion = "Empanada Capresse";
    }
}

public class EmpanadaDeCheddar : Empanada
{
    public EmpanadaDeCheddar()
    {
        descripcion = "Empanada de Cheddar";
    }
}
