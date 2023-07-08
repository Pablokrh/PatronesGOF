Pizzeria pizzeria;
Pizza pizza;

pizzeria = new PizzeríaArgentina();
pizza = pizzeria.CrearPizza("napolitana");
pizza.Render();
pizza = pizzeria.CrearPizza("cancha");
pizza.Render();

pizzeria= new PizzeríaItaliana();
pizza = pizzeria.CrearPizza("napolitana");
pizza.Render();
pizza = pizzeria.CrearPizza("cancha");
pizza.Render();





public abstract class Pizzeria
{
    public abstract Pizza CrearPizza(string tipo);

}

public class PizzeríaArgentina : Pizzeria
{
    public override Pizza CrearPizza(string tipo)
    {
        if (tipo== "cancha")
        {
            return new PizzaCancha("Argentina");
        }
        else if (tipo == "napolitana")
        {
            return new PizzaNapolitana("Argentina");
        }
        else { return null; }
    }
}

public class PizzeríaItaliana : Pizzeria
{
    public override Pizza CrearPizza(string tipo)
    {
        if (tipo == "cancha")
        {
            return new PizzaCancha("Italia");
        }
        else if (tipo == "napolitana")
        {
            return new PizzaNapolitana("Italia");
        }
        else { return null; }
    }
}

public abstract class Pizza
{
    protected string descripcion;
    protected string origen;

    public void Render()
    {
        Console.WriteLine(string.Format("Pizza de {0} hecha en {1}", descripcion, origen));
    }
}


public class PizzaCancha : Pizza
{
    public PizzaCancha(string origen)
    {
        descripcion = "Pizza de cancha";
        this.origen = origen;
    }
}


public class PizzaNapolitana : Pizza
{
    public PizzaNapolitana(string origen)
    {
        descripcion = "Pizza napolitana";
        this.origen = origen;
    }
}