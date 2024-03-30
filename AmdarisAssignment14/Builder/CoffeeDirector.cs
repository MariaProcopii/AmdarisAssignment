using AmdarisAssignment14.Model;

namespace AmdarisAssignment14.Builder;

public class CoffeeDirector
{
    private readonly CoffeeBuilder _coffeeBuilder;

    public CoffeeDirector(CoffeeBuilder coffeeBuilder)
    {
        _coffeeBuilder = coffeeBuilder;
    }

    public Drink MakeEspresso(MilkType extraMilkType = 0, int milkAmount = 0, int sugarAmount = 0)
    {
        _coffeeBuilder.Reset();
        AddExtraIngredients(extraMilkType, milkAmount, sugarAmount);
        return _coffeeBuilder.AddBlackCoffee().Build();
    }

    public Drink MakeCappuccino(MilkType milkType, MilkType extraMilkType = 0, int milkAmount = 0, int sugarAmount = 0)
    {
        _coffeeBuilder.Reset();
        AddExtraIngredients(extraMilkType, milkAmount, sugarAmount);
        return _coffeeBuilder.AddBlackCoffee().AddMilk(milkType).Build();
    }

    public Drink MakeFlatWhite(MilkType milkType, MilkType extraMilkType = 0, int milkAmount = 0, int sugarAmount = 0)
    {
        _coffeeBuilder.Reset();
        AddExtraIngredients(extraMilkType, milkAmount, sugarAmount);
        return _coffeeBuilder.AddBlackCoffee().AddBlackCoffee().AddMilk(milkType).Build();
    }

    private void AddExtraIngredients(MilkType extraMilkType, int milkAmount, int sugarAmount)
    {
        for (int i = 0; i < milkAmount; i++)
        {
            _coffeeBuilder.AddMilk(extraMilkType);
        }
        
        for (int i = 0; i < sugarAmount; i++)
        {
            _coffeeBuilder.AddSugar();
        }
    }
}