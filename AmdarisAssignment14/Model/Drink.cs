namespace AmdarisAssignment14.Model;

public class Drink
{
    private readonly List<Milk> _milk = [];
    private readonly List<Sugar> _sugar = [];
    private readonly List<BlackCoffee> _blackCoffee = [];

    public void AddBlackCoffee(BlackCoffee blackCoffee)
    {
        _blackCoffee.Add(blackCoffee);
    }

    public void AddSugar(Sugar sugar)
    {
        _sugar.Add(sugar);
    }

    public void AddMilk(Milk milk)
    {
        _milk.Add(milk);
    }
    
    public void ListIngredients()
    {
        Console.WriteLine("====Ingredients====");
        Console.Write("Coffee: ");
        foreach (var blackCoffee in _blackCoffee)
        {
            blackCoffee.PrintInfo();
        }
        Console.Write("\nMilk: ");
        foreach (var milk in _milk)
        {
            milk.PrintInfo();
        }
        Console.Write("\nSugar: ");
        foreach (var sugar in _sugar)
        {
            sugar.PrintInfo();
        }
    }
}