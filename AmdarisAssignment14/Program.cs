using AmdarisAssignment14.Builder;

namespace AmdarisAssignment14;

public class Program
{
    public static void Main()
    {
        var coffeeBuilder = new CoffeeBuilder();
        var coffeeDirector = new CoffeeDirector(coffeeBuilder);

        var espresso = coffeeDirector.MakeEspresso();
        var cappuccino = coffeeDirector.MakeCappuccino(milkType: MilkType.Oat, sugarAmount: 3);
        var flatWhite =
            coffeeDirector.MakeFlatWhite(milkType: MilkType.Soy, extraMilkType: MilkType.Oat, milkAmount:1, sugarAmount: 1);
        
        flatWhite.ListIngredients();
    }
}